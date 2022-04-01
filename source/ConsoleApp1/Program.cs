using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using GraphMLWriter.Contracts;
using GraphMLWriter.Elements;
using GraphMLWriter.Elements.Edges;
using GraphMLWriter.Elements.NodeFactories;
using GraphMLWriter.Elements.Nodes;
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
                Y = 80,
                Width = 100
            };
            n1.SetColor(Color.DarkRed);
            var n2 = new Node("Node B", 1)
            {
                Width = 100
            };
            n2.SetColor(Color.Blue);
            var n3 = new Node("Node C", 2)
            {
                Y = 160,
                Width = 100
            };
            n3.SetColor(Color.Green);
            
            var graph = new Graph();
            graph.AddNodes(n1, n2, n3);

            var nodeNumber = 3;
            var y = 200;

            var nodes = typeof(FlowChartNodeFactory)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetParameters().Length == 2
                            && x.GetParameters()[0].ParameterType == typeof(int)
                            && x.GetParameters()[1].ParameterType == typeof(string))
                .Select(x =>
                {
                    var node = (INode) x.Invoke(new FlowChartNodeFactory(), new object[] {nodeNumber++, x.Name});
                    if (node is null)
                        throw new NotSupportedException(x.Name);
                    node.Y = y;
                    if (nodeNumber % 3 == 1)
                        y += 100;

                    switch (nodeNumber % 3)
                    {
                        case 0:
                            node.X = 100;
                            node.SetColor(Color.Orange);
                            break;
                        case 1:
                            node.X = 250;
                            node.SetColor(Color.Aqua);
                            break;
                        case 2:
                            node.X = 400;
                            node.SetColor(Color.Sienna);
                            break;
                    }

                    return node;
                });

            graph.AddNodes(nodes);

            nodes = typeof(ShapeNodeFactory)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetParameters().Length == 2
                            && x.GetParameters()[0].ParameterType == typeof(int)
                            && x.GetParameters()[1].ParameterType == typeof(string))
                .Select(x =>
                {
                    var node = (INode)x.Invoke(new ShapeNodeFactory(), new object[] { nodeNumber++, x.Name });
                    if (node is null)
                        throw new NotSupportedException(x.Name);
                    node.Y = y;
                    if (nodeNumber % 3 == 1)
                        y += 100;

                    switch (nodeNumber % 3)
                    {
                        case 0:
                            node.X = 100;
                            node.SetColor(Color.Chartreuse);
                            break;
                        case 1:
                            node.X = 250;
                            node.SetColor(Color.MediumTurquoise);
                            break;
                        case 2:
                            node.X = 400;
                            node.SetColor(Color.MediumPurple);
                            break;
                    }

                    return node;
                });

            graph.AddNodes(nodes);

            graph.AddEdge(new Edge(0, n1, n2)
            {
                TargetArrow = EdgeArrow.WhiteDelta,
            });
            graph.AddEdge(new Edge(1, n1, n3)
            {
                TargetArrow = EdgeArrow.Diamond,
            });

            BuildSampleErDiagram(graph);

            var serializer = new GraphSerializer();
            serializer.Serialize(graph, @"E:\test.graphml");
        }

        private static void BuildSampleErDiagram(Graph graph)
        {
            var nodeCount = graph.AllNodes.Count;
            var factory = new EntityRelationshipNodeFactory();

            var employee = factory.CreateSmallEntity(nodeCount++, "Employee").SetLocation(500,0);
            var idAttribute = factory.CreatePrimaryKeyAttribute(nodeCount++, "ID").SetLocation(450,50);
            var nameAttribute = factory.CreateAttribute(nodeCount++, "Name").SetLocation(550,50);

            var project = factory.CreateSmallEntity(nodeCount++, "Project").SetLocation(800,0);
            var projectCodeAttribute = factory.CreateAttribute(nodeCount++, "ProjectCode").SetLocation(790,50).SetSize(100,30);
            var managesRelation = factory.CreateRelationship(nodeCount, "manages").SetLocation(650,0);

            graph.AddNodes(employee, idAttribute, nameAttribute, project, projectCodeAttribute, managesRelation);

            var edgeCount = graph.AllEdges.Count;
            graph.AddEdges(
                new Edge(edgeCount++, employee, idAttribute){ TargetArrow = EdgeArrow.None},
                new Edge(edgeCount++, employee, nameAttribute) { TargetArrow = EdgeArrow.None },
                new Edge(edgeCount++, project, projectCodeAttribute) { TargetArrow = EdgeArrow.None },
                new Edge(edgeCount++, employee, managesRelation) { TargetArrow = EdgeArrow.None },
                new Edge(edgeCount, project, managesRelation) { TargetArrow = EdgeArrow.None }
            );
        }
    }
}
