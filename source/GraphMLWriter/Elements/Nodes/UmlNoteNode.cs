namespace GraphMLWriter.Elements.Nodes
{
    public class UmlNoteNode : Node
    {
        public UmlNoteNode(int nodeNumber) : base(nodeNumber)
        {
        }

        public UmlNoteNode(string text, int nodeNumber) : base(text, nodeNumber)
        {
        }
    }
}