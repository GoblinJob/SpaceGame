using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Core
{
    public class Transform
    {
        public Transform()
        {
            location = Vector3.Zero;
            rotation = Quaternion.Identity;
            scale = Vector3.One;
        }

        public Vector3 location;
        public Quaternion rotation;
        public Vector3 scale;
    }
}
