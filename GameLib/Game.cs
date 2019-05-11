using OpenTK;
using OpenTK.Graphics.OpenGL;
using SharpEngine_Core.CameraData;
using SharpEngine_Core.EntityData;
using SharpEngine_Core.PhysicsData;
using SharpEngine_Core.Processors;
using SharpEngine_Core.Solids;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpEngine_Core.GameLib
{
    class Game
    {
        public EntityManager EntityManager { get; private set; }
        public GameWindow GW { get; }
        public float FrameRate { get; }

        public KeyboardProcessor KeyboardProcessor { get; private set; }
        public MouseProcessor MouseProcessor { get; private set; }



        private ASolid spider;
        private ACamera camera;

        public Game(GameWindow gameWindow, float frameRate)
        {
            this.camera = new FPVCamera(new Vector3(0, 0, 0), 1f);

            this.EntityManager = new EntityManager();

            spider = ObjLoader.ObjLoader.LoadObj(@"C:\Users\majda\source\repos\SharpEngine-Core\SharpEngine-Core\TestModels\Spider\", "spider.obj", new Vector3(-100, 0, 0), this.EntityManager);
            spider.PhysicBody.RigidBody = new RigidBody(10f, spider.PhysicBody);

            var spider2 = ObjLoader.ObjLoader.LoadObj(@"C:\Users\majda\source\repos\SharpEngine-Core\SharpEngine-Core\TestModels\Spider\", "spider.obj", new Vector3(200, 0, 0), this.EntityManager);
            spider2.PhysicBody.RigidBody = new RigidBody(10f, spider.PhysicBody);

            spider.OnCollision += (o, e) =>
            {
                e.Solid.Pos += new Vector3(200, 0, 0);
            };

            EntityManager.Add(spider);
            EntityManager.Add(spider2);

            this.GW = gameWindow;
            this.FrameRate = frameRate;

            this.KeyboardProcessor = new KeyboardProcessor(this.GW);
            this.MouseProcessor = new MouseProcessor(this.GW);
        }

        public void Run()
        {
            this.GW.CursorVisible = false;

            this.GW.UpdateFrame += UpdateFrame;
            this.GW.Resize += Resized;
            this.GW.Load += Loaded;

            this.GW.KeyPress += (o, e) =>
            {
                if(e.KeyChar == 'g') spider.Debug = (spider.Debug) ? false : true;
                if (e.KeyChar == 'o') spider.PhysicBody.AddForce(new Force(new Vector3(1, 0, 0), 1));
            };

            this.GW.Run(1 / this.FrameRate);
        }

        private void Resized(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, this.GW.Width, this.GW.Height);
        }

        private void CreatePerspectiveProjection(float angle)
        {
            GL.MatrixMode(MatrixMode.Projection);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(angle), (float)GW.Width / (float)GW.Height, 1.0f, 10000.0f);
            GL.LoadMatrix(ref perspective);
        }

        private void UpdateFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            CreatePerspectiveProjection(45f);

            this.camera.ProcessKeyboard(this.KeyboardProcessor);
            this.camera.ProcessMouse(this.MouseProcessor);
            this.camera.LoadMatrix();

            EntityManager.UpdateSolids();
            EntityManager.RenderVisible();

            GW.SwapBuffers();
        }

        private void Loaded(object sender, EventArgs e)
        {
            GL.ClearColor(0.8f, 0.0f, 0.0f, 0.0f);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.ColorMaterial);

            GL.Enable(EnableCap.Lighting);

            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 20.0f, 0.0f, -10.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 0.8f, 0.8f, 0.8f });
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.6f, 0.6f, 0.6f });

            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.Texture2D);

            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }
    }
}
