using OpenTK;
using SharpEngine_Core.EventArgsData;
using SharpEngine_Core.Solids;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.PhysicsData
{
    class Force : IForce, IDisposable
    {
        public Vector3 Direction { get; private set; }
        public float Velocity { get; private set; }

        private bool _isActive;
        public bool IsActive { get => _isActive; set { _isActive = value; } }

        public Force(Vector3 direction, float velocity)
        {
            this.IsActive = true;
            this.Direction = direction;
            this.Velocity = velocity;
        }

        public void UpdateForce(ASolid solid)
        {
            if (_isActive)
            {
                solid.Pos += this.Direction * this.Velocity;

                ASolid targetSolid = solid.EntityManager.CheckCollisionsFor(solid);
                if (targetSolid != null)
                {
                    solid.FireOnCollision(new CollisionEventArgs(targetSolid, this));
                }
            }
            else this.Dispose();
        }

        public void Dispose()
        {
            // should dispose force here
        }
    }
}
