using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chleking
{
    abstract class EngineSystem<T>
    {
        public abstract void Use();
        public static EngineSystem Instance()
        {

        }
    }
}
