using System;
using System.Collections.Generic;
using System.Text;
using SharpEngine_Core.Processors;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using SharpEngine_Core.EntityData;

namespace SharpEngine_Core.CameraData
{
    abstract class ACamera : ICamera
    {
        public ACamera()
        {
            this._angles = new Vector3(0, 0, 0);
            this.BuildMatrix();
        }

        private Matrix4 _lookAt;
        public Matrix4 LookAt => _lookAt;

        private Vector3 _pos;
        public Vector3 Pos { get => _pos; set {
                if(_pos != value)
                {
                    _pos += value - _pos;
                    this.BuildMatrix();
                }
            } }

        public Vector3 _angles;
        public float Roll { get => _angles.X; set { _angles.X = value; BuildMatrix(); } }
        public float Pitch { get => _angles.Y; set { _angles.Y = value; BuildMatrix(); } }
        public float Yaw { get => _angles.Z; set { _angles.Z = value; BuildMatrix(); } }

        public void LoadMatrix()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref this._lookAt);
        }

        public void BuildMatrix()
        {
            this._lookAt = Matrix4.LookAt(this.Pos, new Vector3(this.Pos.X, this.Pos.Y, this.Pos.Z + 1), Vector3.UnitY);
            //this._lookAt *= Matrix4.CreateRotationZ(Roll);
            this._lookAt *= Matrix4.CreateRotationY(Yaw);
            this._lookAt *= Matrix4.CreateRotationX(Pitch);
        }

        public abstract void ProcessMouse(AMouseProcessor processor);
        public abstract void ProcessKeyboard(AKeyboardProcessor processor);
    }
}
