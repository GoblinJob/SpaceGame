using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chleking.Render.Exceptions
{

    [Serializable]
    public class EntityAlreadyLoadException : Exception
    {
        public EntityAlreadyLoadException() : base($"Object already Load to Render!") { }
        public EntityAlreadyLoadException(string message) : base(message) { }
        public EntityAlreadyLoadException(string message, Exception inner) : base(message, inner) { }
        protected EntityAlreadyLoadException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
