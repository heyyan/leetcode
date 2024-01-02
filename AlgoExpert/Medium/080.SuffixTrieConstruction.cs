using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class SuffixTrieConstruction
    {
        // babc
        public void RunSolution()
        {
            var result = GetSuffixTrieConstruction("babc");
        }

        private object GetSuffixTrieConstruction(string str)
        {
            SuffixTrie suffixTrie = new SuffixTrie();
            suffixTrie.PopulateSuffixTrieFrom(str);
            return suffixTrie;
        }
    }

    public class SuffixTrie
    {
        private readonly Dictionary<char, SuffixTrie> children;
        private bool isEnd;

        public SuffixTrie()
        {
            children = new Dictionary<char, SuffixTrie>();
            isEnd = false;
        }

        public void PopulateSuffixTrieFrom(string inputString)
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                InsertSubstringStartingAt(i, inputString);
            }
        }

        private void InsertSubstringStartingAt(int i, string inputString)
        {
            SuffixTrie node = this;

            for (int j = i; j < inputString.Length; j++)
            {
                char letter = inputString[j];

                if (!node.children.ContainsKey(letter))
                {
                    node.children[letter] = new SuffixTrie();
                }

                node = node.children[letter];
            }

            node.isEnd = true;
        }

        public bool Contains(string query)
        {
            SuffixTrie node = this;

            foreach (char letter in query)
            {
                if (!node.children.ContainsKey(letter))
                {
                    return false;
                }

                node = node.children[letter];
            }

            return node.isEnd;
        }
    }


}
