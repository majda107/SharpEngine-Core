using System;
using System.Collections.Generic;
using System.Text;
using SharpEngine_Core.DebugData;
using SharpEngine_Core.EntityData;
using SharpEngine_Core.RenderData;
using OpenTK;
using SharpEngine_Core.PhysicsData;

namespace SharpEngine_Core.Solids
{
    abstract class ASolid : IEntity, IRenderable, IDebuggable
    {
        public ASolid()
        {
            this.Body = new Body();
        }

        public Body Body { get; protected set; }
        public PhysicBody PhysicBody { get; protected set; }

        private Vector3 _pos;
        public Vector3 Pos { get => _pos; set {
                if(value != _pos)
                {
                    Body.MoveVertices(value - _pos);
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
    }
}
