using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chleking
{
    public sealed class RGBAReader : IDisposable
    {
        private Bitmap bitmap;
        public RGBAReader(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }
        public float[] GetRGBA()
        {
            return ReadBitMapRGBA(bitmap);
        }

        private float[] ReadBitMapRGBA(Bitmap bitmap)
        {
            var resault = new float[4 * bitmap.Width * bitmap.Height];
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    resault[0 + x + y * bitmap.Width] = pixel.R;
                    resault[1 + x + y * bitmap.Width] = pixel.G;
                    resault[2 + x + y * bitmap.Width] = pixel.B;
                    resault[3 + x + y * bitmap.Width] = pixel.A;
                }
            }
            return resault;
        }

        public void Dispose()
        {
            bitmap.Dispose();
        }
    }
}
