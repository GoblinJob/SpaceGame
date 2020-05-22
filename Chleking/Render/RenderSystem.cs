using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chleking.Render
{
    class RenderSystem : IEngineSystem
    {
        public static RenderSystem Instance { get; }
        static RenderSystem()
        {
            Instance = new RenderSystem();
        }
        private RenderSystem()
        {
        }

        public void LoadModel()
        {

        }

        public void Use()
        {
            throw new NotImplementedException();
        }
    }
}
