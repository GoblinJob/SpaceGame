using OpenTK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Collisions
{
    class ColliderDistributor : IEnumerable<Collider>
    {
        private List<Collider> colliders = new List<Collider>();

        public Collider CreateCollider(Vector3[] vertices, GameObject owner)
        {
            var collider = new Collider(vertices, owner);
            colliders.Add(collider);
            return collider;
        }

        public bool RemoveCollider(Collider collider)
        {
            return colliders.Remove(collider);
        }

        public IEnumerator<Collider> GetEnumerator()
        {
            return (IEnumerator<Collider>)colliders;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Collider>)colliders;
        }
    }
}
