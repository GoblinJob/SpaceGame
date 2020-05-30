using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chleking.Render.Exceptions
{

    [Serializable]
    public class EntityNotLoadedException : Exception
    {
        public EntityNotLoadedException() : base("First you need to load an object to do this.") { }
        public EntityNotLoadedException(string message) : base(message) { }
        public EntityNotLoadedException(string message, Exception inner) : base(message, inner) { }
        protected EntityNotLoadedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
