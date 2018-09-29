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
            MiniInitialize();
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            Input.KeyUpdate();
            MiniUpdate();
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            MiniRender();
        }
        protected override void OnClosed(EventArgs e)
        {
            MiniClose();
            Dispose();
        }

        // virtual overrides

        protected virtual void MiniInitialize(EventArgs e = null)
        {
            if(e==null)
            {
                Console.WriteLine("no event arguements passed");
            } else
            {

            }
        }
        protected virtual void MiniUpdate(FrameEventArgs e = null)
        {
            if (e == null)
            {
                Console.WriteLine("no event arguements passed");
            }
            else
            {

            }
        }
        protected virtual void MiniRender(FrameEventArgs e = null)
        {
            if (e == null)
            {
                Console.WriteLine("no event arguements passed");
            }
            else
            {

            }
        }
        protected virtual void MiniClose(EventArgs e = null)
        {

        }
    }
}
