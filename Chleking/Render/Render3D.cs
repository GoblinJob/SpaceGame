using SpaceGame.Core;
using SpaceGame.Render.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    public class Render3D
    {
        public static List<Render3D> AllRenders { get; private set; } = new List<Render3D>();


        public Render3D(string modelName, string textureName, GameObject owner)
        {
            this.Owner = owner;
            this.renderObject = RenderableObject.Create(Model.GetModel(modelName), Texture.GetTexture(textureName));
            AllRenders.Add(this);
        }


        public GameObject Owner { get; private set; }


        public Transform Transform => Owner.Transform;


        private RenderableObject renderObject;


        public void Draw(Camera camera)
        {
            renderObject.Draw(camera, Transform);
        }
    }
}
