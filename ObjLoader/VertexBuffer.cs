using OpenTK;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.ObjLoader
{
    class VertexBuffer
    {
        public List<Vector3> vertices;
        public List<Vector2> textures;
        public List<Vector3> normals;
        public VertexBuffer()
        {
            this.vertices = new List<Vector3>();
            this.textures = new List<Vector2>();
            this.normals = new List<Vector3>();
        }
    }
}
