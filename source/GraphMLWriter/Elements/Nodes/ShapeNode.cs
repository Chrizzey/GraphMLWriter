namespace GraphMLWriter.Elements.Nodes
{
    public class ShapeNode : Node
    {
        public ShapeNode(int nodeNumber) : base(nodeNumber)
        {
            InitializeNode();
        }

        public ShapeNode(string text, int nodeNumber) : base(text, nodeNumber)
        {
            InitializeNode();
        }

        private void InitializeNode()
        {
            Color = "#FFCC00";
            Height = 30d;
            Width = 30d;
        }

        public string ShapeType { get; set; }
    }
}
