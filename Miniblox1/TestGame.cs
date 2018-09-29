using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using System.Drawing;

// GAME EXAMPLE: EDIT Program.cs's value TestGame to change the current game.

namespace Miniblox
{
    public class TestGame : MINIBLOXGAME
    {
        public TestGame(int width, int height, string title) : base(width, height, title)
        {

        }

        // overrides

        protected override void MiniClose(EventArgs e = null)
        {
            base.MiniClose(e);
        }
        protected override void MiniRender(FrameEventArgs e = null)
        {
            base.MiniRender(e);

            Gl.Clear(ClearBufferMask.ColorBufferBit);
            Gl.ClearColor(0, 0, 255, 0);



            Gl.Flush();
            SwapBuffers();
        }
        protected override void MiniInitialize(EventArgs e = null)
        {
            base.MiniInitialize(e);
        }
        protected override void MiniUpdate(FrameEventArgs e = null)
        {
            base.MiniUpdate(e);
        }
    }
}
