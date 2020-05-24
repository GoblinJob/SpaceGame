using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceGame.Collisions
{
    class CollisionSystem : IEngineSystem
    {
        public ColliderDistributor Distributor { get; }
        public static CollisionSystem Instance { get; }
        static CollisionSystem()
        {
            Instance = new CollisionSystem();
        }
        private CollisionSystem()
        {
            Distributor = new ColliderDistributor();
        }

        public void Use()
        {
            foreach(var collider in Distributor)
            {
                var collisedColliders = CollisionChecker.Check(collider);
                collider.SetIsCollised(collisedColliders);
            }
        }
    }
}
