using System;
using System.Collections.Generic;
using System.Text;
using SharpEngine_Core.DebugData;
using SharpEngine_Core.EntityData;
using SharpEngine_Core.RenderData;
using OpenTK;
using SharpEngine_Core.PhysicsData;
using SharpEngine_Core.EventArgsData;

namespace SharpEngine_Core.Solids
{
    abstract class ASolid : IEntity, IRenderable, IDebuggable
    {
        public delegate void CollisionEventHandler(object sender, CollisionEventArgs eventArgs);
        public event CollisionEventHandler OnCollision;

        public EntityManager EntityManager { get; private set; }
        public ASolid(EntityManager entityManager)
        {
            this.PhysicBody = new PhysicBody(this);
            this.Body = new Body(this);

            this.EntityManager = entityManager;
        }

        public Body Body { get; protected set; }
        public PhysicBody PhysicBody { get; protected set; }

        private Vector3 _pos;
        public Vector3 Pos { get => _pos; set {
                if(value != _pos)
                {
                    this.Body.MoveVertices(value - _pos);
                    _pos = value;
                }
            } }

        public float Roll { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Pitch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Yaw { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private bool _debug;
        public bool Debug { get => _debug; set { _debug = value;  } }

        public void Render()
        {
            Body.Render(this.Debug);
        }

        public bool CheckCollide(ASolid solid)
        {
            if ((this.Body.Hitbox.Second.X < solid.Body.Hitbox.First.X && this.Body.Hitbox.First.X > solid.Body.Hitbox.Second.X) &&
                (this.Body.Hitbox.Second.Y > solid.Body.Hitbox.First.Y && this.Body.Hitbox.First.Y < solid.Body.Hitbox.Second.Y) &&
                (this.Body.Hitbox.Second.Z > solid.Body.Hitbox.First.Z && this.Body.Hitbox.First.Z < solid.Body.Hitbox.Second.Z))
            {
                return true;
            }
            return false;
        }

        public void FireOnCollision(CollisionEventArgs collisionEventArgs)
        {
            if(this.OnCollision != null)
            {
                this.OnCollision(this, collisionEventArgs);
            }
        }
    }
}
