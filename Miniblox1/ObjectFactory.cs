﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Miniblox;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Graphics;
using OpenTK;

namespace ObjectService
{
    public class ObjectFactory
    {
        public static Vertex[] CreateSolidCube(float side, Color4 color)
        {
            side = side / 2f; // half side - and other half
            Vertex[] vertices =
            {
               new Vertex(new Vector4(-side, -side, -side, 1.0f),   color),
               new Vertex(new Vector4(-side, -side, side, 1.0f),    color),
               new Vertex(new Vector4(-side, side, -side, 1.0f),    color),
               new Vertex(new Vector4(-side, side, -side, 1.0f),    color),
               new Vertex(new Vector4(-side, -side, side, 1.0f),    color),
               new Vertex(new Vector4(-side, side, side, 1.0f),     color),

               new Vertex(new Vector4(side, -side, -side, 1.0f),    color),
               new Vertex(new Vector4(side, side, -side, 1.0f),     color),
               new Vertex(new Vector4(side, -side, side, 1.0f),     color),
               new Vertex(new Vector4(side, -side, side, 1.0f),     color),
               new Vertex(new Vector4(side, side, -side, 1.0f),     color),
               new Vertex(new Vector4(side, side, side, 1.0f),      color),

               new Vertex(new Vector4(-side, -side, -side, 1.0f),   color),
               new Vertex(new Vector4(side, -side, -side, 1.0f),    color),
               new Vertex(new Vector4(-side, -side, side, 1.0f),    color),
               new Vertex(new Vector4(-side, -side, side, 1.0f),    color),
               new Vertex(new Vector4(side, -side, -side, 1.0f),    color),
               new Vertex(new Vector4(side, -side, side, 1.0f),     color),

               new Vertex(new Vector4(-side, side, -side, 1.0f),    color),
               new Vertex(new Vector4(-side, side, side, 1.0f),     color),
               new Vertex(new Vector4(side, side, -side, 1.0f),     color),
               new Vertex(new Vector4(side, side, -side, 1.0f),     color),
               new Vertex(new Vector4(-side, side, side, 1.0f),     color),
               new Vertex(new Vector4(side, side, side, 1.0f),      color),

               new Vertex(new Vector4(-side, -side, -side, 1.0f),   color),
               new Vertex(new Vector4(-side, side, -side, 1.0f),    color),
               new Vertex(new Vector4(side, -side, -side, 1.0f),    color),
               new Vertex(new Vector4(side, -side, -side, 1.0f),    color),
               new Vertex(new Vector4(-side, side, -side, 1.0f),    color),
               new Vertex(new Vector4(side, side, -side, 1.0f),     color),

               new Vertex(new Vector4(-side, -side, side, 1.0f),    color),
               new Vertex(new Vector4(side, -side, side, 1.0f),     color),
               new Vertex(new Vector4(-side, side, side, 1.0f),     color),
               new Vertex(new Vector4(-side, side, side, 1.0f),     color),
               new Vertex(new Vector4(side, -side, side, 1.0f),     color),
               new Vertex(new Vector4(side, side, side, 1.0f),      color),
              };
            return vertices;
        }
    }
}
