using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Helpers;
using System.DirectoryServices;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace WebApi.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string passworkd);
        IEnumerable<User> GetAll();
    }
    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly work_apsContext _db;

        public UserService(IOptions<AppSettings> appSettings, work_apsContext context)
        {
            _appSettings = appSettings.Value;
            _db = context;
        }

        public User Authenticate(string username, string password)
        {
            
            // AD 인증
            string sDomain = "apsfamily.com";
            if(!IsAuthenticated(sDomain, username, password) )
            {
                return null;
            }

            // 사용자 정보 가져 옴
            var gw_user = _db.VCoviGwUser.SingleOrDefault(u => u.UrCode == username);
            var user = new User
            {
                Username = gw_user.UrCode,
                Company = gw_user.DnName,
                DepName = gw_user.GrName
            };

            // JWT Token 생성
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = creds
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated(string domain, string username, string pwd)
        {
            //string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry("LDAP://"+domain, username, pwd);

            try
            {
                //Bind to the native AdsObject to force authentication.
                object obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();

                if (null == result)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user. " + ex.Message);
            }

            return true;
        }
    }
}
