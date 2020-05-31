using Chleking.Core;
using OpenTK;
using SpaceGame.Collisions;
using SpaceGame.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class GameObject
    {
        private Component Component { get; set; }
        public GameObject(Transform transform)
        {
            Transform = transform;
        }
        public GameObject(Transform transform, string modelName) : this(transform)
        {
            Transform = transform;
            Model = new Render3D(modelName, this);
        }

        public Transform Transform { get; set; }
        // TODO: collisions
        //public Collider Collider { get; set; }
        public Render3D Model { get; set; }

    }
}
