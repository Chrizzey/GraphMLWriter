using GraphMLWriter.Contracts;
using GraphMLWriter.Elements.Nodes;
using GraphMLWriter.Serializer.ElementSerializer;

namespace GraphMLWriter.Serializer
{
    public class NodeSerializerProvider
    {
        private readonly GenericNodeSerializer _genericNodeSerializer;
        private readonly UmlNodeSerializer _umlNodeSerializer;
        private readonly ShapeNodeSerializer _shapeNodeSerializer;

        public NodeSerializerProvider(GenericNodeSerializer genericNodeSerializer, UmlNodeSerializer umlNodeSerializer, ShapeNodeSerializer shapeNodeSerializer)
        {
            _genericNodeSerializer = genericNodeSerializer;
            _umlNodeSerializer = umlNodeSerializer;
            _shapeNodeSerializer = shapeNodeSerializer;
        }
        
        public INodeSerializer GetSerializerForNode(INode node)
        {
            return node switch
            {
                GenericNode _ => _genericNodeSerializer,
                ShapeNode _ => _shapeNodeSerializer,
                _ => _umlNodeSerializer
            };
        }
    }
}
