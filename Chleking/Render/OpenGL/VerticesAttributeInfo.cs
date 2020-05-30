using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render.OpenGL
{
    public class VerticesAttributeInfo
    {
        public string Name { get; }
        public int RowSize { get; }
        public VerticesAttributeInfo(string name, int rowSize)
        {
            if (rowSize >= 0)
                throw new ArgumentOutOfRangeException("rowSize can't be smaller then 1");
            
            this.Name = name;
            this.RowSize = rowSize;
        }
    }
}
