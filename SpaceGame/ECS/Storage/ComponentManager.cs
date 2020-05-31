using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    public class ComponentStorage
    {
        public Component[] storage;
        public ComponentStorage(int maxElementCount)
        {
            storage = new Component[maxElementCount];
        }

        public T CreateCompoennt<T>() where T : Component, new()
        {
            return new T();
        }

        public int CreateEnitiy()
        {
            int i = 0;
            while (storage[i] != null)
            {
                i++;
            }

            storage[i] = new Entity();

            return i;
        }

        public Entity GetEnity(int i)
        {
            return storage[i];
        }

        public void DstroyEnity(int i)
        {
            storage[i] = null;
        }
    }
}
