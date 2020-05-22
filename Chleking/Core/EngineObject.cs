using Chleking.Render;
using ConsoleApp3;
using SpaceGame.Collisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Core
{
    public class EngineObject
    {
        public Transform Transform { get; private set; } 
        public Collider Collider { get; set; }
        public Model Model { get; set; }
    }
}
