using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

// entry point

/// <summary>
/// PG9.2
/// </summary>

namespace Miniblox
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                new TestGame(1000, 600, "TESTGAME 1").Run(60);
            } catch
            {
                Console.WriteLine("exit error!");
            }
        }
    }
}
