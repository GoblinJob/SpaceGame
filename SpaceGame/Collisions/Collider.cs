using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Collisions
{
    public delegate void Collised(Collider[] colliders);
    

    public sealed class Collider
    {
        public Collider(Vector3[] vertices, GameObject owner)
        {
            this.Vertices = vertices;
            this.Owner = owner;
        }


        public event Collised OnCollised;
        public event Collised OnCollising;
        public event Collised OnDecolised;


        private bool isCollised;


        public GameObject Owner { get; set; }
        public Vector3[] Vertices { get; set; }


        public void SetIsCollised(Collider[] colliders)
        {
            if(colliders != null && !isCollised)
            {
                this.isCollised = true;
                OnCollised.Invoke(colliders);
            }
            else if(colliders != null && isCollised)
            {
                OnCollising.Invoke(colliders);
            }
            else
            {
                this.isCollised = false;
                OnDecolised.Invoke(colliders);
            }
        }
    }
}
