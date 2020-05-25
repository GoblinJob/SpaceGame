using OpenTK;
using SpaceGame.Collisions;
using SpaceGame.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Core
{
    public class GameObject
    {
        public GameObject(Transform transform, Vector3[] colliderVertices, string modelName, string textureName)
        {
            Transform = transform;
            Collider = new Collider(colliderVertices, this);
            Model = new Render3D(modelName, textureName, this);
        }

        public Transform Transform { get; set; } 
        public Collider Collider { get; set; }
        public Render3D Model { get; set; }



    }
}
