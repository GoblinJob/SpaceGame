using SpaceGame.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class ResurceManager
    {
        private static Dictionary<string, VerticesInfo> vertexInfoDictionary = new Dictionary<string, VerticesInfo>();
        private static Dictionary<string, Shader> shadersDictionary = new Dictionary<string, Shader>();
        public static Dictionary<string, Texture> textureDictionary = new Dictionary<string, Texture>();
        public static Dictionary<string, Model> modelDictionary = new Dictionary<string, Model>();

        public static VerticesInfo GetVertexInfo(string name)
        {
            return vertexInfoDictionary[name];
        }

        public static Shader GetShader(string name)
        {
            return shadersDictionary[name];
        }

        public static Texture GetTexture(string name)
        {
            return textureDictionary[name];
        }

        public static Model GetModel(string name)
        {
            return modelDictionary[name];
        }


        public static void LoadVertexInfo(string name, VerticesInfo loadVertexInfo, float[] vertexInfo)
        {
            loadVertexInfo.Load(vertexInfo);
            vertexInfoDictionary.Add(name, loadVertexInfo);
        }

        public static void LoadShader(string name, Shader loadShader, string vertexPath, string fragmentPath)
        {
            if (!(File.Exists(vertexPath) && File.Exists(fragmentPath)))
            {
                throw new FileNotFoundException($"Files {vertexPath} and {fragmentPath} not exist.");
            }
            else if (!File.Exists(vertexPath))
            {
                throw new FileNotFoundException($"Files {vertexPath} not exist.");
            }
            else if (!File.Exists(fragmentPath))
            {
                throw new FileNotFoundException($"File {fragmentPath} not exist.");
            }

            var vertexShaderFile = new StreamReader(vertexPath);
            var fragmentShaderFile = new StreamReader(fragmentPath);

            try
            {
                loadShader.Load(vertexShaderFile, fragmentShaderFile);
                shadersDictionary.Add(name, loadShader);
            }
            catch
            {
                throw;
            }
            finally
            {
                vertexShaderFile.Dispose();
                fragmentShaderFile.Dispose();
            }
        }

        public static void LoadTexture(string name, Texture loadTexture, string texturePath)
        {
            if (!File.Exists(texturePath))
            {
                throw new FileNotFoundException($"File {texturePath} not exist.");
            }

            var image = new Bitmap(texturePath);

            try
            {
                loadTexture.Load(image);
                textureDictionary.Add(name, loadTexture);
            }
            catch
            {
                throw;
            }
            finally
            {
                image.Dispose();
            }
        }

        public static void LoadModel(string name, Model loadModel, string vertexInfoName, string shaderName)
        {
            var vartexInfo = GetVertexInfo(vertexInfoName);
            var shader = GetShader(shaderName);

            loadModel.Load(vartexInfo, shader);
            modelDictionary.Add(name, loadModel);
        }


        // TODO Replace 
        //public static void ReplacePolygonInfo(string name, PolygonsInfo newPolygonInfo)
        //{
        //    var replacingVertexInfo = polygonInfoDictionary[name];
        //    replacingVertexInfo.Unload();
        //}

        //public static void ReplaceShader(string name, Shader newShader)
        //{

        //}

        //public static void ReplaceTexture(string name, Texture newTexture)
        //{

        //}
    }
}
