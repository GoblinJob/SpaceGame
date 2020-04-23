using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chleking
{
    class Square : IGraficEntity
    {
        private float[] vertices;
        private Shader shader;

        // Id объекты буфера вершин.
        private int vertexBufferId;
        // Id объекта массива вершин.
        private int vertexArrayId;

        public Square(Shader shader, float[] vertices)
        {
            this.shader = shader;
            this.vertices = vertices;
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            throw new NotImplementedException();
        }
    }
}
