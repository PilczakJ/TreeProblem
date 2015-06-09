using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProblem
{
    class Node
    {
        public int value;
        private Node parent;
        private Node left;
        private Node right;
        public string name;
        public int level;

        public Node()
        {
            value = 1;
        }

        public Node(int val)
        {
            value = val;
        }

        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public Node Left
        {
            get { return left; }
            set { left = value; }
        }

        public Node Right{
            get { return right; }
            set { right = value; }
        }

        public bool IsLeaf()
        {
            if (left == null)
                return true;
            else
                return false;
        }



    }
}
