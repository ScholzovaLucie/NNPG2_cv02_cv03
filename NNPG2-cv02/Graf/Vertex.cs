using NNPG2.DrawData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NNPG2.Graf
{
    public class Vertex<T, TVertexData, TEdgeData>
    {
        public T Name
        {
            get { return name; }
            set { name = value; }
        }

        public TVertexData data { get; set; }

        private T name;

        public List<Edge<T, TVertexData, TEdgeData>> Edges {  
            get { return edges;}
            set { edges = value; }
        }

        private List<Edge<T, TVertexData, TEdgeData>> edges;

        public Vertex(T name) {
            this.name = name;
            edges = new List<Edge<T, TVertexData, TEdgeData>>();
        }

        public void setData(TVertexData data) {
            this.data = data;
        }

        public void removeEdge(Edge<T, TVertexData, TEdgeData> edge)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].Name.Equals(edge.Name))
                {
                    edges.Remove(edges[i]);
                }
            }
        }


        public bool sameVertex(Vertex<T, TVertexData, TEdgeData> other)
        {
            return Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return Convert.ToString(Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17; 
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                return hash;
            }
        }


    }
}
