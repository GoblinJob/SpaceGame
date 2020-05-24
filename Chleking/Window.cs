using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using SpaceGame.Core;
using SpaceGame.Render;
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


        EngineObject engineObject;
                
        public Window(int width, int hight, string title) : base(width, hight, GraphicsMode.Default, title)
        {
        }
        int id2;

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);

            Console.WriteLine(Width);

            Projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Width / (float)Height, 0.1f, 100.0f);

            engineObject = new EngineObject();
            engineObject.Model = RenderSystem.Instance.Distributor.CreateModel(vertices, @"C:\Users\Dalvent\Desktop\0\d9snjna-74a1c22e-85a7-4ac6-8083-11b95c0b24c4.jpg", engineObject);
            engineObject.Transform = new Transform();
            engineObject.Transform.coordination = new Vector3(0, 0, -3);
            engineObject.Transform.rotation = Quaternion.Identity;
            engineObject.Transform.scale = Vector3.Zero;
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //Console.WriteLine(engineObject.Transform.coordination);
            RenderSystem.Instance.Use();

            GL.BindVertexArray(id2);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            var key = Keyboard.GetState();

            if(key.IsKeyDown(Key.Z))
            {
                engineObject.Transform.rotation += new Quaternion(0.1f, 0, 0);
            }

            if (key.IsKeyDown(Key.A))
            {
                engineObject.Transform.coordination += new Vector3(0.1f, 0, 0);
            }

            if (key.IsKeyDown(Key.D))
            {
                engineObject.Transform.coordination += new Vector3(-0.1f, 0, 0);
            }


            if (key.IsKeyDown(Key.W))
            {
                engineObject.Transform.coordination += new Vector3(0, -0.1f, 0);
            }

            if (key.IsKeyDown(Key.S))
            {
                engineObject.Transform.coordination += new Vector3(0, 0.1f, 0);
            }


            if (key.IsKeyDown(Key.Q))
            {
                engineObject.Transform.coordination += new Vector3(0, 0, 0.1f);
            }

            if (key.IsKeyDown(Key.E))
            {
                engineObject.Transform.coordination += new Vector3(0, 0, -0.1f);
            }



            base.OnKeyDown(e);
        }
    }
}