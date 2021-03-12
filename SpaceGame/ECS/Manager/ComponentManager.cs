using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    public class ComponentManager
    {
        private Component[] storage;
        public ComponentManager(int storegeSize)
        {
            storage = new Component[storegeSize];
        }

        public int CreateComponent<T>() where T : Component, new()
        {
            int i = 0;
            while (storage[i] != null)
            {
                i++;
            }

            storage[i] = new T();

            return i;
        }

        public T GetComponent<T>(int i) where T : Component
        {
            return (T)storage[i];
        }

        public void DestroyComponent(int i)
        {
            storage[i] = null;
        }
    }
}
