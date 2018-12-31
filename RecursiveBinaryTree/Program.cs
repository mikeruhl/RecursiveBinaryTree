using System;

namespace RecursiveBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new BinaryTreeNode<int>
            {
                Value = 1,
                Left = new BinaryTreeNode<int> {Value = 2},
                Right = new BinaryTreeNode<int> {Value = 3}
            };
            PrintRootValues(root);
            Console.WriteLine("Changing Values...");
            root.InorderDo(x=>x.Value++);

            PrintRootValues(root);
        }

        static void PrintRootValues(BinaryTreeNode<int> root)
        {
            Console.WriteLine($"Root Value: {root.Value}");
            Console.WriteLine($"Left Value: {root.Left.Value}");
            Console.WriteLine($"Right Value: {root.Right.Value}");
        }
    }

    public static class BinaryTreeNodeExtensions
    {
        public static void InorderDo<T>(this BinaryTreeNode<T> node, Action<BinaryTreeNode<T>> action)
        {
            node.Left?.InorderDo(action);
            action(node);
            node.Right?.InorderDo(action);
        }
    }
}
