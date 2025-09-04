using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Binary_Tree
{
    internal class clsImplementation
    {
        public class BinaryTreeNode<T>
        {
            public T value { get; set; }
            public BinaryTreeNode<T> Left { get; set; }
            public BinaryTreeNode<T> Right { get; set; }
            
            public BinaryTreeNode(T Value)
            {
                this.value = Value;
                Left = null;
                Right = null;
            }
        }

        public class BinaryTree<T>
        {
            public BinaryTreeNode<T> root { get; private set; }

            public BinaryTree()
            {
                root = null;
            }

            public void Insert(T value)
            {
                var NewNode = new BinaryTreeNode<T>(value);
                if (root == null)
                {
                    root = NewNode;
                    return;
                }

                Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();

                    if (current.Left == null)
                    {
                        current.Left = NewNode;
                        break;
                    }
                    else
                    {
                        queue.Enqueue(current.Left);
                    }

                    if (current.Right == null)
                    {
                        current.Right = NewNode;
                        break;
                    }
                    else
                    {
                        queue.Enqueue(current.Right);
                    }
                }
            }

            public void PrintTree()
            {
                PrintTree(this.root, 0);
            }
            private static void PrintTree(BinaryTreeNode<T> root, int space)
            {
                int count = 10;
                space += count;

                if (root == null)
                    return ;

                PrintTree(root.Right, space);

                Console.WriteLine();
                for(int i = count; i < space; i++)
                    Console.Write(" ");

                Console.WriteLine(root.value);
                PrintTree(root.Left, space);
            }

            static public void PreorderTraversal(BinaryTreeNode<T> root)
            {
                if (root != null)
                {
                    Console.Write(root.value + " ");
                    PreorderTraversal(root.Left);
                    PreorderTraversal(root.Right);
                }
            }
            public void PreorderTraversal()
            {
                PreorderTraversal(this.root);
                Console.WriteLine();
            }

            public void PostorderTraversal()
            {
                PostorderTraversal(this.root);
                Console.WriteLine();
            }

            static public void PostorderTraversal(BinaryTreeNode<T> root)
            {
                if (root != null)
                {
                    PostorderTraversal(root.Left);
                    PostorderTraversal(root.Right);
                    Console.Write(root.value + " ");
                }
            }

            public void InorderTraversal()
            {
                InorderTraversal(this.root);
                Console.WriteLine();
            }

            static public void InorderTraversal(BinaryTreeNode<T> root)
            {
                if (root != null)
                {
                    InorderTraversal(root.Left);
                    Console.Write(root.value + " ");
                    InorderTraversal(root.Right);
                }
            }
        }

        static public void Application ()
        {
            BinaryTree<string> binarytree = new BinaryTree<string> ();

            binarytree.Insert("Abdo");
            binarytree.Insert("Ilyas");
            binarytree.Insert("Riyad");
            binarytree.Insert("ziad");
            binarytree.Insert("rania");
            binarytree.Insert("mohammed");
            binarytree.Insert("ghita");
            binarytree.Insert("hmed");
            //binarytree.Insert("hmed");
            //binarytree.Insert("hmed");
            //binarytree.Insert("hmed");
            binarytree.PrintTree();
            binarytree.PreorderTraversal();
            binarytree.PostorderTraversal();


        }
    }
}
