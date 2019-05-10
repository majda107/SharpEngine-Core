using OpenTK.Input;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.Processors
{
    abstract class AMouseProcessor
    {
        public MouseState PrevState { get; set; }
        public Vector2 Dev;

        public abstract void Update(MouseState currentState);
    }
}
