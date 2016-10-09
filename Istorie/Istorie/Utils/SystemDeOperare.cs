using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istorie.Utils
{
    public static class SystemDeOperare
    {
        public static bool isXP = false;
        public static bool isXP64 = false;
        public static bool isVista = false;
        public static bool isWin7 = false;
        public static bool isWin8 = false;
        public static bool isWin8p1 = false;
        public static bool isWin10 = false;
        public static void GetOS()
        {
            if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor == 1)
            {
                isXP = true;
            }
            else if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor == 2)
            {
                isXP64 = true;

            }
            else if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 0)
            {
                isVista = true;
            }
            else if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1)
            {
                isWin7 = true;
            }
            else if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 2)
            {
                isWin8 = true;
            }
            else if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 3)
            {
                isWin8p1 = true;
            }
            else if (Environment.OSVersion.Version.Major == 10 && Environment.OSVersion.Version.Minor == 0)
            {
                isWin10 = true;
            }
        }
        public static bool isHigherThenWin8()
        {
            if (isWin8 || isWin8p1 || isWin10)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
