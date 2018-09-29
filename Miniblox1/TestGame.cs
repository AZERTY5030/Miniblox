using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;

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
            base.MiniClose();
        }
        protected override void MiniRender(EventArgs e = null)
        {
            base.MiniRender();

            Gl.Clear(ClearBufferMask.ColorBufferBit);
            Gl.ClearColor(0, 0, 255, 0);



            Gl.Flush();
            
        }
        protected override void MiniInitialize(EventArgs e = null)
        {
            base.MiniInitialize();
        }
        protected override void MiniUpdate(EventArgs e = null)
        {
            base.MiniUpdate();
        }
    }
}
