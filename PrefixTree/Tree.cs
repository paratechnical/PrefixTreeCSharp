using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArboriPrefixati.PrefixTree
{
    class Tree
    {
        private List<string> subsequentStrings;

        private Node _root;
        public Node Root
        {
            get
            {
                return _root;
            }
        }

        public Tree()
        {
            _root = new Node(' ');
            subsequentStrings = new List<string>();
        }

        public void AddWord(string word)
        {
            char[] chars = word.ToCharArray();
            Node currentNode = _root;
            Node child = null;
            for (int counter = 0; counter < chars.Length; counter++)
            {
                child = currentNode.GetChild(word[counter]);
                if(child == null)
                {
                    var newNode = new Node(word[counter]);
                    currentNode.Subtree.Add(newNode);
                    currentNode = newNode;
                }
                else
                    currentNode = child;
                if(counter == chars.Length - 1)
                    currentNode.AWordEndsHere = true;
            }
        }

        public bool Find(string query)
        {
            char[] chars = query.ToCharArray();
            Node currentNode = _root;
            Node child = null;
            for (int counter = 0; counter < chars.Length; counter++)
            {
                child = currentNode.GetChild(chars[counter]);
                if (child == null)
                    return false;
                currentNode = child;
            }

            return true;
        }

        public List<string> GetMatches(string query)
        {
            StringBuilder sbPrevious = new StringBuilder();
            char[] chars = query.ToCharArray();
            Node currentNode = _root;
            Node child = null;
            for (int counter = 0; counter < chars.Length; counter++)
            {
                if(counter < chars.Length - 1)
                    sbPrevious.Append(chars[counter]);

                child = currentNode.GetChild(chars[counter]);
                if (child == null)
                    break;
                currentNode = child;
            }

            subsequentStrings.Clear();

            GenerateSubsequentStrings(currentNode, sbPrevious.ToString());

            return subsequentStrings;
        }

        private void GenerateSubsequentStrings( Node node,
                                                        string subsequentString)
        {
            if(node == null)
                return;

            subsequentString = subsequentString + node.Char;

            if(node.AWordEndsHere)
            {
                subsequentStrings.Add(subsequentString);
                //return;
            }

            foreach (var subnode in node.Subtree)
                GenerateSubsequentStrings(subnode, subsequentString);
        }
    }
}
