using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProblem
{
    class Tree
    {
        private Node root;
        private int curLevel;
        private int totalLevels;
        private int counter = 1;
        private List<Node> data;
        /// <summary>
        /// Create a tree with the desired number of levels using a starting node with a value of 1
        /// </summary>
        /// <param name="levels">The number of levels inputted by the user</param>
        public Tree(int levels)
        {
            //Currently using an arbitrarily sized array to hold the data
            data = new List<Node>();
            root = new Node();
            data.Add(root);
            root.name = "root";
            root.level = 1;
            curLevel = 1;
            totalLevels = levels;
            if(levels > 1)
                CreateTree(root);
            SetAllData(data);
        }

        /// <summary>
        /// Recursively create the tree
        /// </summary>
        /// <param name="rootNode">The root node of this particular call of CreateTree</param>
        /// <returns>Whether the tree has reached its desired level</returns>
        private void CreateTree(Node rootNode)
        {

            rootNode.Left = new Node();
            rootNode.Left.name = counter++.ToString();
            rootNode.Left.Parent = rootNode;
            rootNode.Left.level = rootNode.level+1;
            rootNode.Right = new Node();
            rootNode.Right.name = counter++.ToString();
            rootNode.Right.Parent = rootNode;
            rootNode.Right.level = rootNode.level+1;

            data.Add(rootNode.Left);
            data.Add(rootNode.Right);
            if (rootNode.Left.level == totalLevels)
                return;
            else
            {
                CreateTree(rootNode.Left);
                CreateTree(rootNode.Right);
            }
        }

        /// <summary>
        /// Now that the tree has all its nodes, we will set the data using the incremental names given,
        /// if a node requires the value of one ahead of it to find its parent's neighbor, that will be checked only 
        /// when needed.
        /// </summary>
        /// <param name="nodes">Array of data</param>
        private void SetAllData(List<Node> nodes)
        {
            foreach(Node n in nodes)
            {
                //Don't check if the node is null, it is the root, or if it has been checked already
                if(n != null && n.name != "root" && n.value == 1)
                {
                    //If it is the direct child of the root, its value will be the root's value
                    if (n.Parent.name == "root")
                    {
                        n.value = root.value;
                    }
                    //Otherwise, we calculate the sum of the parent and parent's neighbor depending on which child it is
                    else if (n == n.Parent.Left)
                        n.value = n.Parent.value + FindLeftNeighbor(n.Parent).value;
                    else
                        n.value = n.Parent.value + FindRightNeighbor(n.Parent).value;
                }
            }
        }

        /// <summary>
        /// Set a specific node's data
        /// </summary>
        /// <param name="n">The specific node</param>
        private void SetData(Node n)
        {
            if (n.Parent.name == "root")
            {
                n.value = root.value;
            }
            else if (n == n.Parent.Left)
                n.value = n.Parent.value + FindLeftNeighbor(n.Parent).value;
            else
                n.value = n.Parent.value + FindRightNeighbor(n.Parent).value;
        }

        /// <summary>
        /// Finds the right neighbor node of the parameter node
        /// </summary>
        /// <param name="n"></param>
        /// <returns>The right neigbor of the parameter node</returns>
        private Node FindRightNeighbor(Node n)
        {
            if (n == n.Parent.Left)
                return n.Parent.Right;

            Node curNode = n;
            int levelsUp = 0;
            while(curNode == curNode.Parent.Right || curNode.Parent == null)
            {
                curNode = curNode.Parent;
                levelsUp++;
                if (curNode.name == "root")
                    return new Node(0);
            }
            if (curNode.Parent == null)
                return new Node(0);
            
            curNode = curNode.Parent;
            levelsUp++;
            
            curNode = curNode.Right;
            for (int i = 0; i < levelsUp-1; i++)
                curNode = curNode.Left;
            if (Int32.Parse(curNode.name) > Int32.Parse(n.name))
                SetData(curNode);
            return curNode;

        }

        /// <summary>
        /// Finds the left neighbor node of the inputted node
        /// </summary>
        /// <param name="n"></param>
        /// <returns>The left neigbor of the parameter node</returns>
        private Node FindLeftNeighbor(Node n)
        {
            if (n == n.Parent.Right)
                return n.Parent.Left;

            Node curNode = n;
            int levelsUp = 0;
            while (curNode == curNode.Parent.Left || curNode.Parent == null)
            {
                curNode = curNode.Parent;
                levelsUp++;
                if (curNode.name == "root")
                    return new Node(0);
            }
            if (curNode.Parent == null)
                return new Node(0);

            curNode = curNode.Parent;
            levelsUp++;


            curNode = curNode.Left;
            for (int i = 0; i < levelsUp-1; i++)
                curNode = curNode.Right;
            if (Int32.Parse(curNode.name) > Int32.Parse(n.name))
                SetData(curNode);
            return curNode;
        }

        /// <summary>
        /// Recursively prints out the tree
        /// </summary>
        /// <param name="rootNode">The root of this particular call of PrintTree</param>
        public void PrintTree(Node rootNode)
        {

            Console.WriteLine(rootNode.value);
            if (rootNode.Left != null)
            {
                PrintTree(rootNode.Left);
                PrintTree(rootNode.Right);
            }
            else
                return;

        }

        public Node Root {
            get { return root; } 
        }
    }
}
