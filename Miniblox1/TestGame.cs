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
using OpenTK.Graphics.OpenGL4;
using ShaderType = OpenTK.Graphics.OpenGL4.ShaderType;
using System.IO;

// GAME EXAMPLE: EDIT Program.cs's value TestGame to change the current game.
// based off of MINIBLOXGAME9

namespace Miniblox
{
    public class TestGame : MINIBLOXGAME
    {
        // put game code here

        void RunGame()
        {

        }

        public TestGame(int width, int height, string title) : base(width, height, title, Color4.SkyBlue, true)
        {
            // add any code here

            // start the game
            RunGame();
        }

        // overrides

        protected override void MiniClose(EventArgs e = null)
        {
            base.MiniClose(e);
        }
        protected override void MiniRender(FrameEventArgs e = null)
        {
            base.MiniRender(e);
        }
        protected override void MiniInitialize(EventArgs e = null)
        {
            base.MiniInitialize(e);
        }
        protected override byte[] MiniUpdate(byte[] cKeys, FrameEventArgs e = null)
        {
            KeyMethod(null);

            return base.MiniUpdate(cKeys,e);
        }
        protected override byte[] KeyMethod(byte[] cKeys)
        {
            var KeyState = Keyboard.GetState();

            if (KeyState.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            return null;
        }
    }
}
