using System.Drawing;

namespace GraphMLWriter.Contracts
{
    public interface INode : IShape
    {
        string Id { get; }

        string Text { get; set; }
        
        void FitText();

        void SetColor(Color color);
    }
}