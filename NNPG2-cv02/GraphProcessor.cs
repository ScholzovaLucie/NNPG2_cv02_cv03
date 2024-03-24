using NNPG2.DrawData;
using NNPG2.Graf;
using NNPG2.Parser;
using NNPG2.Path;
using System.Collections.Generic;


namespace NNPG2
{
    public class GraphProcessor<T, TVertexData, TEdgeData>
    {
        private List<Vertex<T, TVertexData, TEdgeData>> Vertices { get; set; }
        private List<Vertex<T, TVertexData, TEdgeData>> InputVertices { get; set; }
        private List<Vertex<T, TVertexData, TEdgeData>> OutputVertices { get; set; }
        private List<List<Vertex<T, TVertexData, TEdgeData>>> Cross { get; set; }
        private List<Edge<T, TVertexData, TEdgeData>> edges { get; set; }


        public void ProcessGraph(string filePath)
        {
            Parser<T, TVertexData, TEdgeData> parser = new Parser<T, TVertexData, TEdgeData>(filePath);
            Vertices = parser.ExtractVertices();
            edges = parser.ExtractEdges();
            InputVertices = parser.ExtractInputVertices();
            OutputVertices = parser.ExtractOutputVertices();
            Cross = parser.ExtractCross();
        }

        public Graf<T, TVertexData, TEdgeData> CreateGraf()
        {
            Graf<T, TVertexData, TEdgeData> graf = new Graf<T, TVertexData, TEdgeData>();

            foreach (Vertex<T, TVertexData, TEdgeData> vertex in Vertices)
            {
                List<Edge<T, TVertexData, TEdgeData>> currentEdges = findEdges(vertex, edges);
                foreach (var edge in currentEdges)
                {
                    vertex.Edges.Add(edge);
                }
                graf.AddVertex(vertex);

            }

            foreach (var item in Cross)
            {
                graf.Cross.Add(item);
            }


            return graf;
        }

        private List<Edge<T, TVertexData, TEdgeData>> findEdges(Vertex<T, TVertexData, TEdgeData> vertex, List<Edge<T, TVertexData, TEdgeData>> edges)
        {
            List<Edge<T, TVertexData, TEdgeData>> currentEdges = new List<Edge<T, TVertexData, TEdgeData>>();
            foreach (var edge in edges)
            {
                if (edge.StartVertex.sameVertex(vertex)) currentEdges.Add(edge);
            }
            return currentEdges;
        }


        public List<Vertex<T, TVertexData, TEdgeData>> getInputVertices()
        {
            return InputVertices;
        }

        public List<Vertex<T, TVertexData, TEdgeData>> getOutputVertices()
        {
            return OutputVertices;
        }

        public List<Vertex<T, TVertexData, TEdgeData>> GetVertices()
        {
            return Vertices;
        }

        public List<List<Vertex<T, TVertexData, TEdgeData>>> getCross()
        {
            return Cross;
        }


    }


}
