using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zapper.Console.Enums
{
    [Flags]
    public enum SettingFlags
    {
        None = 0,
        SMS = 1,
        Push = 2,
        Biometric = 4,
        Camera = 8,
        Location = 16,
        NFC = 32,
        Vouchers = 64,
        Loyalty = 128
    }
}
