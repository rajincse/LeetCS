using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class NArrayTreeSerailizeProblem
    {
        public class Node {
            public int val;
            public IList<Node> children;

            public Node() {}

            public Node(int _val) {
                val = _val;
            }

            public Node(int _val, IList<Node> _children) {
                val = _val;
                children = _children;
            }
        }

        public class Codec {
            // Encodes a tree to a single string.
            public string serialize(Node root) {
                if(root == null)
                {
                    return string.Empty;
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("(");
                sb.Append(root.val);

                if(root.children != null && root.children.Count > 0)
                {
                    foreach(Node child in root.children)
                    {
                        sb.Append(serialize(child));                        
                    }
                }                
                
                sb.Append(")");
                return sb.ToString();
            }
            
            // Decodes your encoded data to tree.
            public Node deserialize(string data) {
                if(string.IsNullOrEmpty(data))
                {
                    return null;
                }
                char[] charArray = data.ToCharArray();
                Stack<Node> nodeStack = new Stack<Node>();
                Node result = null;
                foreach(char c in charArray)
                {
                    if(c == '(')
                    {
                        if(nodeStack.Count == 0)
                        {
                            Node node = new Node();
                            nodeStack.Push(node);
                        }
                        else
                        {
                            Node top = nodeStack.Pop();
                            if(top.children == null)
                            {
                                top.children = new List<Node>();
                            }
                            Node node = new Node();
                            top.children.Add(node);
                            nodeStack.Push(top);
                            nodeStack.Push(node);
                        }
                    }
                    else if(char.IsDigit(c))
                    {
                        Node top = nodeStack.Pop();
                        top.val = 10 * top.val + c - '0';
                        nodeStack.Push(top);
                    }
                    else if(c == ')')
                    {
                        Node top = nodeStack.Pop();
                        if(nodeStack.Count == 0)
                        {
                            result = top;
                        }
                    }
                    
                }
                return result;
            }
        }
        // public static void Main(string[] args)
        // {
        //     string serialized = "(1(2)(3(6)(7(11(14))))(4(8(12)))(5(9(13)(10))))";
        //     Codec codec = new Codec();
        //     Node node =  codec.deserialize(serialized);
        //     Console.WriteLine($"{serialized} => \n{codec.serialize(node)}");
        // }
    }    
}