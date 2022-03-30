using System;
using GraphMLWriter.Elements;
using GraphMLWriter.Elements.Edges;
using GraphMLWriter.Elements.Nodes;
using GraphMLWriter.Elements.Shapes;
using GraphMLWriter.Serializer;
using GraphMLWriter.Serializer.ElementSerializer;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new Node("Node A", 0)
            {
                Y = 80,
                Width = 100
            };
            var n2 = new Node("Node B", 1)
            {
                Width = 100
            };
            var n3 = new Node("Node C", 2)
            {
                Y = 160,
                Width = 100
            };

            
            var graph = new Graph();
            graph.AddNodes(n1, n2, n3);

            graph.AddEdge(new Edge(0, n1, n2)
            {
                TargetArrow = EdgeArrow.WhiteDelta,
            });
            graph.AddEdge(new Edge(1, n1, n3)
            {
                TargetArrow = EdgeArrow.Diamond,
            });

            var serializer = new GraphSerializer();
            serializer.Serialize(graph, @"E:\test.graphml");
        }
    }
}
