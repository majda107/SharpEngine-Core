using OpenTK;
using SharpEngine_Core.GameLib;
using System;

namespace SharpEngine_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow gw = new GameWindow(500, 500, new OpenTK.Graphics.GraphicsMode(32, 24, 0, 4), "Sharp engine");

            Game game = new Game(gw, 60);
            game.Run();
        }
    }
}
