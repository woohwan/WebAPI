using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class VCoviGwUser
    {
        public string UrCode { get; set; }
        public string DnCode { get; set; }
        public string DnName { get; set; }
        public string GrCode { get; set; }
        public string GrName { get; set; }
        public string EmpNo { get; set; }
        public string EmpName { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string TitleCode { get; set; }
        public string TitleName { get; set; }
        public string LevelCode { get; set; }
        public string LevelName { get; set; }
        public string UseYn { get; set; }
        public string EnterDate { get; set; }
        public string RetireDate { get; set; }
        public string TelNo { get; set; }
        public string MobileNo { get; set; }
        public string EMail { get; set; }
        public string BirthType { get; set; }
        public string BirthDay { get; set; }
        public string ParentCode { get; set; }
        public string ParentName { get; set; }
        public string DepName { get; set; }
        public string GrSort { get; set; }
    }
}
