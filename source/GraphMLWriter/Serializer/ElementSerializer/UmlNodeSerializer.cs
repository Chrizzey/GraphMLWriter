using System.Xml.Linq;
using GraphMLWriter.Contracts;

namespace GraphMLWriter.Serializer.ElementSerializer
{
    public class UmlNodeSerializer : NodeSerializer
    {
        public XElement SerializeNode(INode node)
        {
            XElement umlClassNode = new XElement(YNamespace + "UMLClassNode");
            
            umlClassNode.Add(Geometry(node));

            var fill = Fill(node);
            umlClassNode.Add(fill);

            var borderStyle = BorderStyle(node);
            umlClassNode.Add(borderStyle);

            var nodeLabel = NodeLabel(node);
            umlClassNode.Add(nodeLabel);

            XElement uml = new XElement(YNamespace + "UML",
              new XAttribute("clipContent", "true"),
              new XAttribute("constraint", ""),
              new XAttribute("omitDetails", "false"),
              new XAttribute("stereotype", ""),
              new XAttribute("use3DEffect", "true"),
              new XElement(YNamespace + "AttributeLabel"),
              new XElement(YNamespace + "MethodLabel")
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
