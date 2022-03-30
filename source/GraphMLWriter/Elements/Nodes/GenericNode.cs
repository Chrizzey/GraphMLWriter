namespace GraphMLWriter.Elements.Nodes
{
    public class GenericNode : Node
    {
        public GenericNode(int nodeNumber) : base(nodeNumber)
        {
        }

        public GenericNode(string text, int nodeNumber) : base(text, nodeNumber)
        {
        }

        public string Configuration { get; set; }

        public static GenericNode CreateStart1(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.start1",
                Width = 80
            };
        }

        public static GenericNode CreateStart2(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.start2",
                Width = 80
            };
        }

        public static GenericNode CreateTerminator(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.terminator",
                Width = 80
            };
        }

        public static GenericNode CreateProcess(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.process",
                Width = 80
            };
        }

        public static GenericNode CreatePredefinedProcess(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.predefinedProcess",
                Width = 80
            };
        }

        public static GenericNode CreateDecision(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.decision",
                Width = 80
            };
        }

        public static GenericNode CreateLoopLimit(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.loopLimit",
                Width = 80
            };
        }

        public static GenericNode CreateLoopLimitEnd(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.loopLimitEnd",
                Width = 80
            };
        }

        public static GenericNode CreateDocument(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.document",
                Width = 80
            };
        }

        public static GenericNode CreateData(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.data",
                Width = 80
            };
        }

        public static GenericNode CreateDirectData(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.directData",
                Width = 80
            };
        }

        public static GenericNode CreateStoredData(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.storedData",
                Width = 80
            };
        }
        
        public static GenericNode CreateSequentialData(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.sequentialData",
                Width = 80
            };
        }
        
        public static GenericNode CreateDatabase(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.dataBase",
                Width = 80
            };
        }
        
        public static GenericNode CreateInternalStorage(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.internalStorage",
                Width = 80
            };
        }
        
        public static GenericNode CreateManualInput(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.manualInput",
                Width = 80
            };
        }
        
        public static GenericNode CreateCard(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.card",
                Width = 80
            };
        }
        
        public static GenericNode CreatePaperType(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.paperType",
                Width = 80
            };
        }
        
        public static GenericNode CreateCloud(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.cloud",
                Width = 80
            };
        }
        
        public static GenericNode CreateDelay(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.delay",
                Width = 80
            };
        }
        
        public static GenericNode CreateDisplay(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.display",
                Width = 80
            };
        }
        
        public static GenericNode CreateManualOperation(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.manualOperation",
                Width = 80
            };
        }
        
        public static GenericNode CreatePreparation(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.preparation",
                Width = 80
            };
        }
        
        public static GenericNode CreateOnPageReference(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.onPageReference",
                Width = 80
            };
        }
        
        public static GenericNode CreateOffPageReference(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.offPageReference",
                Width = 80
            };
        }
        
        public static GenericNode CreateUserMessage(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.userMessage",
                Width = 80
            };
        }
        
        public static GenericNode CreateNetworkMessage(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.networkMessage",
                Width = 80
            };
        }
        
        public static GenericNode CreateAnnotation(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.annotation",
                Width = 80
            };
        }
        
    }
}