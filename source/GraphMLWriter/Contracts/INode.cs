using System.Drawing;
using GraphMLWriter.Elements.NodeFactories;

namespace GraphMLWriter.Contracts
{
    public interface INode : IShape
    {
        string Id { get; }

        string Text { get; set; }
        INodeLabel NodeLabel { get; set; }

        void FitText();
    }
}