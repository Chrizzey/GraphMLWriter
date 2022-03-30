using GraphMLWriter.Contracts;
using GraphMLWriter.Elements.Nodes;
using GraphMLWriter.Serializer.ElementSerializer;

namespace GraphMLWriter.Serializer
{
    public class NodeSerializerProvider
    {
        private readonly GenericNodeSerializer _genericNodeSerializer;
        private readonly UmlNodeSerializer _umlNodeSerializer;

        public NodeSerializerProvider(GenericNodeSerializer genericNodeSerializer, UmlNodeSerializer umlNodeSerializer)
        {
            _genericNodeSerializer = genericNodeSerializer;
            _umlNodeSerializer = umlNodeSerializer;
        }
        
        public INodeSerializer GetSerializerForNode(INode node)
        {
            if (node is GenericNode)
            {
                return _genericNodeSerializer;
            }

            return _umlNodeSerializer;
        }
    }
}
