using System;
using System.Linq;
using System.Xml.Linq;
using GraphMLWriter.Contracts;
using GraphMLWriter.Elements.Nodes;

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

            if(node.StyleProperties.Any())
                genericNode.Add(StyleProperties(node));

            var data = new XElement("data",
                new XAttribute("key", "d6"));
            data.Add(genericNode);

            var d5 = new XElement("data",
                new XAttribute("key", "d5"));

            var nodeElement = new XElement("node",
                new XAttribute("id", node.Id));
            nodeElement.Add(data);
            nodeElement.Add(d5);

            return nodeElement;
        }

        private XElement StyleProperties(GenericNode node)
        {
            var styleProperties = new XElement(YNamespace + "StyleProperties");

            foreach (var styleProperty in node.StyleProperties)
            {
                styleProperties.Add(new XElement(YNamespace + "Property",
                    new XAttribute("class", styleProperty.ClassName),
                    new XAttribute("name", styleProperty.Name),
                    new XAttribute("value", styleProperty.Value)));
            }

            return styleProperties;
        }
    }
}