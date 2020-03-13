using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    //[EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly work_apsContext db;
        private readonly IUserService _userService;

        public UsersController(work_apsContext context, IUserService userService)
        {
            db = context;
            _userService = userService;
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticationModel model)
        {
            
            var user = _userService.Authenticate(model.UserId, model.Password);
            var json_user = JsonConvert.SerializeObject(user);
            return Ok(json_user);
        }
    }
}