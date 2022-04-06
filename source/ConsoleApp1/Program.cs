using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
                    var node = (INode)x.Invoke(new FlowChartNodeFactory(), new object[] { nodeNumber++, x.Name });
                    if (node is null)
                        throw new NotSupportedException(x.Name);

                    switch (nodeNumber % 3)
                    {
                        case 0:
                            node.SetLocation(100, y).SetColor(Color.Orange);
                            break;
                        case 1:
                            node.SetLocation(250,y).SetColor(Color.Aqua);
                            break;
                        case 2:
                            node.SetLocation(400,y).SetColor(Color.Sienna);
                            break;
                    }

                    if (nodeNumber % 3 == 1)
                        y += 100;

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


                    switch (nodeNumber % 3)
                    {
                        case 0:
                            node.SetLocation(100, y).SetColor(Color.Chartreuse);
                            break;
                        case 1:
                            node.SetLocation(250, y).SetColor(Color.MediumTurquoise);
                            break;
                        case 2:
                            node.SetLocation(400, y).SetColor(Color.MediumPurple);
                            break;
                    }

                    if (nodeNumber % 3 == 1)
                        y += 100;


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
            BuildExampleUmlClassDiagram(graph);

            var serializer = new GraphSerializer();
            serializer.Serialize(graph, @"E:\test.graphml");
        }

        private static void BuildSampleErDiagram(Graph graph)
        {
            var nodeCount = graph.AllNodes.Count;
            var factory = new EntityRelationshipNodeFactory();

            var employee = factory.CreateSmallEntity(nodeCount++, "Employee").SetLocation(500, 0);
            var idAttribute = factory.CreatePrimaryKeyAttribute(nodeCount++, "ID").SetLocation(450, 50);
            var nameAttribute = factory.CreateAttribute(nodeCount++, "Name").SetLocation(550, 50);

            var project = factory.CreateSmallEntity(nodeCount++, "Project").SetLocation(800, 0);
            var projectCodeAttribute = factory.CreateAttribute(nodeCount++, "ProjectCode").SetLocation(790, 50).SetSize(100, 30);
            var managesRelation = factory.CreateRelationship(nodeCount, "manages").SetLocation(650, 0);

            graph.AddNodes(employee, idAttribute, nameAttribute, project, projectCodeAttribute, managesRelation);

            var edgeCount = graph.AllEdges.Count;
            graph.AddEdges(
                new Edge(edgeCount++, employee, idAttribute) { TargetArrow = EdgeArrow.None },
                new Edge(edgeCount++, employee, nameAttribute) { TargetArrow = EdgeArrow.None },
                new Edge(edgeCount++, project, projectCodeAttribute) { TargetArrow = EdgeArrow.None },
                new Edge(edgeCount++, employee, managesRelation) { TargetArrow = EdgeArrow.None },
                new Edge(edgeCount, project, managesRelation) { TargetArrow = EdgeArrow.None }
            );
        }

        private static void BuildExampleUmlClassDiagram(Graph graph)
        {
            var factory = new UmlNodeFactory();
            var nodeCount = graph.AllNodes.Count;
            var foo = factory.CreateClass(nodeCount++, "Foo");
            foo.AttributeText = "- bar: int\r\n- fooBar: double";
            foo.MethodText = "+ Foo()\r\n+ GetFooBar(): double\r\n+ SetBar(value: int): void";
            graph.AddNode(foo);

            var objectNode = factory.CreateClass(nodeCount, "Object");

            var methods = new List<string>();
            foreach (var method in typeof(object).GetMethods())
            {
                var parameters = method.GetParameters().Select(x => $"{x.Name}: {x.ParameterType.Name}");
                methods.Add($"+ {method.Name}({string.Join(", ", parameters)}): {method.ReturnType.Name}");
            }
            objectNode.MethodText = string.Join(Environment.NewLine, methods);

            graph.AddNode(objectNode);

            graph.AddEdge(new Edge(graph.GetNextEdgeId(), foo, objectNode)
            {
                TargetArrow = EdgeArrow.WhiteDelta
            });
        }
    }
}
