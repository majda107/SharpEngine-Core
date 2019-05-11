using SharpEngine_Core.PhysicsData;
using SharpEngine_Core.Solids;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.EventArgsData
{
    class CollisionEventArgs : EventArgs
    {
        public ASolid Solid { get; private set; }
        public IForce Force { get; private set; }
        public CollisionEventArgs(ASolid solid, IForce force)
        {
            this.Solid = solid;
            this.Force = force;
        }
    }
}
