using GraphMLWriter.Contracts;

namespace GraphMLWriter.Elements
{
    public abstract class GraphMlElement : IGraphMlElement
    {
        public virtual string Id { get; }

        protected GraphMlElement(string id)
        {
            Id = id;
        }

    }
}