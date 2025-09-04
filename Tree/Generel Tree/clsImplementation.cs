using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Generel_Tree
{
    internal class clsImplementation
    {
        public class TreeNode<T>
        {
            public T Value { get; set; }
            public List<TreeNode<T>> Children { get; set; }

            public TreeNode(T value)
            {
                Value = value;
                Children = new List<TreeNode<T>>();
            }

            public void AddChild(TreeNode<T> node)
            {
                Children.Add(node);
            }

            public TreeNode<T> Find(T value)
            {
                if (EqualityComparer<T>.Default.Equals(Value, value))
                    return this;

                foreach(var child in Children)
                {
                    var found = child.Find(value);
                    if (found != null) return found;
                }
                return null;
            }

        }
        public class Tree <T>
        {
            public TreeNode<T> root { get; private set; }

            // private set for root bs cannot change the root for the tree genereted
            public Tree (TreeNode<T> RootNode)
            {
                root = RootNode;
            }
            public void printdata(string indent = " ")
            {
                printdata(this.root, indent);
            }

            private static void printdata(TreeNode<T> Node,  string indent = " ")
            {
                Console.WriteLine(indent + Node.Value);
                foreach(var child in Node.Children)
                    printdata(child, indent + "  ");
            }
        }
        static public void PrintTree(TreeNode <string> tree,Action<string ,string> print ,string del = " ")
        {
            print(del, tree.Value);
            foreach(var child in tree.Children) // foreach use children.count to check it shoulde iterate trough nodes or not
                PrintTree(child, print, del + "  "); //recursion
        }
        static public void Application()
        {
            TreeNode<string> Root = new TreeNode<string>("CEO");
            TreeNode<string> Child1 = new TreeNode<string>("CFO");
            TreeNode<string> Child2 = new TreeNode<string>("CMO");
            TreeNode<string> Child3 = new TreeNode<string>("CTO");

            Tree<string> genTree = new Tree<string>(Root);
            genTree.root?.Children.Add(Child1);
            genTree.root?.Children.Add(Child2);
            genTree.root?.Children.Add(Child3);

            Child1.Children.Add(new TreeNode<string>("Accountant"));
            Child2.Children.Add(new TreeNode<string>("Social Media Manager"));
            Child3.Children.Add(new TreeNode<string>("Developper"));
            Child3.Children.Add(new TreeNode<string>("UX/UI Designer"));

            //PrintTree(genTree.root, (x, y) => Console.WriteLine(x + y));
            genTree.printdata();
            Console.WriteLine();
            var found = genTree.root?.Find("Developper");
            if (found != null)
                Console.WriteLine("Dev was founded in the Tree");
            else
                Console.WriteLine("not founded");
        }

        static public void FamilyTree()
        {
            TreeNode<string> Dad = new TreeNode<string>("abdellatif");
            TreeNode<string> Mom = new TreeNode<string>("Bouchra");

            Tree<string> root1 = new Tree<string>(Mom);
            Tree<string> root2 = new Tree<string>(Dad);

            TreeNode<string> me = new TreeNode<string>("ilyas");
            TreeNode<string> child1 = new TreeNode<string>("Akram");
            TreeNode<string> child2 = new TreeNode<string>("Riyad");
            root1.root?.AddChild(me);
            root1.root?.AddChild(child1);
            root1.root?.AddChild(child2);
            root2.root?.AddChild(me);
            root2.root?.AddChild(child1);
            root2.root?.AddChild(child2);
            me.AddChild(new TreeNode<string>("Inchaalah"));

            PrintTree(root1.root, (x, y) => Console.WriteLine(x + y));
            PrintTree(root2.root, (x, y) => Console.WriteLine(x + y));
        }
    }
}
