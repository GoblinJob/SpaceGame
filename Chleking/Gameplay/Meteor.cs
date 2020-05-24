using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Gameplay
{
    class Meteor
    {
        static Random random = new Random();
        public static Vector3[] GenCoordMeteor()
        {
            Vector3[] coord = new Vector3[26];
            List<float> coordXY = new List<float>();

            for (int i = 0; i < 3; i++)
            {
                coordXY.Add(GenCoord());
            }

            for (int i = 0; i < 8; i++)
            {
                coord[i] = new Vector3(coordXY[0], coordXY[0], GenCoord());
                coord[i + 8] = new Vector3(coordXY[1], coordXY[1], GenCoord());
                coord[i + 16] = new Vector3(coordXY[2], coordXY[2], GenCoord());
            }

            coordXY.Sort();

            coord[24] = new Vector3(coordXY[0], coordXY[0] - (1.0f - coordXY[0] - GenCoord(0, 1.0 - coordXY[0])), GenCoord());
            coord[25] = new Vector3(coordXY[2], coordXY[2] + (1.0f - coordXY[2] - GenCoord(0, 1.0 - coordXY[2])), GenCoord());

            return coord;
        }

        private static float GenCoord()
        {
            return GenCoord(-1.0, 1.0);
        }

        private static float GenCoord(double min, double max)
        {
            return (float)(random.NextDouble() * (max - min) + min);
        }
    }
}
