using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

// entry point

namespace Miniblox
{
    class Program
    {

        static void Main(string[] args)
        {
            using (Toolkit.Init())
            {
                new TestGame(1200, 600, "Miniblox Game Engine");
            }

        }
    }
}
