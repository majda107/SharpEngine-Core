﻿using OpenTK;
using SharpEngine_Core.SolidData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace SharpEngine_Core.ObjLoader
{
    static class ObjLoader
    {
        public static Solids.ASolid LoadObj(string pathToFolder, string fileName, Vector3 pos)
        {
            Material mat = null;
            VertexBuffer vb = new VertexBuffer();
            MaterialBuffer materialBuffer = null;

            List<Face3> faces = new List<Face3>();
            string[] lines = File.ReadAllLines(pathToFolder + "/" + fileName);

            foreach(string line in lines)
            {
                string[] split = line.Split(' ');
                switch (split[0])
                {
                    case "v":
                        vb.vertices.Add(new Vector3(float.Parse(split[1], CultureInfo.InvariantCulture), float.Parse(split[2], CultureInfo.InvariantCulture), float.Parse(split[3], CultureInfo.InvariantCulture)));
                        break;
                    case "vt":
                        vb.textures.Add(new Vector2(float.Parse(split[1], CultureInfo.InvariantCulture), float.Parse(split[2], CultureInfo.InvariantCulture)));
                        break;
                    case "vn":
                        vb.normals.Add(new Vector3(float.Parse(split[1], CultureInfo.InvariantCulture), float.Parse(split[2], CultureInfo.InvariantCulture), float.Parse(split[3], CultureInfo.InvariantCulture)));
                        break;
                    case "f":

                        Vector3[] faceVertices = new Vector3[split.Length - 1];
                        Vector2[] faceTextures = new Vector2[split.Length - 1];
                        Vector3[] faceNormals = new Vector3[split.Length - 1];

                        if (split[1].Contains("//"))
                        {
                            for (int i = 1; i < split.Length - 1; i++)
                            {
                                string[] index = split[i].Split(("//").ToCharArray());
                                faceVertices[i - 1] = vb.vertices[int.Parse(index[0]) - 1];
                                faceNormals[i - 1] = vb.normals[int.Parse(index[2]) - 1];
                            }
                        }
                        else
                        {
                            for (int i = 1; i < split.Length; i++)
                            {
                                string[] index = split[i].Split('/');
                                faceVertices[i - 1] = vb.vertices[int.Parse(index[0]) - 1];
                                if (index.Length > 0) faceTextures[i - 1] = vb.textures[int.Parse(index[1]) - 1];
                                if (index.Length > 1) faceNormals[i - 1] = vb.normals[int.Parse(index[2]) - 1];
                            }
                        }

                        faces.Add(new Face3(faceVertices, faceTextures, faceNormals, mat));
                        break;

                    case "mtllib":
                        materialBuffer = MtlLoader.LoadMaterial(pathToFolder, split[1]);
                        break;
                    case "usemtl":
                        if (materialBuffer != null)
                        {
                            mat = materialBuffer.materials.FirstOrDefault(t => t.name == split[1]);
                        }
                        break;
                }
            }

            return new Solids.Solid(faces.ToArray(), pos);
        }
    }
}
