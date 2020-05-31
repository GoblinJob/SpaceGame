using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    /// <summary>
    /// Шейдер загружаймый в OpenGL.
    /// </summary>
    public abstract class Shader
    {
        public int Id { get; private set; }
        private RenderEntityState state = new RenderEntityState();
        public Shader()
        {
            
        }

        public virtual void Load(StreamReader vertexShaderFile, StreamReader fragmentShaderFile)
        {
            state.Load();

            Id = GL.CreateProgram();

            var vertexShaderId = CompileShaderFromFile(vertexShaderFile, ShaderType.VertexShader);
            ConsoleLogShaderInfo(vertexShaderId);
            GL.AttachShader(Id, vertexShaderId);

            var fragmentShader = CompileShaderFromFile(fragmentShaderFile, ShaderType.FragmentShader);
            ConsoleLogShaderInfo(fragmentShader);
            GL.AttachShader(Id, fragmentShader);

            GL.LinkProgram(Id);
            GL.ValidateProgram(Id);

            GL.UseProgram(Id);

            DetachDeleteShader(vertexShaderId);
            DetachDeleteShader(fragmentShader);
        }


        /// <summary>
        /// Привязка шейдера для использования OpenGL.
        /// </summary>
        public virtual void Use(Transform objectTransorm, Camera viewer)
        {
            GL.UseProgram(Id);
        }


        public void Unload()
        {
            state.Unload();

            GL.DeleteProgram(Id);
        }

        /// <summary>
        /// Установка значения uniform переменной в шейдере по имени. 
        /// </summary>
        /// <param name="name">Имя переменной</param>
        /// <param name="value">Устонавливаемое значение</param>
        protected void SetValue(string name, bool value)
        {
            var uniformLocation = GL.GetUniformLocation(Id, name);
            GL.Uniform1(uniformLocation, value ? 1 : 0);
        }


        /// <summary>
        /// Установка значения uniform переменной в шейдере по имени. 
        /// </summary>
        /// <param name="name">Имя переменной</param>
        /// <param name="value">Устонавливаемое значение</param>
        protected void SetValue(string name, int value)
        {
            var uniformLocation = GL.GetUniformLocation(Id, name);
            GL.Uniform1(uniformLocation, value);
        }


        /// <summary>
        /// Установка значения uniform переменной в шейдере по имени. 
        /// </summary>
        /// <param name="name">Имя переменной</param>
        /// <param name="value">Устонавливаемое значение</param>
        protected void SetValue(string name, float value)
        {
            var uniformLocation = GL.GetUniformLocation(Id, name);
            GL.Uniform1(uniformLocation, value);
        }

        /// <summary>
        /// Установка значения uniform переменной в шейдере по имени. 
        /// </summary>
        /// <param name="name">Имя переменной</param>
        /// <param name="value">Устонавливаемое значение</param>
        protected void SetVector3(string name, Vector3 value)
        {
            var uniformLocation = GL.GetUniformLocation(Id, name);
            GL.Uniform3(uniformLocation, value);
        }

        /// <summary>
        /// Установка значения uniform переменной в шейдере по имени. 
        /// </summary>
        /// <param name="name">Имя переменной</param>
        /// <param name="value">Устонавливаемое значение</param>
        protected void SetVector3(string name, Color value)
        {
            var uniformLocation = GL.GetUniformLocation(Id, name);
            GL.Uniform3(uniformLocation, value.R, value.G, value.B);
        }

        /// <summary>
        /// Установка значения uniform переменной в шейдере по имени. 
        /// </summary>
        /// <param name="name">Имя переменной</param>
        /// <param name="value">Устонавливаемое значение</param>
        protected void SetMatrix4(string name, Matrix4 value)
        {
            var uniformLocation = GL.GetUniformLocation(Id, name);
            GL.UniformMatrix4(uniformLocation, true, ref value);
        }


        /// <summary>
        /// Получение значения location переменной шейдера по имени.
        /// </summary>
        public int GetAttribLocation(string attributName)
        {
            return GL.GetAttribLocation(Id, attributName);
        }

        private int CompileShaderFromFile(StreamReader shaderFile, ShaderType shaderType)
        {
            var vertexShader = GL.CreateShader(shaderType);

            GL.ShaderSource(vertexShader, shaderFile.ReadToEnd());
            GL.CompileShader(vertexShader);

            return vertexShader;
        }


        private void ConsoleLogShaderInfo(int shader)
        {
            string infoLog = GL.GetShaderInfoLog(shader);
            if (!String.IsNullOrEmpty(infoLog))
                Console.WriteLine(infoLog);
        }


        private void DetachDeleteShader(int shader)
        {
            GL.DetachShader(Id, shader);
            GL.DeleteShader(shader);
        }
    }
}