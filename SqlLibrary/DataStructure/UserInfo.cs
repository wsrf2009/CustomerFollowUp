using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary.DataStructure
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Image Portrait { get; set; }
        public string Privilege { get; set; }
        public string Nickname { get; set; }
        public string RegisTime { get; set; }
        public string LastLogin { get; set; }
        public string LastLoginLanIp { get; set; }
        public string LastLoginWanIp { get; set; }
        public string LastLoginMac { get; set; }
        public string LastLoginHostName { get; set; }
        public string LastLoginUserName { get; set; }
        public string LastLogout { get; set; }
    }
}
