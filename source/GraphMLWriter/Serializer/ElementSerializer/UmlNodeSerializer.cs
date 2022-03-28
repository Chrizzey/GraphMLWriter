using System.Xml.Linq;
using GraphMLWriter.Contracts;

namespace GraphMLWriter.Serializer.ElementSerializer
{
    public class UmlNodeSerializer : NodeSerializer
    {
        public override XElement SerializeNode(INode node)
        {
            XElement umlClassNode = new XElement(YNamespace + "UMLClassNode");
            
            umlClassNode.Add(Geometry(node));
            umlClassNode.Add(Fill(node));
            umlClassNode.Add(BorderStyle(node));
            umlClassNode.Add(NodeLabel(node));

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
