using System.Collections.Generic;

namespace DataStructures.MyTrie
{
    public class MyTrieNode
    {
        public Dictionary<char, MyTrieNode> Children { get; private set; }
        public bool EndOfWord { get; set; }

        public MyTrieNode()
        {
            Children = new Dictionary<char, MyTrieNode>();
        }
    }
}