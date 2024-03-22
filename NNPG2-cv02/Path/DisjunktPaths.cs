using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NNPG2_cv02.Graf;
using NNPG2_cv02.DrawData;

namespace NNPG2_cv02.Path
{
    public class DisjointPaths<T, TVertexData, TEdgeData>
    {
        [JsonProperty]
        public List<HashSet<Path<T, TVertexData, TEdgeData>>> DisjointPathSets { get; private set; }
        private int MaxTupleSize;

        public DisjointPaths(List<Path<T, TVertexData, TEdgeData>> paths, int maxTupleSize)
        {
            DisjointPathSets = new List<HashSet<Path<T, TVertexData, TEdgeData>>>();
            MaxTupleSize = maxTupleSize;
            GenerateDisjointSets(paths);
        }

        public List<HashSet<Path<T, TVertexData, TEdgeData>>> getDisjonktPaths()
        {
            return DisjointPathSets;
        }

        public void printList()
        {
            Console.WriteLine("Disjunktní množina cest: ");
            foreach (var disjointSet in DisjointPathSets)
            {
                foreach (var path in disjointSet)
                {
                    Console.Write(path.Name + ", ");
                }
                Console.WriteLine();
            }
        }

        private void GenerateDisjointSets(List<Path<T, TVertexData, TEdgeData>> paths)
        {
            var pairs = GenerateAllPairs(paths);

            foreach (var pair in pairs)
            {
                DisjointPathSets.Add(new HashSet<Path<T, TVertexData, TEdgeData>>(pair));
            }

            for (int currentSize = 2; currentSize < MaxTupleSize; currentSize++)
            {
                var currentSets = DisjointPathSets.Where(s => s.Count == currentSize).ToList();
                var newSets = new List<HashSet<Path<T, TVertexData, TEdgeData>>>();

                foreach (var set in currentSets)
                {
                    foreach (var path in paths)
                    {
                        if (set.All(s => s.IsDisjoint(path)) && !set.Contains(path))
                        {
                            var newSet = new HashSet<Path<T, TVertexData, TEdgeData>>(set) { path };
                            if (!newSets.Any(ns => ns.SetEquals(newSet)))
                            {
                                newSets.Add(newSet);
                            }
                        }
                    }
                }

                DisjointPathSets.AddRange(newSets);
            }
        }

        private List<List<Path<T, TVertexData, TEdgeData>>> GenerateAllPairs(List<Path<T, TVertexData, TEdgeData>> paths)
        {
            var pairs = new List<List<Path<T, TVertexData, TEdgeData>>>();

            for (int i = 0; i < paths.Count; i++)
            {
                for (int j = i + 1; j < paths.Count; j++)
                {
                    if (paths[i].IsDisjoint(paths[j]))
                    {
                        pairs.Add(new List<Path<T, TVertexData, TEdgeData>> { paths[i], paths[j] });
                    }
                }
            }

            return pairs;
        }

    }
}
