using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using SpaceGame.Core;
using SpaceGame.Render;
using SpaceGame.Render.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpaceGame
{
    public class Window : GameWindow
    {
        public static Matrix4 Projection;


        public Window(int width, int hight, string title) : base(width, hight, GraphicsMode.Default, title)
        {
        }


        private Camera camera;

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

        private readonly float[] vertices2 = new float[] {
             // Позиции вершин  
            -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,
             0.5f, -0.5f, -0.5f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
            -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,

            0.5f, -0.5f, 0.0f, 1.0f, -1.0f,
            0.5f, 0.5f, 0.0f, 1.0f, 1.0f,
            0.0f, 0.0f, 1.0f, 0.0f, 1.0f,

            0.5f, 0.5f, 0.0f, 1.0f, -1.0f,
            -0.5f, 0.5f, 0.0f, 1.0f, 1.0f,
            0.0f, 0.0f, 1.0f, 0.0f, 1.0f,

            -0.5f, 0.5f, 0.0f, 1.0f, -1.0f,
            -0.5f, -0.5f, 0.0f, 1.0f, 1.0f,
            0.0f, 0.0f, 1.0f, 0.0f, 1.0f,

            -0.5f, -0.5f, 0.0f, 1.0f, -1.0f,
            0.5f, -0.5f, 0.0f, 1.0f, 1.0f,
            0.0f, 0.0f, 1.0f, 0.0f, 1.0f,
        };

        Vector2 lastPos;
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);
            CursorVisible = false;

            Texture.CreateTexture("goblin", @"..\..\Assets\goblin.jpg");
            Texture.CreateTexture("spaceBlue", @"..\..\Assets\spaceBlue.jpg");
            Texture.CreateTexture("meteor", @"..\..\Assets\meteor.jpg");
            Texture.CreateTexture("lava", @"..\..\Assets\lava.png");
            Texture.CreateTexture("space", @"..\..\Assets\space.png");
            Texture.CreateTexture("box", @"..\..\Assets\box.jpg");
            Texture.CreateTexture("betterGoblin", @"..\..\Assets\betterGoblin.png");
            Texture.CreateTexture("Gorinich", @"..\..\Assets\Gorinich.png");
            Texture.CreateTexture("moveIcon", @"..\..\Assets\moveIcon.png");
            Texture.CreateTexture("spaceSamir", @"..\..\Assets\spaceSamir.png");
            Texture.CreateTexture("realSamir", @"..\..\Assets\realSamir.jpg");
            Texture.CreateTexture("BrainSamir", @"..\..\Assets\BrainSamir.png");
            Texture.CreateTexture("CollSam", @"..\..\Assets\CollSam.png");
            Shader.CreateShader("0", @"..\..\Render\OpenGL\Shaders\Transform.vert", @"..\..\Render\OpenGL\Shaders\TextureOverlay.frag");
            Model.CreateModel("cube", vertices);
            
            camera = new Camera(90, 100, Height, Width);
            camera.Transform.rotation = Quaternion.Identity;
            //_ = new GameObject(new Transform(new Vector3(0, 0, -2f)), "cube", "goblin");
            //_ = new GameObject(new Transform(new Vector3(-0.5f, 0, -4f), new Quaternion(30, 120, 0)), "cube", "goblin");
            //_ = new GameObject(new Transform(new Vector3(-2.5f, 0, -4f), new Quaternion(30, 120, 0)), "cube", "goblin");
            //_ = new GameObject(new Transform(new Vector3(0.5f, 2.0f, -4f), new Quaternion(30, 120, 0)), "cube", "goblin");
            //_ = new GameObject(new Transform(new Vector3(-2.5f, 2.4f, -4f), new Quaternion(30, 120, 0)), "cube", "goblin");


            CreateRandomCoolCubes("cube", "spaceBlue", 50, -70, -60, 20);
            CreateRandomCoolCubes("cube", "lava", 50, -60, -50, 20);
            CreateRandomCoolCubes("cube", "goblin", 50, -50, -40, 20);
            CreateRandomCoolCubes("cube", "space", 50, -40, -30, 20);
            CreateRandomCoolCubes("cube", "CollSam", 50, -30, -20, 20);
            CreateRandomCoolCubes("cube", "Gorinich", 50, -20, -10, 20);
            CreateRandomCoolCubes("cube", "moveIcon", 50, -10, 0, 20);
            CreateRandomCoolCubes("cube", "spaceSamir", 50, 0, 10, 20);
            CreateRandomCoolCubes("cube", "realSamir", 50, 10, 20, 20);
            CreateRandomCoolCubes("cube", "BrainSamir", 50, 20, 30, 20);
            CreateRandomCoolCubes("cube", "meteor", 50, 30, 40, 20);
            CreateRandomCoolCubes("cube", "box", 50, 40, 50, 20);
            CreateRandomCoolCubes("cube", "goblin", 50, 50, 60, 20);
            CreateRandomCoolCubes("cube", "betterGoblin", 50, 60, 70, 20);

            foreach (var item in Texture.dictionaryOfTextures)
            {
                Console.WriteLine(item);
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            int color;
            if (DateTime.Now.Minute % 2 == 0)
            {
                color = (int)((float)DateTime.Now.Second / 60 * 255) + 20;
                color = Math.Min(color, 255);
            }
            else
            {
                color = 255 - ((int)((float)DateTime.Now.Second / 60 * 255) + 20);
                color = Math.Max(color, 0);
            }
            color = Math.Min(color, 255);
            Console.WriteLine(color);
            GL.ClearColor(Color.FromArgb(color, color, (int)((float)color * 0.75f)));
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

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            //if (Focused) // check to see if the window is focused  
            //{
            //    Mouse.SetPosition(X + Width / 2f, Y + Height / 2f);
            //}

            base.OnMouseMove(e);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            base.OnResize(e);
        }

        float speed = 90.0f;
        float sensitivity = 0.2f;
        float yaw = 90.0f;
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




        private GameObject[] CreateRandomCoolCubes(string modelName, string textureName, int count, int minSpawnCoordZ, int maxSpawnCoordZ, int maxSpawnCoordXY)
        {
            var random = new Random();
            var resault = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                var randomTransform = new Transform();

                randomTransform.position.X = (float)random.NextDouble() + random.Next(-maxSpawnCoordXY, maxSpawnCoordXY);
                randomTransform.position.Y = (float)random.NextDouble() + random.Next(-maxSpawnCoordXY, maxSpawnCoordXY);
                randomTransform.position.Z = (float)random.NextDouble() + random.Next(minSpawnCoordZ, maxSpawnCoordZ);

                randomTransform.rotation.X = (float)random.Next(0, 360);
                randomTransform.rotation.Y = (float)random.Next(0, 360);
                randomTransform.rotation.Z = (float)random.Next(0, 360);

                var randomScale = (float)(random.NextDouble() + 1);
                randomTransform.scale.X = randomScale;
                randomTransform.scale.Y = randomScale;
                randomTransform.scale.Z = randomScale;

                resault[i] = new GameObject(randomTransform, modelName, textureName);
            }
            return resault;
        }
    }
}