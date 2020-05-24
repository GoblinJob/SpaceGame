using SpaceGame.Render.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    class RenderSystem : IEngineSystem, IDisposable
    {
        public ModelDistributor Distributor { get;  }
        public static RenderSystem Instance { get; }
        static RenderSystem()
        {
            Instance = new RenderSystem();
        }
        private RenderSystem()
        {
            Distributor = new ModelDistributor();
        }

        private Color ClearColor = Color.FromArgb(255, 12, 52);

        public void Use()
        {
            foreach (var item in Distributor)
            {
                item.Draw();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
