using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NNPG2.Graf;

namespace NNPG2.Path
{
    public class Path<T, TVertexData, TEdgeData>
    {
        public string Name { get; set; }
        public LinkedList<Vertex<T, TVertexData, TEdgeData>> Vertices { get; set; }

        public Path(LinkedList<Vertex<T, TVertexData, TEdgeData>> vertices)
        {
            Vertices = vertices;
        }

        public Path(int index, LinkedList<Vertex<T, TVertexData, TEdgeData>> vertices)
        {
            Name = "A" + index;
            Vertices = vertices;
        }


        public void setName(int index)
        {
            Name = "A" + index;
        }

        public Path<T, TVertexData, TEdgeData> Copy()
        {
            LinkedList<Vertex<T, TVertexData, TEdgeData>> copiedVertices = new LinkedList<Vertex<T, TVertexData, TEdgeData>>(Vertices);
            return new Path<T, TVertexData, TEdgeData>(copiedVertices);
        }

        public Vertex<T, TVertexData, TEdgeData> getFirst()
        {
            return Vertices.First();
        }

        public Vertex<T, TVertexData, TEdgeData> getLast()
        {
            return Vertices.Last();
        }


        public bool Equals(Path<T, TVertexData, TEdgeData> other)
        {
            if (Vertices.Count != other.Vertices.Count) return false;

            bool same = true;

            Vertex<T, TVertexData, TEdgeData> aktual_this = Vertices.First();
            Vertex<T, TVertexData, TEdgeData> aktual_other = other.Vertices.First();

            if (!aktual_this.Name.Equals(aktual_other.Name))
            {
                return false;
            }

            foreach (Vertex<T, TVertexData, TEdgeData> s in Vertices)
            {
                if (Vertices.Find(aktual_this).Next == null)
                {
                    if (!aktual_this.Name.Equals(aktual_other.Name))
                    {
                        return false;
                    }
                    return same;
                }

                aktual_this = Vertices.Find(aktual_this).Next.Value;
                aktual_other = other.Vertices.Find(aktual_other).Next.Value;

                if (!aktual_this.Name.Equals(aktual_other.Name))
                {
                    return false;
                }

            }
            return same;
        }

        public bool IsDisjoint(Path<T, TVertexData, TEdgeData> other)
        {
            foreach (var vertex in Vertices)
            {
                foreach (var vertex1 in other.Vertices)
                {
                    if (vertex1.Name.Equals(vertex.Name)) {
                        return false; 
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            string returnString = "";
            foreach (var vertex in Vertices)
            {
                returnString += vertex.ToString() +"->";
            }
            return returnString;
        }
    }

}
