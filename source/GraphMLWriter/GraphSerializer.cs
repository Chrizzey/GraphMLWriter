using System.Drawing;
using System.Xml.Linq;

namespace GraphMLWriter
{
    public class GraphSerializer
    {
        private readonly XDocument _graph;
        private XNamespace _yNamespace;
        private XElement _graphNode;

        private readonly EdgeArrowConverter _edgeArrowConverter;
        private readonly LineStyleConverter _lineStyleConverter;

        public GraphSerializer()
        {
            _edgeArrowConverter = new EdgeArrowConverter();
            _lineStyleConverter = new LineStyleConverter();
            _graph = new XDocument();
            InitializeGraph();
        }

        public virtual XDocument GetDocument()
        {
            return _graph;
        }

        public string GetXml()
        {
            using (var reader = GetDocument().CreateReader())
            {
                reader.MoveToContent();
                return reader.ReadOuterXml();
            }
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

        public void AddGraph(Graph graph)
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

        public virtual void AddNode(Node node)
        {
            XElement umlClassNode = new XElement(_yNamespace + "UMLClassNode");
            XElement geometry = new XElement(_yNamespace + "Geometry",
              new XAttribute("height", node.Height),
              new XAttribute("width", node.Width),
              new XAttribute("x", node.X),
              new XAttribute("y", node.Y));
            umlClassNode.Add(geometry);

            XElement fill = new XElement(_yNamespace + "Fill",
              new XAttribute("color", node.Color),
              new XAttribute("transparent", "false"));
            umlClassNode.Add(fill);

            XElement borderStyle = new XElement(_yNamespace + "BorderStyle",
              new XAttribute("color", node.BorderColor),
              new XAttribute("type", node.BorderStyle),
              new XAttribute("width", node.BorderWidth));
            umlClassNode.Add(borderStyle);

            XElement nodeLabel = new XElement(_yNamespace + "NodeLabel",
              new XAttribute("alignment", "center"),
                 new XAttribute("autoSizePolicy", "content"),
                 new XAttribute("fontFamily", "Dialog"),
                 new XAttribute("fontSize", "13"),
                 new XAttribute("fontStyle", "bold"),
                 new XAttribute("hasBackgroundColor", "false"),
                 new XAttribute("hasLineColor", "false"),
                 new XAttribute("height", "19.92626953125"),
                 new XAttribute("modelName", "custom"),
                 new XAttribute("textColor", "#000000"),
                 new XAttribute("visible", "true"),
                 new XAttribute("width", "38.68994140625"),
                 new XAttribute("x", "30.655029296875"),
                 new XAttribute("y", "3.0"));
            nodeLabel.Add(node.Text);
            XElement labelModel = new XElement(_yNamespace + "LabelModel",
              new XElement(_yNamespace + "SmartNodeLabelModel",
                new XAttribute("distance", "4.0")
                )
              );
            nodeLabel.Add(labelModel);
            XElement modelParameter = new XElement(_yNamespace + "ModelParameter",
              new XElement(_yNamespace + "SmartNodeLabelModelParameter",
              new XAttribute("labelRatioX", "0.0"),
              new XAttribute("labelRatioY", "0.0"),
              new XAttribute("nodeRatioX", "0.0"),
              new XAttribute("nodeRatioY", "-0.03703090122767855"),
              new XAttribute("offsetX", "0.0"),
              new XAttribute("offsetY", "0.0"),
              new XAttribute("upX", "0.0"),
              new XAttribute("upY", "-1.0"))
              );
            nodeLabel.Add(modelParameter);
            umlClassNode.Add(nodeLabel);

            XElement uml = new XElement(_yNamespace + "UML",
              new XAttribute("clipContent", "true"),
              new XAttribute("constraint", ""),
              new XAttribute("omitDetails", "false"),
              new XAttribute("stereotype", ""),
              new XAttribute("use3DEffect", "true"),
              new XElement(_yNamespace + "AttributeLabel"),
              new XElement(_yNamespace + "MethodLabel")
              );
            umlClassNode.Add(uml);

            XElement data = new XElement("data",
              new XAttribute("key", "d6"));
            data.Add(umlClassNode);

            XElement nodeElement = new XElement("node",
              new XAttribute("id", node.Id));
            nodeElement.Add(data);

            _graphNode.Add(nodeElement);
        }

        public virtual void AddEdge(int edgeNumber, string source, string target)
        {
            AddEdge(new Edge(edgeNumber, source, target));
        }

        public virtual void AddEdge(Edge edge)
        {
            XElement edgeElement = new XElement("edge",
              new XAttribute("id", edge.Id),
              new XAttribute("source", edge.Source),
              new XAttribute("target", edge.Target),

              new XElement("data", new XAttribute("key", "d8")),
              new XElement("data", new XAttribute("key", "d9"))
              );

            XElement polyLine = new XElement(_yNamespace + "PolyLineEdge");

            XElement path = new XElement(_yNamespace + "Path",
              new XAttribute("sx", edge.Sx.ToString()),
              new XAttribute("sy", edge.Sy.ToString()),
              new XAttribute("tx", edge.Tx.ToString()),
              new XAttribute("ty", edge.Ty.ToString()));

            foreach (Point p in edge.Points)
            {
                XElement point = new XElement(_yNamespace + "Point",
                  new XAttribute("x", p.X),
                  new XAttribute("y", p.Y)
                  );
                path.Add(point);
            }

            polyLine.Add(path);

            XElement lineStyle = new XElement(_yNamespace + "LineStyle",
              new XAttribute("color", edge.LineProperties.Color),
              new XAttribute("type", _lineStyleConverter.ConvertLineStyle(edge.LineProperties.LineStyle)),
              new XAttribute("width", edge.LineProperties.Width));
            polyLine.Add(lineStyle);

            XElement arrows = new XElement(_yNamespace + "Arrows",
              new XAttribute("source", _edgeArrowConverter.ConvertArrow(edge.SourceArrow)),
              new XAttribute("target", _edgeArrowConverter.ConvertArrow(edge.TargetArrow)));
            polyLine.Add(arrows);

            XElement bendStyle = new XElement(_yNamespace + "BendStyle",
              new XAttribute("smoothed", "false"));
            polyLine.Add(bendStyle);

            XElement d10 = new XElement("data", new XAttribute("key", "d10"));
            d10.Add(polyLine);
            edgeElement.Add(d10);
            _graphNode.Add(edgeElement);
        }
    }
}
