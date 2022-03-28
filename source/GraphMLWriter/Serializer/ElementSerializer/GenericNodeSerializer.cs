using System;
using System.Xml.Linq;
using GraphMLWriter.Contracts;

namespace GraphMLWriter.Serializer.ElementSerializer
{
    public class GenericNodeSerializer : NodeSerializer
    {
        public override XElement SerializeNode(INode node)
        {
            return node switch
            {
                null => throw new ArgumentNullException(),
                GenericNode genericNode => SerializeNode(genericNode),
                _ => throw new ArgumentException($"Cannot serialize node of type {node.GetType().FullName}")
            };
        }

        public XElement SerializeNode(GenericNode node)
        {
            var genericNode = new XElement(YNamespace + "GenericNode",
                new XAttribute("configuration", node.Configuration));

            genericNode.Add(Geometry(node));
            genericNode.Add(Fill(node));
            genericNode.Add(BorderStyle(node));
            genericNode.Add(NodeLabel(node));

            XElement data = new XElement("data",
                new XAttribute("key", "d6"));
            data.Add(genericNode);

            XElement d5 = new XElement("data",
                new XAttribute("key", "d5"));

            XElement nodeElement = new XElement("node",
                new XAttribute("id", node.Id));
            nodeElement.Add(data);
            nodeElement.Add(d5);

            return nodeElement;
        }
    }
}