using Newtonsoft.Json;
using NNPG2_cv02.Graf;
using System;
using System.Collections.Generic;

namespace NNPG2_cv02.Path
{
    public class Paths<T, TVertexData, TEdgeData>
    {
        [JsonProperty]
        public List<Path<T, TVertexData, TEdgeData>> paths { get; set; }
        private int index = 1;
        private Graf<T, TVertexData, TEdgeData> graphData;
        public List<Vertex<T, TVertexData, TEdgeData>> InputVertices { get; private set; }
        public List<Vertex<T, TVertexData, TEdgeData>> OutputVertices { get; private set; }

        public Paths(
            GraphProcessor<T, TVertexData, TEdgeData> processor,
            Graf<T, TVertexData, TEdgeData> graf
            )
        {
            this.graphData = graf;
            this.InputVertices = processor.getInputVertices();
            this.OutputVertices = processor.getOutputVertices();
            paths = new List<Path<T, TVertexData, TEdgeData>>();
            FindPaths();
        }

        public void printList()
        {
            Console.WriteLine("Dostupné cesty:");
            foreach (var path in paths)
            {
                Console.WriteLine($"Cesta {path.Name}: {string.Join(" -> ", path.Vertices)}");
            }
        }

        public void FindPaths()
        {
            foreach (var inputVertex in InputVertices)
            {
                List<Vertex<T, TVertexData, TEdgeData>> visited = new List<Vertex<T, TVertexData, TEdgeData>>();
                DFS(inputVertex, visited);
            }
        }

        private void DFS(Vertex<T, TVertexData, TEdgeData> currentVertex, List<Vertex<T, TVertexData, TEdgeData>> visited)
        {
            visited.Add(currentVertex);
            if (containsByName(currentVertex.Name, OutputVertices)
                && visited.Count > 1
                && !PathAlreadyExists(visited))
            {
                paths.Add(new Path<T, TVertexData, TEdgeData>(index++,
                    new LinkedList<Vertex<T, TVertexData, TEdgeData>>(visited)));
            }


            foreach (var edge in currentVertex.Edges)
            {
                if (!visited.Contains(edge.EndVertex))
                {
                    DFS(edge.EndVertex, visited);
                }
            }

            foreach (var cross in graphData.Cross)
            {
                if (cross[0] == currentVertex
                    && !visited.Contains(cross[1])
                    && !visited.Contains(cross[2]))
                {
                    List<Vertex<T, TVertexData, TEdgeData>> newVisited = new List<Vertex<T, TVertexData, TEdgeData>>(visited);
                    newVisited.Add(cross[1]);
                    DFS(cross[2], newVisited);
                }
            }

            visited.Remove(currentVertex);
        }


        private bool containsByName(T name, List<Vertex<T, TVertexData, TEdgeData>> list)
        {
            foreach (var vertex in list)
            {
                if (vertex.Name.Equals(name))
                {
                    return true;
                }
            }

            return false;
        }

        private bool PathAlreadyExists(List<Vertex<T, TVertexData, TEdgeData>> newPath)
        {
            foreach (var path in paths)
            {
                if (path.Equals(newPath))
                {
                    return true;
                }
            }
            return false;
        }
    }
}