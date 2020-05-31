using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.ECS
{
    public class Entity
    {
        public int Id { get; }
        public T GetComponent<T>() where T : new()
        {
            return new T();
        }
    }
}
