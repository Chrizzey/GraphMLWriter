namespace GraphMLWriter
{
    public abstract class GraphMlElement
    {
        public virtual string Id { get; }

        protected GraphMlElement(string id)
        {
            Id = id;
        }
    }
}