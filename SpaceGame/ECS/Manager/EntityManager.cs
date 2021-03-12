using Chleking.Core;
using ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.ECS
{
    public class EntityManager
    {
        private Entity[] storage;
        public EntityManager(int storegeSize)
        {
            storage = new Entity[storegeSize];
        }

        public int CreateEntity()
        {
            int i = 0;
            while (storage[i] != null)
            {
                i++;
            }

            storage[i] = new Entity();

            return i;
        }

        public Entity GetEntity(int i)
        {

            return storage[i];
        }

        public void Destroy(int i)
        {
            storage[i] = null;
        }
    }
}
