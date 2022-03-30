using System.Xml.Linq;

namespace GraphMLWriter.Contracts
{
    public interface INodeSerializer
    {
        XElement SerializeNode(INode node);
    }
}