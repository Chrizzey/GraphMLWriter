using System.Drawing;
using GraphMLWriter.Elements;
using GraphMLWriter.Elements.Edges;
using GraphMLWriter.Elements.Shapes;
using GraphMLWriter.Serializer;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new Node("Node A", 0)
            {
                X = 0,
                Y = 0,
                Width = 80
            };

            var n2 = new Node("Node B", 1)
            {
                X = 200,
                Y = 0,
                Width = 80,
                Color = "#ffcc00"
            };

            var n3 = new Node("Node C", 2)
            {
                X = 0,
                Y = 80,
                Width = 80
            };

            var graph = new Graph();

            graph.AddNodes(n1, n2, n3);

            graph.AddEdge(new Edge(0, n1, n2)
            {
                TargetArrow = EdgeArrow.WhiteDelta,
                LineProperties =
                {
                    Color = "#777777",
                    Width = 3d
                }
            });

            graph.AddEdge(new Edge(1, n1, n3)
            {
                TargetArrow = EdgeArrow.WhiteDiamond,
                Points =
                {
                    new Point(-40, 15),
                    new Point(-40, 95)
                }
            });

            var serializer = new GraphSerializer();
            serializer.AddGraph(graph);
            serializer.GetDocument().Save(@"E:\test.graphml");

        }
    }
}
