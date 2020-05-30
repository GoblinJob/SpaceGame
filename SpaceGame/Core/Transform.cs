using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Transform
    {
        public Transform()
        {
        }
        public Transform(Vector3 location)
        {
            this.position = location;
        }

        public Transform(Vector3 location, Quaternion rotation) 
            : this(location)
        {
            this.rotation = rotation;
        }

        public Transform(Vector3 location, Quaternion rotation, Vector3 scale)
    : this(location, rotation)
        {
            this.scale = scale;
        }

        public Vector3 ForwardVector => rotation.Xyz.Normalized();

        public Vector3 position;
        public Quaternion rotation = Quaternion.Identity;
        public Vector3 scale = Vector3.One;
    }
}
