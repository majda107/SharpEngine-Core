using SharpEngine_Core.Solids;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.PhysicsData
{
    class PhysicBody
    {
        public RigidBody RigidBody { get; set; }
        public List<IForce> Forces { get; private set; }
        public ASolid Solid { get; private set; }

        public PhysicBody(ASolid solid)
        {
            this.Forces = new List<IForce>();
            this.Solid = solid;
        }

        public void AddForce(IForce force)
        {
            this.Forces.Add(force);
        }

        public void UpdateForces()
        {
            foreach(IForce force in this.Forces)
            {
                force.UpdateForce(this.Solid);
            }
        }
    }
}
