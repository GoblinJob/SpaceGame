using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using SpaceGame.Core;
using SpaceGame.Render;
using SpaceGame.Render.OpenGL;
using System;

namespace SpaceGame
{
    public class Window : GameWindow
    {
        private readonly float[] vertices = new float[] {
             // Позиции вершин  
    -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,
     0.5f, -0.5f, -0.5f,  1.0f, 0.0f,
     0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
     0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
    -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
    -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,

    -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
     0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
     0.5f,  0.5f,  0.5f,  1.0f, 1.0f,
     0.5f,  0.5f,  0.5f,  1.0f, 1.0f,
    -0.5f,  0.5f,  0.5f,  0.0f, 1.0f,
    -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,

    -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
    -0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
    -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
    -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
    -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
    -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,

     0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
     0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
     0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
     0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
     0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
     0.5f,  0.5f,  0.5f,  1.0f, 0.0f,

    -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
     0.5f, -0.5f, -0.5f,  1.0f, 1.0f,
     0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
     0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
    -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
    -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,

    -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
     0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
     0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
     0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
    -0.5f,  0.5f,  0.5f,  0.0f, 0.0f,
    -0.5f,  0.5f, -0.5f,  0.0f, 1.0f
        };

        private EngineObject[] CreateRandomCoolCubes(string textureName, string modelName, int count, int minSpawnCoordZ, int maxSpawnCoordZ)
        {
            var random = new Random();
            var resault = new EngineObject[count];
            for (int i = 0; i < count; i++)
            {
                var randomTransform = new Transform();

                randomTransform.location.X = (float)random.NextDouble() + random.Next(-50, 50);
                randomTransform.location.Y = (float)random.NextDouble() + random.Next(-50, 50);
                randomTransform.location.Z = (float)random.NextDouble() + random.Next(minSpawnCoordZ, maxSpawnCoordZ);

                randomTransform.rotation.X = (float)random.Next(0, 360);
                randomTransform.rotation.Y = (float)random.Next(0, 360);
                randomTransform.rotation.Z = (float)random.Next(0, 360);

                var randomScale = (float)(random.NextDouble() + 1);
                randomTransform.scale.X = randomScale;
                randomTransform.scale.Y = randomScale;
                randomTransform.scale.Z = randomScale;

                resault[i] = new EngineObject();
                resault[i].Transform = randomTransform;
                resault[i].Model = new Render3D(modelName, textureName, resault[i]);
            }
            return resault;
        }

        public static Matrix4 Projection;

        Camera camera;
        EngineObject[] engineObjects;

        public Window(int width, int hight, string title) : base(width, hight, GraphicsMode.Default, title)
        {
        }
        int id2;

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);

            Texture.CreateTexture("lava", @"..\..\Assets\space.png");
            Texture.CreateTexture("stone", @"..\..\Assets\spaceBlue.jpg");
            Shader.CreateShader("0", @"..\..\Render\OpenGL\Shaders\Transform.vert", @"..\..\Render\OpenGL\Shaders\TextureOverlay.frag");
            Model.CreateModel("cube", vertices);

            camera = new Camera(170, 400, Height, Width);
            //engineObjects = CreateRandomCoolCubes("lava", "cube", 3000, -400, 0);
            var engineObject = new EngineObject();
            engineObject.Transform = new Transform();
            engineObject.Transform.scale = new Vector3(800, 800, 800);
            engineObject.Model = new Render3D("cube", "stone", engineObject);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //Console.WriteLine(engineObject.Transform.coordination);

            GL.BindVertexArray(id2);

            camera.ShowAllInView();

            SwapBuffers();
            base.OnRenderFrame(e);
        }


        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            base.OnResize(e);
        }
        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            var key = Keyboard.GetState();

            if (key.IsKeyDown(Key.A))
            {
                camera.Transform.location += new Vector3(0.1f, 0, 0);
            }

            if (key.IsKeyDown(Key.D))
            {
                camera.Transform.location += new Vector3(-0.1f, 0, 0);
            }


            if (key.IsKeyDown(Key.W))
            {
                camera.Transform.location += new Vector3(0, -0.1f, 0);
            }

            if (key.IsKeyDown(Key.S))
            {
                camera.Transform.location += new Vector3(0, 0.1f, 0);
            }


            if (key.IsKeyDown(Key.Q))
            {
                camera.Transform.location += new Vector3(0, 0, 0.1f);
            }

            if (key.IsKeyDown(Key.E))
            {
                camera.Transform.location += new Vector3(0, 0, -0.1f);
            }



            base.OnKeyDown(e);
        }
    }
}