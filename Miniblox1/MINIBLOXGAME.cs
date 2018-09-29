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

namespace Miniblox
{
    public abstract class MINIBLOXGAME : GameWindow
    {
        public MINIBLOXGAME(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            Run();
        }

        // overrides

        protected override void OnLoad(EventArgs e)
        {
            MiniInitialize(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            Input.KeyUpdate();
            MiniUpdate(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            MiniRender(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            MiniClose(e);
            Dispose();
        }

        // virtual overrides

        protected virtual void MiniInitialize(EventArgs e = null)
        {
            if(e==null)
            {
                Console.WriteLine("protected virtual void MiniInitialize: no event arguements passed");
            } else
            {

            }
        }
        protected virtual void MiniUpdate(FrameEventArgs e = null)
        {
            if (e == null)
            {
                Console.WriteLine("protected virtual void MiniUpdate: no event arguements passed");
            }
            else
            {

            }
        }
        protected virtual void MiniRender(FrameEventArgs e = null)
        {
            if (e == null)
            {
                Console.WriteLine("protected virtual void MiniRender: no event arguements passed");
            }
            else
            {

            }
        }
        protected virtual void MiniClose(EventArgs e = null)
        {
            if (e == null)
            {
                Console.WriteLine("protected virtual void MiniClose: no event arguements passed");
            }
            else
            {

            }
        }
    }
}
