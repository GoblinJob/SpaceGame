using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    public class VerticesAttributeInfo
    {
        public string Name { get; }
        public int RowLength { get; }
        public VerticesAttributeInfo(string name, int rowLenght)
        {
            if (rowLenght <= 0)
                throw new ArgumentOutOfRangeException("rowSize can't be smaller then 1");
            
            this.Name = name;
            this.RowLength = rowLenght;
        }
    }
}
