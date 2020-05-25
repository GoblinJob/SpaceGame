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

        public static Matrix4 Projection;

        Camera camera;
        EngineObject engineObject;
                
        public Window(int width, int hight, string title) : base(width, hight, GraphicsMode.Default, title)
        {
        }
        int id2;

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.DarkGray);
            GL.Enable(EnableCap.DepthTest);

            Texture.CreateTexture("stone", @"C:\Users\Dalvent\Desktop\0\d9snjna-74a1c22e-85a7-4ac6-8083-11b95c0b24c4.jpg");
            Shader.CreateShader("0", @"..\..\Render\OpenGL\Shaders\Transform.vert", @"..\..\Render\OpenGL\Shaders\TextureOverlay.frag");
            Model.CreateModel("cube", vertices);

            camera = new Camera(90, 100, Height, Width);
            engineObject = new EngineObject();
            engineObject.Model = new Render3D("cube", "stone", engineObject);
            engineObject.Transform = new Transform();
            engineObject.Transform.location = new Vector3(0, 0, -3);
            engineObject.Transform.rotation = Quaternion.Identity;
            base.OnLoad(e);
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

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            var key = Keyboard.GetState();

            if(key.IsKeyDown(Key.Z))
            {
                camera.Transform.rotation += new Quaternion(0.1f, 0, 0);
            }

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