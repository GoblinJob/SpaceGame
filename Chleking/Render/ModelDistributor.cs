using SpaceGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chleking.Render
{
    class ModelDistributor
    {
        private List<Model> models = new List<Model>();

        public Model CreateCollider(float[] verticesInfo, EngineObject owner)
        {
            var model = new Model(verticesInfo, owner);

            models.Add(model);
            return collider;
        }

        private void InitializeModel()
        {
            model
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
