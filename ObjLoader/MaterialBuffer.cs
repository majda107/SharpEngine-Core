using SharpEngine_Core.SolidData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.ObjLoader
{
    class MaterialBuffer
    {
        public List<Material> materials { get; set; }
        public MaterialBuffer()
        {
            this.materials = new List<Material>();
        }

        public void Add(Material mat)
        {
            this.materials.Add(mat);
        }
    }
}
