using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary.DataStructure
{
    public class LoginLog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string LoginLanIp { get; set; }
        public string LoginWanIp { get; set; }
        public string LoginMac { get; set; }
        public string LoginHostName { get; set; }
        public string LoginUserName { get; set; }
        public string Logout { get; set; }
        public int Uid { get; set; }
    }
}
