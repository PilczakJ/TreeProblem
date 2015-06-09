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

        /// <summary>
        /// Create a tree with the desired number of levels using a starting node with a value of 1
        /// </summary>
        /// <param name="levels">The number of levels inputted by the user</param>
        public Tree(int levels)
        {
            root = new Node();
            curLevel = 1;
            totalLevels = levels;
            if(levels > 1)
                CreateTree(root);
        }

        /// <summary>
        /// Recursively create the tree
        /// </summary>
        /// <param name="rootNode">The root node of this particular call of CreateTree</param>
        /// <returns>Whether the tree has reached its desired level</returns>
        private bool CreateTree(Node rootNode)
        {
            rootNode.Left = new Node(rootNode.Parent.value + FindLeftNeighbor(rootNode.Parent).value);
            rootNode.Right = new Node(rootNode.Parent.value + FindRightNeighbor(rootNode.Parent).value);
            curLevel++;
            if (curLevel < totalLevels)
            {
                CreateTree(rootNode.Left);
                CreateTree(rootNode.Right);
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Finds the right neighbor node of the parameter node
        /// </summary>
        /// <param name="n"></param>
        /// <returns>The right neigbor of the parameter node</returns>
        private Node FindRightNeighbor(Node n)
        {
            return null;
        }

        /// <summary>
        /// Finds the left neighbor node of the inputted node
        /// </summary>
        /// <param name="n"></param>
        /// <returns>The left neigbor of the parameter node</returns>
        private Node FindLeftNeighbor(Node n)
        {
            return null;
        }

        /// <summary>
        /// Recursively prints out the tree
        /// </summary>
        /// <param name="rootNode">The root of this particular call of PrintTree</param>
        public void PrintTree(Node rootNode)
        {

        }
    }
}
