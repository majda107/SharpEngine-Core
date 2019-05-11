using OpenTK;
using SharpEngine_Core.EntityData;
using SharpEngine_Core.SolidData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.Solids
{
    class Solid : ASolid
    {
        public Solid(Face3[] faces, Vector3 pos, EntityManager em) : base(em)
        {
            this.Body.Faces = faces;
            this.Pos = pos;
        }
    }
}
