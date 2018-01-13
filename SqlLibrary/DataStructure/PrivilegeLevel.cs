using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary.DataStructure
{
    public class PrivilegeLevel
    {
        public const string Generally = "Generally";
        public const string Administrative = "Administrative";

        public static string[] ToArray()
        {
            string[] arr = new string[2];
            arr[0] = Generally;
            arr[1] = Administrative;

            return arr;
        }
    }
}
