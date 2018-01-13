using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFUSystem.Tools
{
    class SettingsHelper
    {
        public static bool GetRememberPassword()
        {
            return Properties.Settings.Default.RememberPassword;
        }

        public static void UpdateRememberPassword(bool remember)
        {
            Properties.Settings.Default.RememberPassword = remember;
            Properties.Settings.Default.Save();
        }
    }
}
