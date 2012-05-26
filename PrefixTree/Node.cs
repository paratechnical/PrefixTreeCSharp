using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArboriPrefixati.PrefixTree
{
    class Node
    {

        public char Char;
        public bool AWordEndsHere;
        public List<Node> Subtree;

        public Node(char c)
        {
            Char = c;
            Subtree = new List<Node>();
        }

        public Node(char c, bool wordends):this(c)
        {
            AWordEndsHere = wordends;
        }

        public Node GetChild(char c)
        {
            if (Subtree.Count != 0)
                foreach (var node in Subtree)
                    if (node.Char == c)
                        return node;
            return null;
        }
    }
}
