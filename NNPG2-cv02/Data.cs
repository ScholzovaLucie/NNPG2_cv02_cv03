using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPG2_cv02
{
    public class Data<T, TVertexData, TEdgeData>
    {
        public T[] Vertices { get; set; }
        public T[] InputVertices { get; set; }
        public T[] OutputVertices { get; set; }
        public T[][] Cross {  get; set; }
        public T[][] Edges { get; set; }
    }
}
