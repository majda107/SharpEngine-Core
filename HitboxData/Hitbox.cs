using OpenTK;
using SharpEngine_Core.SolidData;
using SharpEngine_Core.Solids;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.HitboxData
{
    class Hitbox : AHitbox
    {
        public Hitbox(Face3[] faces, ASolid parent)  : base(parent)
        {
            if(faces != null)
            {
                float left = faces[0].vertices[0].X;
                float right = faces[0].vertices[0].X;
                float top = faces[0].vertices[0].Y;
                float bottom = faces[0].vertices[0].Y;
                float close = faces[0].vertices[0].Z;
                float distant = faces[0].vertices[0].Z;

                foreach (Face3 face in faces)
                {
                    foreach (Vector3 vertex in face.vertices)
                    {
                        if (vertex.X > left) left = vertex.X;
                        if (vertex.X < right) right = vertex.X;
                        if (vertex.Y > top) top = vertex.Y;
                        if (vertex.Y < bottom) bottom = vertex.Y;
                        if (vertex.Z < close) close = vertex.Z;
                        if (vertex.Z > distant) distant = vertex.Z;
                    }
                }

                this.First = new Vector3(left, bottom, close);
                this.Second = new Vector3(right, top, distant);
            }
        }
    }
}
