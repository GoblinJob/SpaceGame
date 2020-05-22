using Chleking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chleking.Visualisation
{
    interface IRenderSystem : EngineSystem
    {
        void Subscribe(IRenderSystem subsciber);

        void UnSubscribe(IRenderSystem subsciber);
    }
}
