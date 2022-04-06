using System;
using System.Collections.Generic;
using System.Text;

namespace GraphMLWriter.Elements.Nodes
{
    public class UmlClassNode : Node
    {
        public UmlClassNode(int nodeNumber) : base(nodeNumber)
        {
        }

        public UmlClassNode(string text, int nodeNumber) : base(text, nodeNumber)
        {
        }

        public bool ClipContent { get; set; } = true;

        public string Constraint { get; set; } = string.Empty;

        public bool HasDetailsColor { get; set; } = false;

        public bool OmitDetails { get; set; } = false;

        public string Stereotype { get; set; } = string.Empty;

        public bool Use3dEffect { get; set; } = false;

        public string AttributeText { get; set; }

        public string MethodText { get; set; }
    }

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
