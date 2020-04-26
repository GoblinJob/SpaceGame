using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chleking
{
    public class Texture
    {
        public Image SourceImage { get; private set; }
        public int Width => SourceImage.Width;
        public int Height => SourceImage.Height;

        public Texture(Image sourceImage)
        {
            this.SourceImage = sourceImage;
        }

        private byte[] GetPixelRGBA()
        {
            var resault = new byte[SourceImage.Width * SourceImage.Height * 4];
            using (var bitmap = new Bitmap(SourceImage))
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        var pixel = bitmap.GetPixel(x, y);
                        int pixelStartIndex = (x + y * bitmap.Width) * 4;
                        Console.WriteLine(pixelStartIndex);

                        resault[pixelStartIndex + 0] = pixel.R;
                        resault[pixelStartIndex + 1] = pixel.G;
                        resault[pixelStartIndex + 2] = pixel.B;
                        resault[pixelStartIndex + 3] = pixel.A;
                    }
                }
            }
            return resault;
        }

        public void Use()
        {

        }
    }
}