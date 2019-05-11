using SharpEngine_Core.Solids;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.PhysicsData
{
    interface IForce
    {
        public bool IsActive { get; set; }
        void UpdateForce(ASolid solid);
    }
}
