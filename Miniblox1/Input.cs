using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;
using OpenTK;
using System.Runtime.InteropServices;

namespace Miniblox
{
    public class Input /// basic input class
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);

        // key update
        internal static byte[] KeyUpdate() /// returns all keys state
        {
            var keys = new byte[256];

            GetKeyboardState(keys);

            return keys;
        }
    }
}
