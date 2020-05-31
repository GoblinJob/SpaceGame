using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceGame.Collisions
{
    class CollisionSystem
    {
        static CollisionSystem()
        {
            Instance = new CollisionSystem();
        }


        public static CollisionSystem Instance { get; }


        private CollisionSystem()
        {
            Distributor = new ColliderDistributor();
        }


        public ColliderDistributor Distributor { get; }


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
