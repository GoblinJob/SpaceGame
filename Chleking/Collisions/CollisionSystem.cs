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
        public static CollisionSystem Instance { get; }
        static CollisionSystem()
        {
            Instance = new CollisionSystem();
        }
        private CollisionSystem()
        {

        }
    }
}
