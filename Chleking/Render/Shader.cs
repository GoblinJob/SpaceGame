using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    /// <summary>
    /// Шейдер загружаймый в OpenGL.
    /// </summary>
    internal class Shader : IDisposable
    {
        public Shader(string vertexPath, string fragmentPath)
        {
            Id = GL.CreateProgram();

            var vertexShaderId = CreateCompileShaderFromFile(vertexPath, ShaderType.VertexShader);
            ConsoleLogShaderInfo(vertexShaderId);
            GL.AttachShader(Id, vertexShaderId);

            var fragmentShader = CreateCompileShaderFromFile(fragmentPath, ShaderType.FragmentShader);
            ConsoleLogShaderInfo(fragmentShader);
            GL.AttachShader(Id, fragmentShader);

            GL.LinkProgram(Id);
            GL.ValidateProgram(Id);

            DetachDeleteShader(vertexShaderId);
            DetachDeleteShader(fragmentShader);
        }


        /// <summary>
        /// Id шейдера в массиве шейдеров OpenGL.
        /// </summary>
        public int Id { get; private set; }


        /// <summary>
        /// Привязка шейдера для использования OpenGL.
        /// </summary>
        public virtual void Use()
        {
            GL.UseProgram(Id);
        }


        public virtual void Dispose()
        {
            GL.DeleteProgram(Id);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Установка значения uniform переменной в шейдере по имени. 
        /// </summary>
        /// <param name="name">Имя переменной</param>
        /// <param name="value">Устонавливаемое значение</param>
        public void SetValue(string name, bool value)
        {
            var uniformLocation = GL.GetUniformLocation(Id, name);
            GL.Uniform1(uniformLocation, value ? 1 : 0);
        }


        /// <summary>
        /// Установка значения uniform переменной в шейдере по имени. 
        /// </summary>
        /// <param name="name">Имя переменной</param>
        /// <param name="value">Устонавливаемое значение</param>
        public void SetValue(string name, int value)
        {
            var uniformLocation = GL.GetUniformLocation(Id, name);
            GL.Uniform1(uniformLocation, value);
        }


        /// <summary>
        /// Установка значения uniform переменной в шейдере по имени. 
        /// </summary>
        /// <param name="name">Имя переменной</param>
        /// <param name="value">Устонавливаемое значение</param>
        public void SetValue(string name, float value)
        {
            var uniformLocation = GL.GetUniformLocation(Id, name);
            GL.Uniform1(uniformLocation, value);
        }


        /// <summary>
        /// Получение значения location переменной шейдера по имени.
        /// </summary>
        public int GetAttribLocation(string attributName)
        {
            return GL.GetAttribLocation(Id, attributName);
        }


        private int CreateCompileShaderFromFile(string shaderPath, ShaderType shaderType)
        {
            string shaderSource;

            using (StreamReader reader = new StreamReader(shaderPath, Encoding.UTF8))
            {
                shaderSource = reader.ReadToEnd();
            }

            var vertexShader = GL.CreateShader(shaderType);

            GL.ShaderSource(vertexShader, shaderSource);
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