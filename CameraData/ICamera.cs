using System;
using System.Collections.Generic;
using System.Text;
using SharpEngine_Core.EntityData;
using OpenTK;

namespace SharpEngine_Core.CameraData
{
    interface ICamera : IEntity
    {
        /// <summary>
        /// LookAt matrix of camera
        /// </summary>
        public Matrix4 LookAt { get; }

        void LoadMatrix();
        void BuildMatrix();
    }
}
