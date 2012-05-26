using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArboriPrefixati.PrefixTree
{
    public class StringListHelper
    {
        public static List<string> InitializeList(string s, int count)
        {
            List<string> list = new List<string>();

            for(int i=0;i<count;i++)
                list.Add(s);
        }

        public static List<string> AddCharToList(List<string> list, char c)
        {
            foreach (var elem in list)
            {
                elem = elem + c;
            }
            return list;
        }
    }
}
