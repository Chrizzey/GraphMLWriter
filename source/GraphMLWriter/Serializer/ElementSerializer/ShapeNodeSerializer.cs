using System;
using System.Xml.Linq;
using GraphMLWriter.Contracts;
using GraphMLWriter.Elements.Nodes;

namespace GraphMLWriter.Serializer.ElementSerializer
{
    public class ShapeNodeSerializer : NodeSerializer
    {
        public override XElement SerializeNode(INode node)
        {
            return node switch
            {
                null => throw new ArgumentNullException(),
                ShapeNode genericNode => SerializeNode(genericNode),
                _ => throw new ArgumentException($"Cannot serialize node of type {node.GetType().FullName}")
            };
        }

        public virtual XElement SerializeNode(ShapeNode node)
        {
            var shapeNode = new XElement(YNamespace + "ShapeNode");

            shapeNode.Add(Geometry(node));
            shapeNode.Add(Fill(node));
            shapeNode.Add(BorderStyle(node));
            shapeNode.Add(NodeLabel(node));

            var shape = new XElement(YNamespace + "Shape",
                new XAttribute("type", node.ShapeType));
            shapeNode.Add(shape);

            var nodeElement = new XElement("node",
                new XAttribute("id", node.Id));
            nodeElement.Add(new XElement("data", 
                new XAttribute("key", "d5")));
            nodeElement.Add(new XElement("data",
                new XAttribute("key", "d6"),
                shapeNode));

            return nodeElement;
        }
    }
}
