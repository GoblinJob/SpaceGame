using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chleking
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var game = new OpiGame(500, 500, "Chlekin"))
            {
                // Запуск программы.
                game.Run(60.0);
            }
        }
    }
}
