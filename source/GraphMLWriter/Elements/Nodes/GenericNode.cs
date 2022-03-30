using System.Collections.Generic;
using GraphMLWriter.Elements.NodeFactories;

namespace GraphMLWriter.Elements.Nodes
{
    public class GenericNode : Node
    {
        public GenericNode(int nodeNumber) : base(nodeNumber)
        {
        }

        public GenericNode(string text, int nodeNumber) : base(text, nodeNumber)
        {
        }

        public string Configuration { get; set; }

        public List<StyleProperty> StyleProperties { get; } = new List<StyleProperty>();
    }
}