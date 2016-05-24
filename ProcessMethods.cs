using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImagePro
{
    class ProcessMethods
    {
        String output = "";
        String leafout = "";
        
        public List<HuffmanNode> getListFromFile(Bitmap image)
        {
            List<HuffmanNode> nodeList = new List<HuffmanNode>();   
            Color c;
            Console.Write("Enter the path of the file: ");
            String filename = Console.ReadLine();

 
            for(int i = 0; i < image.Width; i++)
            {
                for(int j = 0; j < image.Height; j++)
                {
                    c = image.GetPixel(i, j);
                    String val = ((c.R + c.G + c.B) / 3).ToString();
                    if (nodeList.Exists(x => x.symbol == val))  
                        nodeList[nodeList.FindIndex(y => y.symbol == val)].frequencyIncrease();  
                    else
                        nodeList.Add(new HuffmanNode(val));
                }
            }
                
                nodeList.Sort();    
                return nodeList;
            

        }


     
        public void getTreeFromList(List<HuffmanNode> nodeList)
        {
            while (nodeList.Count > 1)  
            {
                HuffmanNode node1 = nodeList[0];     
                nodeList.RemoveAt(0);                
                HuffmanNode node2 = nodeList[0];     
                nodeList.RemoveAt(0);               
                nodeList.Add(new HuffmanNode(node1, node2));    
                nodeList.Sort();         
            }
        }


        
        public void setCodeToTheTree(string code, HuffmanNode Nodes)
        {
            if (Nodes == null)
                return;
            if (Nodes.leftTree == null && Nodes.rightTree == null)
            {
                Nodes.code = code;
                return;
            }
            setCodeToTheTree(code + "0", Nodes.leftTree);
            setCodeToTheTree(code + "1", Nodes.rightTree);
        }

        public String print(int level, HuffmanNode node)
        {
            PrintTree(level,node);
            return output;


        }
     
        public void PrintTree(int level, HuffmanNode node)
        {
            
            if (node == null)
                return ;
            for (int i = 0; i < level; i++)
            {
                //Console.Write("\t");
                output = output + "\t";
            }
            //Console.Write("[" + node.symbol + "]");
            output = output + "[" + node.symbol + "]";
            // Test.setColor();
            // Console.WriteLine("(" + node.code + ")");
            output = output + "(" + node.code + ")";
              //Test.setColorDefault();
            PrintTree(level + 1, node.rightTree);
            PrintTree(level + 1, node.leftTree);
             
        }


         
        public String PrintInformation(List<HuffmanNode> nodeList)
        {
            String output = "";
            foreach (var item in nodeList)
                // Console.WriteLine("Symbol : {0} - Frequency : {1}", item.symbol, item.frequency);
                output = output + "Symbol : {0} - Frequency : {1}" + item.symbol + item.frequency + "\n";
            return output;
        }

        public String printLeaf(HuffmanNode nodeList)
        {
            PrintfLeafAndCodes(nodeList);
            return leafout;
        }

        
        public void PrintfLeafAndCodes(HuffmanNode nodeList)
        {
            if (nodeList == null)
                return;
            if (nodeList.leftTree == null && nodeList.rightTree == null)
            {
                //Console.WriteLine("Symbol : {0} -  Code : {1}", nodeList.symbol, nodeList.code);
                leafout = leafout + "Symbol : {0} -  Code : {1}" + nodeList.symbol + nodeList.code;
                return;
            }
            PrintfLeafAndCodes(nodeList.leftTree);
            PrintfLeafAndCodes(nodeList.rightTree);
        }

    }
}
