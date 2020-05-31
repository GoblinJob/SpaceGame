using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using SpaceGame.Render;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpaceGame
{
    public class SpaceGameWindow : GameWindow
    {
        private Camera camera;
        private GameObject box;
        private GameObject light;

        Vector2 lastPos;
        private readonly float[] vertices = new float[] {
             // Позиции вершин  
            -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,  0.0f,  0.0f, -1.0f,
             0.5f, -0.5f, -0.5f,  1.0f, 0.0f,  0.0f,  0.0f, -1.0f, 
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,  0.0f,  0.0f, -1.0f, 
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,  0.0f,  0.0f, -1.0f, 
            -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,  0.0f,  0.0f, -1.0f, 
            -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,  0.0f,  0.0f, -1.0f, 

            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,  0.0f,  0.0f, 1.0f,
             0.5f, -0.5f,  0.5f,  1.0f, 0.0f,  0.0f,  0.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 1.0f,  0.0f,  0.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 1.0f,  0.0f,  0.0f, 1.0f,
            -0.5f,  0.5f,  0.5f,  0.0f, 1.0f,  0.0f,  0.0f, 1.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,  0.0f,  0.0f, 1.0f,

            -0.5f,  0.5f,  0.5f,  1.0f, 0.0f, -1.0f,  0.0f,  0.0f,
            -0.5f,  0.5f, -0.5f,  1.0f, 1.0f, -1.0f,  0.0f,  0.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f, -1.0f,  0.0f,  0.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f, -1.0f,  0.0f,  0.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f, -1.0f,  0.0f,  0.0f,
            -0.5f,  0.5f,  0.5f,  1.0f, 0.0f, -1.0f,  0.0f,  0.0f,

             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,  1.0f,  0.0f,  0.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,  1.0f,  0.0f,  0.0f,
             0.5f, -0.5f, -0.5f,  0.0f, 1.0f,  1.0f,  0.0f,  0.0f,
             0.5f, -0.5f, -0.5f,  0.0f, 1.0f,  1.0f,  0.0f,  0.0f,
             0.5f, -0.5f,  0.5f,  0.0f, 0.0f,  1.0f,  0.0f,  0.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,  1.0f,  0.0f,  0.0f,

            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,  0.0f, -1.0f,  0.0f,
             0.5f, -0.5f, -0.5f,  1.0f, 1.0f,  0.0f, -1.0f,  0.0f,
             0.5f, -0.5f,  0.5f,  1.0f, 0.0f,  0.0f, -1.0f,  0.0f,
             0.5f, -0.5f,  0.5f,  1.0f, 0.0f,  0.0f, -1.0f,  0.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,  0.0f, -1.0f,  0.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,  0.0f, -1.0f,  0.0f,

            -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,  0.0f,  1.0f,  0.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,  0.0f,  1.0f,  0.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,  0.0f,  1.0f,  0.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,  0.0f,  1.0f,  0.0f,
            -0.5f,  0.5f,  0.5f,  0.0f, 0.0f,  0.0f,  1.0f,  0.0f,
            -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,  0.0f,  1.0f,  0.0f
        };

        public SpaceGameWindow(int width, int hight, string title) : base(width, hight, GraphicsMode.Default, title)
        {
        }


        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);
            CursorVisible = false;

            ResurceManager.LoadTexture("box", 
                new Texture(), @"..\..\Assets\box.jpg");
            ResurceManager.LoadTexture("lava", 
                new Texture(), @"..\..\Assets\lava.png");

            ResurceManager.LoadVertexInfo("cube", 
                new VerticesInfo(new VerticesAttributeInfo[] {
                    new VerticesAttributeInfo("v_position", 3), 
                    new VerticesAttributeInfo("v_textureCoord", 2), 
                    new VerticesAttributeInfo("v_normal", 3)
                }), vertices);

            ResurceManager.LoadShader("lightSource",
                new LightSourceShader(ResurceManager.GetTexture("lava"), 
                new Vector3(1, 0.6471f, 0)), 
                @"..\..\Render\OpenGL\Shaders\Source\Vertex\transform.vert", 
                @"..\..\Render\OpenGL\Shaders\Source\Fragment\lightSource.frag");
            ResurceManager.LoadShader("lightTaker", 
                new LightTakerShader(ResurceManager.GetTexture("box"), 
                    (LightSourceShader)ResurceManager.GetShader("lightSource"),
                    new Vector3(0.4f, 0.4f, 0.4f)),
                @"..\..\Render\OpenGL\Shaders\Source\Vertex\transform.vert",
                @"..\..\Render\OpenGL\Shaders\Source\Fragment\lightTaker.frag");

            ResurceManager.LoadModel("WoodBox",
                new Model(), "cube", "lightTaker");
            ResurceManager.LoadModel("LavaBox",
                new Model(), "cube", "lightSource");

            camera = new Camera(90, 100, Height, Width);
            box = new GameObject(new Transform(new Vector3(0, 0f, -4f)), "WoodBox");
            light = new GameObject(new Transform(new Vector3(4, 2, -2f)), "LavaBox");
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            camera.ShowAllInView();
            
            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (!Focused) // check to see if the window is focused
            {
                return;
            }
            DoMouseMovement();
            DoKeyboardMovement((float)e.Time);

            base.OnUpdateFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            base.OnResize(e);
        }

        float speed = 9.0f;
        float sensitivity = 0.2f;
        float yaw = 0.0f;
        float pitch = 0;
        bool FirstMove = true;
        private void DoMouseMovement()
        {
            var mouseState = Mouse.GetCursorState();
            if (FirstMove)
            {
                lastPos = new Vector2(mouseState.X, mouseState.Y);
                FirstMove = false;
            }
            else
            {
                float deltaX = mouseState.X - lastPos.X;
                float deltaY = mouseState.Y - lastPos.Y;
                lastPos = new Vector2(mouseState.X, mouseState.Y);

                yaw += deltaX * sensitivity;
                if (pitch > 89.0f)
                {
                    pitch = 89.0f;
                }
                else if (pitch < -89.0f)
                {
                    pitch = -89.0f;
                }
                else
                {
                    pitch -= deltaY * sensitivity;
                }
                var newFront = new Vector3();
                newFront.X = (float)Math.Cos(MathHelper.DegreesToRadians(pitch)) * (float)Math.Cos(MathHelper.DegreesToRadians(yaw));
                newFront.Y = (float)Math.Sin(MathHelper.DegreesToRadians(pitch));
                newFront.Z = (float)Math.Cos(MathHelper.DegreesToRadians(pitch)) * (float)Math.Sin(MathHelper.DegreesToRadians(yaw));
                newFront = Vector3.Normalize(newFront);
                camera.Front = newFront;
                Mouse.SetPosition(lastPos.X, lastPos.Y);
            }
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            if (e.Value >= 45.0f)
            {
                camera.Fov += 1;
            }
            else if (e.Value <= 1.0f)
            {
                camera.Fov = 1;
            }
            else
            {
                camera.Fov -= e.DeltaPrecise;
            }

            base.OnMouseWheel(e);
        }

        private void DoKeyboardMovement(float deltaTime)
        {
            var input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Q))
            {
                 box.Transform.position += new Vector3(speed * deltaTime, 0, 0); //Forward 
            }

            if (input.IsKeyDown(Key.E))
            {
                box.Transform.position -= new Vector3(speed * deltaTime, 0, 0); //Forward 
            }

            if (input.IsKeyDown(Key.W))
            {
                camera.Transform.position += speed * camera.Front * deltaTime; //Forward 
            }

            if (input.IsKeyDown(Key.S))
            {
                camera.Transform.position -= speed * camera.Front * deltaTime;
            }

            if (input.IsKeyDown(Key.A))
            {

                camera.Transform.position -= Vector3.Normalize(Vector3.Cross(camera.Front, camera.Up)) * speed * deltaTime;
            }

            if (input.IsKeyDown(Key.D))
            {
                camera.Transform.position += Vector3.Normalize(Vector3.Cross(camera.Front, camera.Up)) * speed * deltaTime;
            }

            if (input.IsKeyDown(Key.Space))
            {
                camera.Transform.position += camera.Up * speed * deltaTime;
            }

            if (input.IsKeyDown(Key.ShiftLeft))
            {
                camera.Transform.position -= camera.Up * speed * deltaTime;
            }
        }
    }
}