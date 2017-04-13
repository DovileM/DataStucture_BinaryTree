using System;

namespace DataStuctureBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            int[] values = new int[] {19, 23, 5, 6, 9, 27, 20, 5, 27, 0 };

            for (int i = 0; i < values.Length; i++)
            {
                tree.Add(values[i]);
            }
            tree.Print("Asc");
            //tree.Print("Dec");
            for (int i = 0; i < values.Length; i++)
            {
                tree.Remove(values[i]);
            }
            Console.WriteLine();
            if (tree.head != null)
                Console.WriteLine(tree.head.value);
            else
                Console.WriteLine("head equals null");
            Console.WriteLine();
            tree.Print("Asc");

            Console.ReadKey();
        }
    }

    public class BinaryTree
    {
        public Node head;

        public BinaryTree()
        {
            head = null;
        }

        public bool Add(int value)
        {
            if (head == null)
            {
                head = new Node(value);
                return true;
            }
            else
                return Insert(value, head);
        }

        private bool Insert(int value, Node root)
        {
            if (value == root.value)
                return false;
            else if (value < root.value)
            {
                if (root.leftLeaf == null)
                {
                    root.leftLeaf = new Node(value);
                    return true;
                }
                else
                    return Insert(value, root.leftLeaf);
            }
            else
            {
                if (root.rightLeaf == null)
                { 
                    root.rightLeaf = new Node(value);
                    return true;
                }
                else
                    return Insert(value, root.rightLeaf);
            }
        }

        public bool Search(int value)
        {
            if (head == null)
                return false;
            else
                return Search(value, head);
        }

        private bool Search(int value, Node root)
        {
            if (root.value == value)
                return true;
            else if (root.value > value)
            {
                if (root.leftLeaf == null)
                    return false;
                else
                    return Search(value, root.leftLeaf);
            }
            else
            {
                if (root.rightLeaf == null)
                    return false;
                else
                    return Search(value, root.rightLeaf);
            }
        }

        public bool Remove(int value)
        {
            if (head == null)
                return false;
            else
                return Remove(value, ref head);
        }

        private bool Remove(int value, ref Node root)
        {
            if (root.value > value)
            {
                if (root.leftLeaf == null)
                    return false;
                else
                    return Remove(value, ref root.leftLeaf);
            }
            else if (root.value < value)
            {
                if (root.rightLeaf == null)
                    return false;
                else
                    return Remove(value, ref root.rightLeaf);
            }
            else
            {
                if (root.leftLeaf == null && root.rightLeaf == null)
                    root = null;
                else if (root.leftLeaf != null && root.rightLeaf == null)
                    root = root.leftLeaf;
                else if (root.leftLeaf == null && root.rightLeaf != null)
                    root = root.rightLeaf;
                else
                    root.value = FindMinValue(ref root.rightLeaf);
                return true;
            }
        }

        private int FindMinValue(ref Node root)
        {
            if (root.leftLeaf != null)
                return FindMinValue(ref root.leftLeaf);
            else
            {
                int value = root.value;
                root = null;
                return value;
            }
        }

        private Node Delete(Node root)
        {
            if (root.rightLeaf != null)
            {
                return Delete(root.rightLeaf);
            }
            else
            {
                Node temp = root;
                root = null;
                return temp;
            }
        }

        public void Print(string str)
        {
            if(head != null)
            {
                if (str.Equals("Asc"))
                    PrintAsc(head);
                else
                    PrintDec(head);
                Console.WriteLine();
            }
        }

        private void PrintAsc(Node root)
        {
            if (root.leftLeaf != null)
            {
                PrintAsc(root.leftLeaf);
                Console.Write(root.value + ", ");
            }
            else
                Console.Write(root.value + ", ");

            if (root.rightLeaf != null)
                PrintAsc(root.rightLeaf);
        }

        private void PrintDec(Node root)
        {
            if (root.rightLeaf != null)
            {
                PrintDec(root.rightLeaf);
                Console.Write(root.value+", ");
            }
            else
                Console.Write(root.value + ", ");

            if (root.leftLeaf != null)
                PrintDec(root.leftLeaf);
        }

    }

    public class Node
    {
        public int value;
        public Node leftLeaf;
        public Node rightLeaf;

        public Node(int value)
        {
            leftLeaf = null;
            rightLeaf = null;
            this.value = value;
        }
    }
}