using OpenTK;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.Processors
{
    class KeyboardProcessor : AKeyboardProcessor
    {
        public KeyboardProcessor(GameWindow gameWindow)
        {
            gameWindow.KeyDown += (o, e) => this.AddKey(e.Key);
            gameWindow.KeyUp += (o, e) => this.RemoveKey(e.Key);
        }
    }
}
