using OpenTK;
using System.Drawing;
using TestGame;

namespace Chleking.Render
{
    internal class RenderInfo
    {
        public RenderInfo(Bitmap texture)
        {
            this.Texture = new Texture(texture);
        }
        public Texture Texture { get; set; }
        public VaO
    }
}