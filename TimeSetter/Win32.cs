using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TimeSetter
{
    public class Win32
    {
        [DllImport("Kernel32.dll")]
        public static extern bool SetSystemTime(ref SystemDate time);
        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SystemDate time);
        [DllImport("Kernel32.dll")]
        public static extern void GetSystemTime(ref SystemDate time);
        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(ref SystemDate time);  
    }
}
