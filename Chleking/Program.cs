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
            using (var game = new Window(1600, 1600, "Chlekin"))
            {
                // Запуск программы.
                game.Run(60.0);
            }
        }
    }
}
