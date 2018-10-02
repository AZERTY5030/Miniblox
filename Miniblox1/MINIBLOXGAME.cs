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
using System.IO;
using System.Diagnostics;
using static Miniblox.MINIBLOXGAME;
using static Miniblox.RenderObject;
using ObjectService;
using VSFProtect;
using Discord;
using Microsoft.CSharp;

/// <summary>
/// MINIBLOXGAME10
/// </summary>

namespace Miniblox
{
    
    public struct Vertex
    {
        public const int Size = (4 + 4) * 4; // size of struct in bytes

        private readonly Vector4 _position;
        private readonly Color4 _color;

        public Vertex(Vector4 position, Color4 color)
        {
            _position = position;
            _color = color;
        }
    }
    public class PhysicObject
    {
        private bool _initialized;

        RenderObject RenderObject;
        public PhysicObject()
        {
            _initialized = true;
        }
    }
    public class RenderObject : IDisposable
    {
        private bool _initialized;
        private readonly int _vertexArray;
        private readonly int _buffer;
        private readonly int _verticeCount;
        public RenderObject(Vertex[] vertices)
        {
            _verticeCount = vertices.Length;

            _vertexArray = GL.GenVertexArray();
            _buffer = GL.GenBuffer();

            // RENDERING CODE!
            GL.BindVertexArray(_vertexArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _buffer);

            GL.NamedBufferStorage(
                _buffer,
                Vertex.Size * vertices.Length,        // the size needed by this buffer
                vertices,                           // data to initialize with
                BufferStorageFlags.MapWriteBit
            );    // at this point we will only write to the buffer

            GL.VertexArrayAttribBinding(_vertexArray, 0, 0);
            GL.EnableVertexArrayAttrib(_vertexArray, 0);
            GL.VertexArrayAttribFormat(
                _vertexArray,
                0,                      // attribute index, from the shader location = 0
                4,                      // size of attribute, vec4
                VertexAttribType.Float, // contains floats
                false,                  // does not need to be normalized as it is already, floats ignore this flag anyway
                0
            );                     // relative offset, first item

            GL.VertexArrayAttribBinding(_vertexArray, 1, 0);
            GL.EnableVertexArrayAttrib(_vertexArray, 1);
            GL.VertexArrayAttribFormat(
                _vertexArray,
                1,                      // attribute index, from the shader location = 1
                4,                      // size of attribute, vec4
                VertexAttribType.Float, // contains floats
                false,                  // does not need to be normalized as it is already, floats ignore this flag anyway
            16);                     // relative offset after a vec4

            GL.VertexArrayVertexBuffer(_vertexArray, 0, _buffer, IntPtr.Zero, Vertex.Size);


            GL.BindVertexArray(_vertexArray);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);


            _initialized = true;
        }
        public void Render()
        {
            GL.BindVertexArray(_vertexArray);
            GL.DrawArrays(PrimitiveType.Triangles, 0, _verticeCount);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_initialized)
                {
                    GL.DeleteVertexArray(_vertexArray);
                    GL.DeleteBuffer(_buffer);
                    _initialized = false;
                }
            }
        }
    }

    public abstract class MINIBLOXGAME : GameWindow
    {
        // variables

        private Color4 bg;
        private bool uII;
        private byte[] cKeys;
        private bool useDisposeB;
        private Color4 blueViolet;
        private Func<int> compileShaders;
        private bool useIndependantInputs;

        // default functions

        private int CompileShader(ShaderType type, string path)
        {
            Debug.WriteLine($"Creating Shader, Path:" + path + ". Encrypted: " + File.ReadAllText(path));
            Debug.WriteLine($"Decrypted:" + StringCipher.Decrypt(File.ReadAllText(path), "VSFProtectM"));

            string EnCode = StringCipher.Decrypt(File.ReadAllText(path), "VSFProtectM");

            var shader = GL.CreateShader(type);
            var src = EnCode;
            GL.ShaderSource(shader, src);
            GL.CompileShader(shader);
            var info = GL.GetShaderInfoLog(shader);
            if (!string.IsNullOrWhiteSpace(info))
                Debug.WriteLine($"GL.CompileShader [{type}] had info log: {info}");
            return shader;
        }

        private int CreateProgram()
        {
            var program = GL.CreateProgram();
            var shaders = new List<int>();
            shaders.Add(CompileShader(ShaderType.VertexShader, @"shader\VertShader.VSF"));
            shaders.Add(CompileShader(ShaderType.FragmentShader, @"shader\FragShader.VSF"));

            foreach (var shader in shaders)
                GL.AttachShader(program, shader);
            GL.LinkProgram(program);
            var info = GL.GetProgramInfoLog(program);
            if (!string.IsNullOrWhiteSpace(info))
                Debug.WriteLine($"GL.LinkProgram had info log: {info}");

            foreach (var shader in shaders)
            {
                GL.DetachShader(program, shader);
                GL.DeleteShader(shader);
            }
            return program;
        }

        public MINIBLOXGAME(int width, int height, string title, Color4 bgColor, bool useIndependantInputs = false, bool useDispose = false)  : base(width, height, GraphicsMode.Default, title, GameWindowFlags.Default, DisplayDevice.Default, 4, 0, GraphicsContextFlags.ForwardCompatible)
        {
            bg = bgColor;
            useDisposeB = useDispose;

            uII = useIndependantInputs;

            

            Console.WriteLine("game is being run");
            Run();
        }

        protected MINIBLOXGAME(int width, int height, string title, Color4 blueViolet, Func<int> compileShaders, bool useIndependantInputs)
        {
            Width = width;
            Height = height;
            Title = title;
            this.blueViolet = blueViolet;
            this.compileShaders = compileShaders;
            this.useIndependantInputs = useIndependantInputs;
        }

        // variables

        private int _program;
        private int _vertexArray;

        // overrides

        public List<RenderObject> renderObjects = new List<RenderObject>();

        protected override void OnLoad(EventArgs e)
        {
            Vertex[] vertices =
            {
              new Vertex(new Vector4(-0.25f, 0.25f, 0.5f, 1-0f), Color4.HotPink),
              new Vertex(new Vector4( 0.0f, -0.25f, 0.5f, 1-0f), Color4.HotPink),
              new Vertex(new Vector4( 0.25f, 0.25f, 0.5f, 1-0f), Color4.HotPink),
             };
            renderObjects.Add(new RenderObject(vertices));

            vertices = ObjectFactory.CreateSolidCube(0.2f, Color4.Gray);

            renderObjects.Add(new RenderObject(vertices));

            CursorVisible = true;

            _program = CreateProgram();
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);

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
            GL.ClearColor(bg.R, bg.G, bg.B, bg.A);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(_program);
            foreach (var renderObject in renderObjects)
                renderObject.Render();

            SwapBuffers();

            MiniRender(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            Debug.WriteLine("Exit called");
            foreach (var obj in renderObjects)
                obj.Dispose();
            GL.DeleteProgram(_program);
            MiniClose(e);
            if (useDisposeB == true)
            {
                Dispose();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            // GL.Viewport(0, 0, Width, Height);

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
