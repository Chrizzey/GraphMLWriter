using System.Diagnostics.CodeAnalysis;
using GraphMLWriter.Elements.Nodes;

namespace GraphMLWriter.Elements.NodeFactories
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class FlowChartNodeFactory
    {
        public virtual GenericNode CreateStart1(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.start1",
                Width = 80
            };
        }

        public virtual GenericNode CreateStart2(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.start2",
                Width = 80
            };
        }

        public virtual GenericNode CreateTerminator(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.terminator",
                Width = 80
            };
        }

        public virtual GenericNode CreateProcess(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.process",
                Width = 80
            };
        }

        public virtual GenericNode CreatePredefinedProcess(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.predefinedProcess",
                Width = 80
            };
        }

        public virtual GenericNode CreateDecision(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.decision",
                Width = 80
            };
        }

        public virtual GenericNode CreateLoopLimit(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.loopLimit",
                Width = 80
            };
        }

        public virtual GenericNode CreateLoopLimitEnd(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.loopLimitEnd",
                Width = 80
            };
        }

        public virtual GenericNode CreateDocument(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.document",
                Width = 80
            };
        }

        public virtual GenericNode CreateData(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.data",
                Width = 80
            };
        }

        public virtual GenericNode CreateDirectData(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.directData",
                Width = 80
            };
        }

        public virtual GenericNode CreateStoredData(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.storedData",
                Width = 80
            };
        }

        public virtual GenericNode CreateSequentialData(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.sequentialData",
                Width = 80
            };
        }

        public virtual GenericNode CreateDatabase(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.dataBase",
                Width = 80
            };
        }

        public virtual GenericNode CreateInternalStorage(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.internalStorage",
                Width = 80
            };
        }

        public virtual GenericNode CreateManualInput(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.manualInput",
                Width = 80
            };
        }

        public virtual GenericNode CreateCard(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.card",
                Width = 80
            };
        }

        public virtual GenericNode CreatePaperType(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.paperType",
                Width = 80
            };
        }

        public virtual GenericNode CreateCloud(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.cloud",
                Width = 80
            };
        }

        public virtual GenericNode CreateDelay(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.delay",
                Width = 80
            };
        }

        public virtual GenericNode CreateDisplay(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.display",
                Width = 80
            };
        }

        public virtual GenericNode CreateManualOperation(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.manualOperation",
                Width = 80
            };
        }

        public virtual GenericNode CreatePreparation(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.preparation",
                Width = 80
            };
        }

        public virtual GenericNode CreateOnPageReference(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.onPageReference",
                Width = 80
            };
        }

        public virtual GenericNode CreateOffPageReference(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.offPageReference",
                Width = 80
            };
        }

        public virtual GenericNode CreateUserMessage(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.userMessage",
                Width = 80
            };
        }

        public virtual GenericNode CreateNetworkMessage(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.networkMessage",
                Width = 80
            };
        }

        public virtual GenericNode CreateAnnotation(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.annotation",
                Width = 80
            };
        }
    }
}