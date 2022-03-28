using System.Xml.Linq;
using GraphMLWriter.Contracts;

namespace GraphMLWriter.Serializer.ElementSerializer
{
    public interface INodeSerializer
    {
        XElement SerializeNode(INode node);
    }
}