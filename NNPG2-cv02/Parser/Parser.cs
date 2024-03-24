using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using NNPG2.Graf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNPG2.Parser
{
    public class Parser<T, TVertexData, TEdgeData>
    {
        private Data<T, TVertexData, TEdgeData> data { get; set; }
        private List<Vertex<T, TVertexData, TEdgeData>> vertices { get; set; }

        public Parser(string filePath)
        {
            try
            {
                string jsonData = System.IO.File.ReadAllText(filePath);
                data = JsonConvert.DeserializeObject<Data<T, TVertexData, TEdgeData>>(jsonData);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
            }
        }

        public List<Vertex<T, TVertexData, TEdgeData>> ExtractVertices()
        {
            try
            {
                vertices = new List<Vertex<T, TVertexData, TEdgeData>>();
                foreach (T vertexName in data.Vertices)
                {
                    vertices.Add(new Vertex<T, TVertexData, TEdgeData>(vertexName));
                }
                return vertices;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
                return null;
            }

        }

        public List<Edge<T, TVertexData, TEdgeData>> ExtractEdges()
        {
            try
            {

                List<Edge<T, TVertexData, TEdgeData>> edges = new List<Edge<T, TVertexData, TEdgeData>>();
                foreach (T[] edgeArray in data.Edges)
                {
                    T fromVertexName = edgeArray[0];
                    T toVertexName = edgeArray[1];

                    Vertex<T, TVertexData, TEdgeData> fromVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, fromVertexName));
                    Vertex<T, TVertexData, TEdgeData> toVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, toVertexName));
                    T name = (T)Convert.ChangeType("E" + edges.Count.ToString(), typeof(T));

                    if (fromVertex != null && toVertex != null)
                    {
                        edges.Add(new Edge<T, TVertexData, TEdgeData>(name, fromVertex, toVertex));
                    }
                    else
                    {
                        throw new Exception("Nepodařilo se najít vrcholy pro hranu.");
                    }
                }
                return edges;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
                return null;
            }
        }

        public List<Vertex<T, TVertexData, TEdgeData>> ExtractInputVertices()
        {
            try
            {
                List<Vertex<T, TVertexData, TEdgeData>> inputVertices = new List<Vertex<T, TVertexData, TEdgeData>>();
                foreach (T inputVertexName in data.InputVertices)
                {
                    Vertex<T, TVertexData, TEdgeData> inputVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, inputVertexName));
                    if (inputVertex != null)
                    {
                        inputVertices.Add(inputVertex);
                    }
                }
                return inputVertices;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
                return null;
            }
        }

        public List<Vertex<T, TVertexData, TEdgeData>> ExtractOutputVertices()
        {
            try
            {
                List<Vertex<T, TVertexData, TEdgeData>> outputVertices = new List<Vertex<T, TVertexData, TEdgeData>>();
                foreach (T outputVertexName in data.OutputVertices)
                {
                    Vertex<T, TVertexData, TEdgeData> outputVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, outputVertexName));
                    if (outputVertex != null)
                    {
                        outputVertices.Add(outputVertex);
                    }
                }
                return outputVertices;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
                return null;
            }
        }

        public List<List<Vertex<T, TVertexData, TEdgeData>>> ExtractCross()
        {
            try
            {

                List<List<Vertex<T, TVertexData, TEdgeData>>> cross = new List<List<Vertex<T, TVertexData, TEdgeData>>>();
                foreach (T[] crossArray in data.Cross)
                {
                    List<Vertex<T, TVertexData, TEdgeData>> crossList = new List<Vertex<T, TVertexData, TEdgeData>>();
                    foreach (T crossItem in crossArray)
                    {
                        Vertex<T, TVertexData, TEdgeData> crossVertex = vertices.Find(v => EqualityComparer<T>.Default.Equals(v.Name, crossItem));
                        if (crossVertex != null)
                        {
                            crossList.Add(crossVertex);
                        }
                    }
                    cross.Add(crossList);
                }
                return cross;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při parsování dat ze souboru: " + ex.Message);
                return null;
            }
        }

    }
}


