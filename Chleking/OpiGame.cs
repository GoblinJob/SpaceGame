using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Chleking
{
    // Объекта буфера вершин.
    // Массив буфера вершин
    // Маска буффера.


    class OpiGame : GameWindow
    {
        Triangle triangle;
        Shader shader;
        // Id объекты буфера вершин.
        int vertexBufferId;
        // Id объекта массива вершин.
        int vertexArrayId;

        /// <summary>
        /// Координаты вершин треугольника.
        /// </summary>
        float[] vertices = {
            -0.5f, -0.5f, 0.0f,  //Bottom-left vertex
            0.5f, -0.5f, 0.0f,   //Bottom-right vertex
            0.0f,  0.5f, 0.0f    //Top vertex
        };

        /// <summary>
        /// </summary>
        /// <param name="width">Ширина создоваемого окна.</param>
        /// <param name="height">Высота создоваемого окна.</param>
        /// <param name="title">Название создоваемого окна.</param>
        public OpiGame(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            shader = new Shader("../../Shaders/shader.vert", "../../Shaders/shader.frag");
            triangle = new Triangle(shader, vertices);
        }

        protected override void OnLoad(EventArgs e)
        {
            // Назначение цвета заднего фона.
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            triangle.Load();

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // Очистка цветовой маски буффера.
            // Каждый фрейм выставляется цвет выставленный в ClearColor.
            GL.Clear(ClearBufferMask.ColorBufferBit);

            triangle.Render();

            // Смена буффера для двойной буфферизации.
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // Сохраняем нажатую пользователем кнопку.
            KeyboardState input = Keyboard.GetState();
            
            // Если нажата кнопка ESC, выход из программы.
            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            // Изменяет размер отображаемой области.
            GL.Viewport(0, 0, Width, Height);

            base.OnResize(e);
        }
        protected override void OnUnload(EventArgs e)
        {
            shader.Dispose();
            // ???????????
            // Ставит выделенную пользователем память для массива буффера в NULL.
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            // Удаление выделенного пользователем буффера по id.
            GL.DeleteBuffer(vertexBufferId);

            base.OnUnload(e);
        }
    }
}
