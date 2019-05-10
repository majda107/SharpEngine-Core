using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Input;
using SharpEngine_Core.Processors;

namespace SharpEngine_Core.CameraData
{
    class FPVCamera : ACamera
    {
        public float Sensitivity { get; set; }
        public FPVCamera(Vector3 pos, float sensitivity)
        {
            this.Pos = pos;
            this.Sensitivity = sensitivity;
        }

        public override void ProcessKeyboard(AKeyboardProcessor keyboardProcessor)
        {
            Vector3 toMove = new Vector3(0, 0, 0);
            foreach (Key key in keyboardProcessor.KeysDown)
            {
                switch (key)
                {
                    case Key.W:
                        toMove.Z += 1;
                        break;
                    case Key.S:
                        toMove.Z -= 1;
                        break;
                    case Key.A:
                        toMove.X += 1;
                        break;
                    case Key.D:
                        toMove.X -= 1;
                        break;
                    case Key.Space:
                        toMove.Y += 1;
                        break;
                    case Key.ShiftLeft:
                        toMove.Y -= 1;
                        break;
                }
            }

            this.Pos += new Vector3(0.0f, toMove.Y, 0.0f); // sets Y position of the camera
            this.Pos += new Vector3((float)(toMove.Z * Math.Cos(Yaw + MathHelper.DegreesToRadians(90))), 0.0f, (float)(toMove.Z * Math.Sin(Yaw + MathHelper.DegreesToRadians(90))));
            this.Pos += new Vector3((float)(toMove.X * Math.Cos(Yaw)), 0.0f, (float)(toMove.X * Math.Sin(Yaw)));
        }

        public override void ProcessMouse(AMouseProcessor mouseProcessor)
        {
            this.Yaw += (float)mouseProcessor.Dev.X / 400f * Sensitivity;
            this.Pitch += (float)mouseProcessor.Dev.Y / 400f * Sensitivity;
        }
    }
}
