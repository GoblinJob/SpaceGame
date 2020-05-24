using OpenTK;
using SpaceGame.Collisions;
using SpaceGame.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render.OpenGL
{
    public class ModelDistributor : IEnumerable<Model>
    {
        private List<Model> models = new List<Model>();

        public Model CreateModel(float[] verticesInfo, string texturePath, EngineObject owner)
        {
            var model = new Model(CreateRenderObject(verticesIёnfo, texturePath), owner);
            models.Add(model);
            return model;
        }

        public Model CreateModel(float[] vertices, float[] textCoord, string texturePath, EngineObject owner)
        {
            var model = new Model(CreateRenderObject(vertices, textCoord, texturePath), owner);
            models.Add(model);
            return model;
        }

        public void GetModelsInView()
        { }

        private RenderObject CreateRenderObject(float[] vertices, float[] textCoord, string texturePath)
        {
            var vertexInfo = new VertexInfo(vertices, textCoord);
            var texture = new Texture(texturePath);
            return new RenderObject(vertexInfo, texture);
        }

        private RenderObject CreateRenderObject(float[] verticesInfo, string texturePath)
        {
            var vertexInfo = new VertexInfo(verticesInfo);
            var texture = new Texture(texturePath);
            return new RenderObject(vertexInfo, texture);
        }

        public bool RemoveCollider(Model model)
        {
            return models.Remove(model);
        }

        public IEnumerator<Model> GetEnumerator()
        {
            return models.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return models.GetEnumerator();
        }
    }
}
