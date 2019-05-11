using SharpEngine_Core.Solids;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.PhysicsData
{
    class RigidBody
    {
        public float Weight { get; private set; }
        public PhysicBody PhysicBody { get; private set; }
        public RigidBody(float weight, PhysicBody physicBody)
        {
            this.PhysicBody = physicBody;
            this.Weight = weight;

            this.PhysicBody.Solid.OnCollision += (o, e) =>
            {
                ASolid sender = o as ASolid;

                if(e.Solid.PhysicBody.RigidBody != null) e.Force.IsActive = false;
            };
        }
    }
}
