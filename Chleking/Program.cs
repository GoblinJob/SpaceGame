﻿using OpenTK;
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
            using (var game = new Window(1200, 1000, "Chlekin"))
            {
                // Запуск программы.
                game.Run(60.0);
            }
        }
    }
}
