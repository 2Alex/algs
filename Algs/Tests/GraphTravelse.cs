using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Algs.Tests
{
    [TestFixture]
    public class GraphTravelseTest
    {
        [Test]
        public void Test1()
        {
            var graph = new List<List<int>>
            {
                new List<int>{1, 2},
                new List<int>{0},
                new List<int>{0,3},
                new List<int>{2},
            };
            var result = GraphTravelse.Travelse(graph);
            Assert.That(result, Is.EqualTo("0123"));
        }

        [Test]
        public void Test2()
        {
            var graph = new List<List<int>>
            {
                new List<int>{1, 2},
                new List<int>{0,3},
                new List<int>{0,3},
                new List<int>{1, 2},
            };
            var result = GraphTravelse.Travelse(graph);
            Assert.That(result, Is.EqualTo("0123"));
        }

        [Test]
        public void Test3()
        {
            var graph = new List<List<int>>
            {
                new List<int>{1, 2},
                new List<int>{0,3},
                new List<int>{0,3},
                new List<int>{1, 2, 4, 5},
                new List<int>{3,6},
                new List<int>{3,6},
                new List<int>{4,5},
            };
            var result = GraphTravelse.Travelse(graph);
            Assert.That(result, Is.EqualTo("0123456"));
        }
    }

    public static class GraphTravelse
    {        
        public static string Travelse(List<List<int>> graph)
        {
            var visited = new HashSet<int>();
            var planned = new HashSet<int>();            
            var candidates = new Queue<int>();

            candidates.Enqueue(0);
            planned.Add(0);
            var resultBuilder = new StringBuilder();
            while (candidates.Count > 0)
            {
                var currentVisited = candidates.Dequeue();
                planned.Remove(currentVisited);
                visited.Add(currentVisited);

                resultBuilder.Append(currentVisited);

                foreach (var vertex in graph[currentVisited])
                {
                    if (!visited.Contains(vertex) && !planned.Contains(vertex))
                    {
                        candidates.Enqueue(vertex);
                        planned.Add(vertex);
                    }
                }

            }
            return resultBuilder.ToString();
        }
    }
}