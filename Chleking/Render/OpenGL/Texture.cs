
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;

namespace SpaceGame.Render.OpenGL
{
    /// <summary>
    /// Двумерная текстура, взаимодействующая с OpenGL.
    /// Cпособно отображать RGBA цвета.
    /// </summary>
    public class Texture : IUsableByRender, IDisposable
    {
        private static Dictionary<string, Texture> dictionaryOfTextures = new Dictionary<string, Texture>();

        public static Texture GetTexture(string name)
        {
            return dictionaryOfTextures[name];
        }
        public static void CreateTexture(string name, string imagePath)
        {
            var model = new Texture(imagePath);
            dictionaryOfTextures.Add(name, model);
        }


        /// <summary>
        /// Id текстуры в массиве текстур OpenGL.
        /// </summary>
        public int Id { get; private set; }
        private Texture()
        {
        }
        private Texture(string imagePath)
        {
            // Создаем текстуру в памяти OpenGL.
            Id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, Id);

            // Инициализируем текстуру картинкой.
            using (var image = new Bitmap(imagePath))
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipX);
                var data = image.LockBits(
                    new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width,
                    image.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            }

            // Установка параметров наложения текстуры.
            SetTextureParameters();
            // Создаем для тектуры "пресеты меньшего размера" для
            // более правильного отображения в далеке и оптимизации.
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            Use();
        }
        /// <summary>
        /// Устанавливает параметры наложения текстуры.
        /// </summary>
        protected virtual void SetTextureParameters()
        {
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
        }
        /// <summary>
        /// Привязка текстуры для использования OpenGL.
        /// </summary>
        public void Use()
        {
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Id);
        }

        /// <summary>
        /// Привязка текстуры для использования OpenGL.
        /// </summary>
        /// <param name="unit">Уровень, где будет использоваться текстура</param>
        public void Use(TextureUnit unit)
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, Id);
        }


        public void Dispose()
        {
            GL.DeleteTexture(Id);
        }

    }
}
