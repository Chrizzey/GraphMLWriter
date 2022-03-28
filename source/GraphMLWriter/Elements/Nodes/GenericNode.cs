using GraphMLWriter.Elements;

namespace GraphMLWriter.Serializer.ElementSerializer
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

        public static GenericNode Start1(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.start1",
                Width = 80
            };
        }

        public static GenericNode Start2(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.start2",
                Width = 80
            };
        }

        public static GenericNode Terminator(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.terminator",
                Width = 80
            };
        }

        public static GenericNode Process(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.process",
                Width = 80
            };
        }

        public static GenericNode PredefinedProcess(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.predefinedProcess",
                Width = 80
            };
        }

        public static GenericNode Decision(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.decision",
                Width = 80
            };
        }

        public static GenericNode LoopLimit(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.loopLimit",
                Width = 80
            };
        }

        public static GenericNode LoopLimitEnd(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.loopLimitEnd",
                Width = 80
            };
        }

        public static GenericNode Document(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.document",
                Width = 80
            };
        }

        public static GenericNode Data(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.data",
                Width = 80
            };
        }

        public static GenericNode DirectData(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.directData",
                Width = 80
            };
        }

        public static GenericNode StoredData(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.storedData",
                Width = 80
            };
        }
        
        public static GenericNode SequentialData(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.sequentialData",
                Width = 80
            };
        }
        
        public static GenericNode Database(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.dataBase",
                Width = 80
            };
        }
        
        public static GenericNode InternalStorage(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.internalStorage",
                Width = 80
            };
        }
        
        public static GenericNode ManualInput(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.manualInput",
                Width = 80
            };
        }
        
        public static GenericNode Card(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.card",
                Width = 80
            };
        }
        
        public static GenericNode PaperType(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.paperType",
                Width = 80
            };
        }
        
        public static GenericNode Cloud(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.cloud",
                Width = 80
            };
        }
        
        public static GenericNode Delay(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.delay",
                Width = 80
            };
        }
        
        public static GenericNode Display(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.display",
                Width = 80
            };
        }
        
        public static GenericNode ManualOperation(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.manualOperation",
                Width = 80
            };
        }
        
        public static GenericNode Preparation(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.preparation",
                Width = 80
            };
        }
        
        public static GenericNode OnPageReference(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.onPageReference",
                Width = 80
            };
        }
        
        public static GenericNode OffPageReference(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.offPageReference",
                Width = 80
            };
        }
        
        public static GenericNode UserMessage(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.userMessage",
                Width = 80
            };
        }
        
        public static GenericNode NetworkMessage(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.networkMessage",
                Width = 80
            };
        }
        
        public static GenericNode Annotation(int nodeNumber, string text = null)
        {
            return new GenericNode(text, nodeNumber)
            {
                Configuration = "com.yworks.flowchart.annotation",
                Width = 80
            };
        }
        
    }
}