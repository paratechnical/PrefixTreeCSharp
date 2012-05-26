using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArboriPrefixati.PrefixTree;

namespace ArboriPrefixati
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree prefixTree = new Tree();
            
            prefixTree.AddWord("abc");
            prefixTree.AddWord("abcd");
            prefixTree.AddWord("abcde");
            prefixTree.AddWord("abcdef");
            prefixTree.AddWord("ab123cd");
            prefixTree.AddWord("abc123d");
            prefixTree.AddWord("abc132d");
            
            string word = "abc";


            if (prefixTree.Find(word))
            {
                var matches = prefixTree.GetMatches("abc");

                Console.WriteLine("gasit");
                Console.WriteLine("Autocomplete:");

                if (matches.Count > 0)
                    foreach (var m in matches)
                        Console.WriteLine(m);
            }
            else
                Console.WriteLine("nu gasii nimic");
        }
    }
}
