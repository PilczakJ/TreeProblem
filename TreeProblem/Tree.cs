using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProblem
{
    class Tree
    {
        // Keeps track of the root of the whole tree
        private Node root;

        // Keeps track of what level the tree is currently on
        private int curLevel;
        
        // The user inputted level
        private int totalLevels;

        // Used for naming, gives an order to filling in the data
        private int counter = 1;

        // The actual list of data
        private List<Node> data;

        /// <summary>
        /// Create a tree with the desired number of levels using a starting node with a value of 1
        /// </summary>
        /// <param name="levels">The number of levels inputted by the user</param>
        public Tree(int levels)
        {
            data = new List<Node>();

            // Make and add the root
            root = new Node();
            data.Add(root);
            root.name = "root";
            root.level = 1;

            // Set the total levels
            curLevel = 1;
            totalLevels = levels;

            // Populate the tree
            if(levels > 1)
                CreateTree(root);

            // Set the data
            SetAllData(data);
        }

        /// <summary>
        /// Recursively create the tree
        /// </summary>
        /// <param name="rootNode">The root node of this particular call of CreateTree</param>
        /// <returns>Whether the tree has reached its desired level</returns>
        private void CreateTree(Node rootNode)
        {
            // Make the left child
            rootNode.Left = new Node();
            rootNode.Left.name = counter++.ToString();
            rootNode.Left.Parent = rootNode;
            rootNode.Left.level = rootNode.level+1;

            // Make the right child
            rootNode.Right = new Node();
            rootNode.Right.name = counter++.ToString();
            rootNode.Right.Parent = rootNode;
            rootNode.Right.level = rootNode.level+1;

            // Add the node to the data list
            data.Add(rootNode.Left);
            data.Add(rootNode.Right);

            // If we are at the inputted levels, stop
            if (rootNode.Left.level == totalLevels)
                return;
            // If not, make the next level
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
            // If it is the left child, the right neighbor is the right child
            if (n == n.Parent.Left)
                return n.Parent.Right;

            // If not, go up the tree until it is the right child or it is the root
            Node curNode = n;
            int levelsUp = 0;
            while(curNode == curNode.Parent.Right || curNode.Parent == null)
            {
                curNode = curNode.Parent;
                levelsUp++;
                if (curNode.name == "root")
                    return new Node(0);
            }
            // If it makes it to the root without being the right child, there is no right neighbor
            if (curNode.Parent == null)
                return new Node(0);
            
            // If not, move up to the parent that it is the right child of
            curNode = curNode.Parent;
            levelsUp++;
            
            // Go to the right side
            curNode = curNode.Right;

            // Go down the same amount you went up staying to the left
            for (int i = 0; i < levelsUp-1; i++)
                curNode = curNode.Left;
            
            // If the neighbor's data isn't set yet, set it so that this one's results are accurate
            if (Int32.Parse(curNode.name) > Int32.Parse(n.name))
                SetData(curNode);

            // Return the neighbor
            return curNode;

        }

        /// <summary>
        /// Finds the left neighbor node of the inputted node
        /// </summary>
        /// <param name="n"></param>
        /// <returns>The left neigbor of the parameter node</returns>
        private Node FindLeftNeighbor(Node n)
        {
            // If the node is the right child of its parent, the left neighbor is its sibling
            if (n == n.Parent.Right)
                return n.Parent.Left;

            // If not, go up until it is the right child
            Node curNode = n;
            int levelsUp = 0;
            while (curNode == curNode.Parent.Left || curNode.Parent == null)
            {
                curNode = curNode.Parent;
                levelsUp++;
                if (curNode.name == "root")
                    return new Node(0);
            }

            // If it reaches the root without being the right child, there is no left neighbor
            if (curNode.Parent == null)
                return new Node(0);

            // If not, move up to the parent then move to the left child
            curNode = curNode.Parent;
            levelsUp++;
            curNode = curNode.Left;

            // Go back down staying to the right to find the left neighbor of the node
            for (int i = 0; i < levelsUp-1; i++)
                curNode = curNode.Right;

            // If the neighbor isn't set yet, set it
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
            // Print the current node
            Console.WriteLine(rootNode.value);

            // If it isn't a leaf
            if (!rootNode.IsLeaf())
            {
                // Print its children
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
