using GraphMLWriter.Elements.NodeFactories;

namespace GraphMLWriter.Contracts
{
    public interface IGraphMlElement
    {
        string Id { get; }
    }

    public interface INode : IGraphMlElement, IShape
    {
        string Text { get; set; }

        INodeLabel NodeLabel { get; set; }

        void FitText();
    }
}