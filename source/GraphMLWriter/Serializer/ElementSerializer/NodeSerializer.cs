using System.Xml.Linq;
using GraphMLWriter.Contracts;

namespace GraphMLWriter.Serializer.ElementSerializer
{
    public class NodeSerializer
    {
        private readonly XNamespace _yNamespace;

        public NodeSerializer()
        {
            _yNamespace = "http://www.yworks.com/xml/graphml";
        }

        public XElement SerializeNode(INode node)
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

            return nodeElement;
        }
    }
}
