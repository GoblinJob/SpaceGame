using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Collisions
{
    interface ICollisinable
    {
        Vector3[] WorldVerticesCoordinate { get; }
    }
}
