using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine(Matrix4.CreateTranslation(30, 190, 90));

            var cameraPositon = new Vector3(0, 0, 3);
            var cameraTarget = Vector3.Zero;
            var cameraDirection = Vector3.Normalize(cameraPositon - cameraTarget);
            var upVector = new Vector3(0.0f, 1.0f, 0.0f);
            var cameraRight = Vector3.Normalize(Vector3.Cross(upVector, cameraDirection));
            var cameraUp = Vector3.Cross(cameraDirection, cameraRight);

            using (var game = new Window(1200, 1000, "Chlekin"))
            {
                // Запуск программы.
                game.Run(60.0);
            }
        }
    }
}
