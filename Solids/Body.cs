using OpenTK;
using SharpEngine_Core.RenderData;
using SharpEngine_Core.SolidData;
using SharpEngine_Core.HitboxData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.Solids
{
    class Body : IRenderableDebug
    {
        public Face3[] Faces;
        public AHitbox Hitbox;
        
        public ASolid Solid { get; private set; }

        public Body(ASolid solid)
        {
            this.Solid = solid;
            this.Faces = null;
            this.Hitbox = new Hitbox(this.Faces, this.Solid);
        }

        public void MoveVertices(Vector3 dev)
        {
            for(int i = 0; i < Faces.Length; i++)
            {
                for(int j = 0; j < Faces[i].vertices.Length; j++)
                {
                    Faces[i].vertices[j] += dev;
                }
            }
            this.Hitbox = new Hitbox(this.Faces, this.Solid);
        }

        public void Render(bool debug)
        {
            foreach(Face3 face in this.Faces)
            {
                face.Render();
            }

            if (debug) Hitbox.Render();
        }
    }
}
