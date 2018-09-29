using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using System.Drawing;

/// <summary>
/// MINIBLOXGAME9.2
/// </summary>

namespace Miniblox
{
    public abstract class MINIBLOXGAME : GameWindow
    {
        private Color4 bg;
        private bool uII;
        private byte[] cKeys;
        private bool useDisposeB;

        public MINIBLOXGAME(int width, int height, string title, Color4 bgColor, bool useIndependantInputs = false, bool useDispose = false)  : base(width, height, GraphicsMode.Default, title, GameWindowFlags.Default, DisplayDevice.Default, 4, 0, GraphicsContextFlags.ForwardCompatible)
        {
            bg = bgColor;
            useDisposeB = useDispose;

            uII = useIndependantInputs;

            Console.WriteLine("game is being run");
            Run();
        }

        // overrides

        protected override void OnLoad(EventArgs e)
        {
            CursorVisible = true;
            MiniInitialize(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if(uII == false)
            {
                cKeys = Input.ByteKeyUpdate();
            } else
            {
                KeyMethod(cKeys);
            }
            
            MiniUpdate(cKeys, e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            MiniRender(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            MiniClose(e);
            if (useDisposeB == true)
            {
                Dispose();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            base.OnResize(e);
        }

        protected virtual byte[] KeyMethod(byte[] cKeys) /// OVERRIDE WHEN UII = TRUE
        {
            return cKeys;
        }

        // virtual overrides

        protected virtual void MiniInitialize(EventArgs e = null)
        {
            Console.WriteLine("starting");
        }
        protected virtual byte[] MiniUpdate(byte[] Keys, FrameEventArgs e = null)
        {
            return Keys;
        }
        protected virtual void MiniRender(FrameEventArgs e = null)
        {
            GL.ClearColor(bg.R, bg.G, bg.B, bg.A);
            Console.WriteLine("CLEARCOLOR");
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
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
