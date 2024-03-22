using NNPG2_cv02.DrawData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPG2_cv02.Graf
{
    public class Edge<T, TVertexData, TEdgeData>
    {
        public T Name { get; set; }
        public Vertex<T, TVertexData, TEdgeData> StartVertex { get; set; }
        public Vertex<T, TVertexData, TEdgeData> EndVertex { get; set; }
        public TEdgeData data { get; set; }

        public Edge(T name, Vertex<T, TVertexData, TEdgeData> startVertex, Vertex<T, TVertexData, TEdgeData> endVertex)
        {
            Name = name;
            StartVertex = startVertex;
            EndVertex = endVertex;
        }

        public Edge()
        {
        }

        public void setData(TEdgeData data)
        {
            this.data = data;
        }

        public override string ToString()
        {
            return Name + ": " + StartVertex + ", " + EndVertex;
        }

        public bool sameEdge(Edge<T, TVertexData, TEdgeData> other)
        {
            return StartVertex.Name.Equals(other.StartVertex.Name) && EndVertex.Name.Equals(other.EndVertex.Name);
        }
    }
}
