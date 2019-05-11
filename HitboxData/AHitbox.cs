using OpenTK;
using OpenTK.Graphics.OpenGL;
using SharpEngine_Core.Solids;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.HitboxData
{
    abstract class AHitbox
    {
        public ASolid Parent { get; private set; }
        public AHitbox(ASolid parent)
        {
            this.Parent = parent;
        }

        /// <summary>
        /// Defines left - bottom - close coord of hitbox 
        /// </summary>
        public Vector3 First { get; protected set; }
        /// <summary>
        /// Defines right - top - distant coord of hitbox
        /// </summary>
        public Vector3 Second { get; protected set; }

        public void Render()
        {
            GL.Color4(0.3, 0.3, 0.7, 0.4);

            GL.Begin(PrimitiveType.Quads);

            //front
            GL.Vertex3(First.X, Second.Y, First.Z);
            GL.Vertex3(First.X, First.Y, First.Z);
            GL.Vertex3(Second.X, First.Y, First.Z);
            GL.Vertex3(Second.X, Second.Y, First.Z);

            //back
            GL.Vertex3(First.X, Second.Y, Second.Z);
            GL.Vertex3(First.X, First.Y, Second.Z);
            GL.Vertex3(Second.X, First.Y, Second.Z);
            GL.Vertex3(Second.X, Second.Y, Second.Z);

            //left
            GL.Vertex3(First.X, Second.Y, Second.Z);
            GL.Vertex3(First.X, First.Y, Second.Z);
            GL.Vertex3(First.X, First.Y, First.Z);
            GL.Vertex3(First.X, Second.Y, First.Z);

            //right
            GL.Vertex3(Second.X, Second.Y, Second.Z);
            GL.Vertex3(Second.X, First.Y, Second.Z);
            GL.Vertex3(Second.X, First.Y, First.Z);
            GL.Vertex3(Second.X, Second.Y, First.Z);

            //top
            GL.Vertex3(First.X, Second.Y, Second.Z);
            GL.Vertex3(First.X, Second.Y, First.Z);
            GL.Vertex3(Second.X, Second.Y, First.Z);
            GL.Vertex3(Second.X, Second.Y, Second.Z);

            //bottom
            GL.Vertex3(First.X, First.Y, Second.Z);
            GL.Vertex3(First.X, First.Y, First.Z);
            GL.Vertex3(Second.X, First.Y, First.Z);
            GL.Vertex3(Second.X, First.Y, Second.Z);

            GL.End();
        }
    }
}
