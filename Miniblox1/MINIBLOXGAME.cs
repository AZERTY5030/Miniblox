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
        private Color4 bg;

        public MINIBLOXGAME(int width, int height, string title, Color4 bgColor) : base(width, height, GraphicsMode.Default, title)
        {
            bg = bgColor;

            Console.WriteLine("game is being run");
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
            Console.WriteLine("starting");
        }
        protected virtual void MiniUpdate(FrameEventArgs e = null)
        {

        }
        protected virtual void MiniRender(FrameEventArgs e = null)
        {
            Gl.ClearColor(bg.R, bg.G, bg.B, bg.A);
            Console.WriteLine("CLEARCOLOR");
            Gl.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Console.WriteLine("CLEAR");

            SwapBuffers();
            Console.WriteLine("SWAPPED BUFFERS");
        }
        protected virtual void MiniClose(EventArgs e = null)
        {
            Console.WriteLine("exiting");
        }
        protected virtual Color4 ColorConstruct(float R, float G, float B, float A)
        {
            Color4 ret;

            ret.R = R;
            ret.G = G;
            ret.B = B;
            ret.A = A;

            return ret;
        }
        protected virtual float[] ColorDeConstruct(Color4 color)
        {
            float[] ret =
            {

            };

            ret[1] = color.R;
            ret[2] = color.G;
            ret[3] = color.B;
            ret[0] = color.A;

            return ret;
        }
    }
}
