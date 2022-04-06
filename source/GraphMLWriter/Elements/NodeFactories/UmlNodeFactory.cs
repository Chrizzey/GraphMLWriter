using System;
using GraphMLWriter.Contracts;
using GraphMLWriter.Elements.Nodes;

namespace GraphMLWriter.Elements.NodeFactories
{
    public class UmlNodeFactory
    {
        public UmlClassNode CreateClass(int nodeNumber, string text = null)
        {
            return new UmlClassNode(text, nodeNumber);
        }

        public UmlNoteNode CreateNote(int nodeNumber, string text = null)
        {
            return new UmlNoteNode(text, nodeNumber);
        }

        public ShapeNode CreateUseCase(int nodeNumber, string text = null)
        {
            return new ShapeNode(text, nodeNumber)
            {
                ShapeType = "ellipse"
            };
        }

        public INode CreateActor(int nodeNumber, string text = null)
        {
            throw new NotImplementedException();
        }
    }
}
