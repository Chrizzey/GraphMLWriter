using System.Xml.Linq;
using GraphMLWriter.Contracts;
using GraphMLWriter.Elements.Nodes;

namespace GraphMLWriter.Serializer.ElementSerializer
{
    public class UmlNodeSerializer : NodeSerializer
    {
        private readonly ShapeNodeSerializer _shapeNodeSerializer;

        public UmlNodeSerializer(ShapeNodeSerializer shapeNodeSerializer)
        {
            _shapeNodeSerializer = shapeNodeSerializer;
        }

        public override XElement SerializeNode(INode node)
        {
            return node switch
            {
                UmlClassNode classNode => SerializeClassNode(classNode),
                UmlNoteNode noteNode => SerializeNoteNode(noteNode),
                ShapeNode shapeNode => _shapeNodeSerializer.SerializeNode(shapeNode),
                _ => SerializeOtherNode(node)
            };
        }

        private XElement SerializeOtherNode(INode node)
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

        private XElement SerializeClassNode(UmlClassNode classNode)
        {
            var xmlClassElement = new XElement(YNamespace + "UMLClassNode");
            xmlClassElement.Add(Geometry(classNode));
            xmlClassElement.Add(Fill(classNode));
            xmlClassElement.Add(BorderStyle(classNode));
            xmlClassElement.Add(NodeLabel(classNode));

            var uml = new XElement(YNamespace + "UML",
                new XAttribute("clipContent", classNode.ClipContent),
                new XAttribute("constraint", classNode.Constraint),
                new XAttribute("hasDetailsColor", classNode.HasDetailsColor),
                new XAttribute("omitDetails", classNode.OmitDetails),
                new XAttribute("stereotype", classNode.Stereotype),
                new XAttribute("use3DEffect", classNode.Use3dEffect)
            );
            uml.Add(new XElement(YNamespace+ "AttributeLabel", CreateXmlSpacePreserveAttribute(), classNode.AttributeText));
            uml.Add(new XElement(YNamespace+ "MethodLabel", CreateXmlSpacePreserveAttribute(), classNode.MethodText));
            
            xmlClassElement.Add(uml);

            return new XElement("node",
                new XAttribute("id", classNode.Id),
                new XElement("data", new XAttribute("key", "d4"), CreateXmlSpacePreserveAttribute()),
                new XElement("data", new XAttribute("key", "d5")),
                new XElement("data", new XAttribute("key", "d6"), xmlClassElement)
                );
        }

        private XElement SerializeNoteNode(INode noteNode)
        {
            var noteElement = new XElement(YNamespace + "UMLClassNode");
            noteElement.Add(Geometry(noteNode));
            noteElement.Add(Fill(noteNode));
            noteElement.Add(BorderStyle(noteNode));
            noteElement.Add(NodeLabel(noteNode));
            
            return new XElement("node",
                new XAttribute("id", noteNode.Id),
                new XElement("data", new XAttribute("key", "d4"), CreateXmlSpacePreserveAttribute()),
                new XElement("data", new XAttribute("key", "d6"), noteElement)
            );
        }

        private static XAttribute CreateXmlSpacePreserveAttribute()
        {
            return new XAttribute(((XNamespace) "xml") + "space", "preserve");
        }
    }
}
