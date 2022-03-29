using System.Xml.Linq;
using GraphMLWriter.Contracts;
using GraphMLWriter.Elements;
using GraphMLWriter.Elements.Edges;
using GraphMLWriter.Serializer.ElementSerializer;

namespace GraphMLWriter.Serializer
{
    public class GraphSerializer
    {
        private readonly XDocument _graph;
        private readonly EdgeSerializer _edgeSerializer;
        private readonly NodeSerializerProvider _nodeSerializerProvider;
        private XNamespace _yNamespace;
        private XElement _graphNode;

        public GraphSerializer()
        {
            _graph = new XDocument();
            _edgeSerializer = new EdgeSerializer();
            _nodeSerializerProvider = new NodeSerializerProvider(new GenericNodeSerializer(), new UmlNodeSerializer());
            InitializeGraph();
        }

        public void Serialize(Graph graph, string fileName)
        {
            AddGraph(graph);
            GetDocument().Save(fileName);
        }

        private void InitializeGraph()
        {
            _yNamespace = "http://www.yworks.com/xml/graphml";
            XNamespace java = "http://www.yworks.com/xml/yfiles-common/1.0/java";
            XNamespace sys = "http://www.yworks.com/xml/yfiles-common/markup/primitives/2.0";
            XNamespace x = "http://www.yworks.com/xml/yfiles-common/markup/2.0";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace yed = "http://www.yworks.com/xml/yed/3";

            XElement root = new XElement("graphml",
              new XAttribute(XNamespace.Xmlns + "y", _yNamespace),
              new XAttribute(XNamespace.Xmlns + "java", java),
              new XAttribute(XNamespace.Xmlns + "sys", sys),
              new XAttribute(XNamespace.Xmlns + "x", x),
              new XAttribute(XNamespace.Xmlns + "xsi", xsi),
              new XAttribute(XNamespace.Xmlns + "yed", yed)
              );

            AddKeysToRoot(root);

            _graphNode = new XElement("graph",
              new XAttribute("edgedefault", "directed"),
              new XAttribute("id", "G"));
            root.Add(_graphNode);

            XElement data = new XElement("data",
              new XAttribute("key", "d0"));
            _graphNode.Add(data);

            _graph.Add(root);
        }

        private void AddGraph(Graph graph)
        {
            foreach (var node in graph.AllNodes)
            {
                AddNode(node);
            }

            foreach (var edge in graph.AllEdges)
            {
                AddEdge(edge);
            }
        }

        private XDocument GetDocument()
        {
            return _graph;
        }

        private static void AddKeysToRoot(XContainer root)
        {
            root.Add(new XElement("key",
              new XAttribute("attr.name", "Description"),
              new XAttribute("attr.type", "string"),
              new XAttribute("for", "graph"),
              new XAttribute("id", "d0")));

            root.Add(new XElement("key",
              new XAttribute("for", "port"),
              new XAttribute("id", "d1"),
              new XAttribute("yfiles.type", "portgraphics")
              ));
            root.Add(new XElement("key",
              new XAttribute("for", "port"),
              new XAttribute("id", "d2"),
              new XAttribute("yfiles.type", "portgeometry")
              ));
            root.Add(new XElement("key",
              new XAttribute("for", "port"),
              new XAttribute("id", "d3"),
              new XAttribute("yfiles.type", "portuserdata")
              ));

            root.Add(new XElement("key",
              new XAttribute("attr.name", "url"),
              new XAttribute("attr.type", "string"),
              new XAttribute("for", "node"),
              new XAttribute("id", "d4")
              ));

            root.Add(new XElement("key",
              new XAttribute("attr.name", "description"),
              new XAttribute("attr.type", "string"),
              new XAttribute("for", "node"),
              new XAttribute("id", "d5")
              ));

            root.Add(new XElement("key",
              new XAttribute("for", "node"),
              new XAttribute("id", "d6"),
              new XAttribute("yfiles.type", "nodegraphics")
              ));
            root.Add(new XElement("key",
              new XAttribute("for", "graphml"),
              new XAttribute("id", "d7"),
              new XAttribute("yfiles.type", "resources")
              ));
            root.Add(new XElement("key",
              new XAttribute("attr.name", "url"),
              new XAttribute("attr.type", "string"),
              new XAttribute("for", "edge"),
              new XAttribute("id", "d8")
              ));
            root.Add(new XElement("key",
              new XAttribute("attr.name", "description"),
              new XAttribute("attr.type", "string"),
              new XAttribute("for", "edge"),
              new XAttribute("id", "d9")
              ));
            root.Add(new XElement("key",
              new XAttribute("for", "edge"),
              new XAttribute("id", "d10"),
              new XAttribute("yfiles.type", "edgegraphics")
              ));
        }

        public virtual void AddNode(INode node)
        {
            var serializer = _nodeSerializerProvider.GetSerializerForNode(node);
            var nodeElement = serializer.SerializeNode(node);
            _graphNode.Add(nodeElement);
        }

        public virtual void AddEdge(int edgeNumber, string source, string target)
        {
            AddEdge(new Edge(edgeNumber, source, target));
        }

        public virtual void AddEdge(Edge edge)
        {
            var edgeElement = _edgeSerializer.SerializeEdge(edge);

            _graphNode.Add(edgeElement);
        }
    }
}
