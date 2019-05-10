using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Input;

namespace SharpEngine_Core.Processors
{
    class MouseProcessor : AMouseProcessor
    {
        public MouseProcessor(GameWindow gameWindow)
        {
            gameWindow.UpdateFrame += (o, e) =>
            {
                this.Update(Mouse.GetState());
            };
        }

        public override void Update(MouseState currentState)
        {
            this.Dev.X = currentState.X - this.PrevState.X;
            this.Dev.Y = currentState.Y - this.PrevState.Y;

            this.PrevState = currentState;
        }
    }
}
