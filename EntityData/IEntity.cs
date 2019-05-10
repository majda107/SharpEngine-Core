using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;

namespace SharpEngine_Core.EntityData
{
    interface IEntity
    {
        /// <summary>
        /// Position of entity
        /// </summary>
        public Vector3 Pos { get; set; }

        /// <summary>
        /// Roll angle of entity
        /// </summary>
        public float Roll { get; set; }

        /// <summary>
        /// Pitch angle of entity
        /// </summary>
        public float Pitch { get; set; }

        /// <summary>
        /// Yaw angle of entity
        /// </summary>
        public float Yaw { get; set; }
    }
}
