using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS
{
    public abstract class Manager<T> where T : new()
    {
        protected T[] storage;
        public Manager(int maxElementCount)
        {
            storage = new T[maxElementCount];
        }

        public int Create()
        {
            int i = 0;
            while (storage[i] != null)
            {
                i++;
            }

            storage[i] = new T();

            return i;
        }

        public T Get(int i)
        {
            
            return storage[i];
        }

        public void Destroy(int i)
        {
            storage[i] = null;
        }
    }
}
