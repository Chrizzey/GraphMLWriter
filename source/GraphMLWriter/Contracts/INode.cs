namespace GraphMLWriter.Contracts
{
    public interface INode : IShape
    {
        string Text { get; set; }
        
        void FitText();
    }
}