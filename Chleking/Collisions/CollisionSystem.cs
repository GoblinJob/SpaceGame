using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chleking;
using OpenTK;

namespace SpaceGame.Collisions
{
    class CollisionSystem : IEngineSystem
    {
        private ColliderDistributor colliders = new ColliderDistributor();
        public static CollisionSystem Instance { get; }
        static CollisionSystem()
        {
            Instance = new CollisionSystem();
        }
        private CollisionSystem()
        {
        }

        public void Use()
        {
            foreach(var collider in colliders)
            {
                var collisedColliders = CollisionChecker.Check(collider);
                collider.SetIsCollised(collisedColliders);
            }
        }
    }
}
