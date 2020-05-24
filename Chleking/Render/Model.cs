using SpaceGame.Core;
using SpaceGame.Render.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    public class Model
    {
        public static List<Model> models = new List<Model>();

        private RenderObject renderObject;
        public EngineObject Owner { get; private set; }
        public Transform Transform => Owner.Transform;

        public Model(RenderObject renderObject, EngineObject owner)
        {
            this.Owner = owner;
            this.renderObject = renderObject;
            AddModel(this);
        }

        private static void AddModel(Model model)
        {
            models.Add(model);
            models.Sort();
        }

        public void Draw(Camera camera)
        {
            renderObject.Draw(camera, Transform);
        }
    }
}
