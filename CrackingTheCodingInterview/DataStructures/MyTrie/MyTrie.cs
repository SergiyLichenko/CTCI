using System;

namespace DataStructures.MyTrie
{
    public class MyTrie
    {
        public MyTrieNode Root { get; private set; }

        public MyTrie()
        {
            Root = new MyTrieNode();
        }

        public void Insert(string value)
        {
            if (value == null)
                throw new ArgumentNullException();
            var currentNode = Root;

            for (int i = 0; i < value.Length; i++)
            {
                if (currentNode.Children.ContainsKey(value[i]))
                    currentNode = currentNode.Children[value[i]];
                else
                {
                    var node = new MyTrieNode();
                    node.EndOfWord = i == value.Length - 1;
                    currentNode.Children[value[i]] = node;
                    currentNode = node;
                }
            }
        }

        public bool ContainsWord(string value)
        {
            if (value == null)
                throw new ArgumentNullException();
            var currentNode = Root;

            foreach (char ch in value)
            {
                if (!currentNode.Children.ContainsKey(ch))
                    return false;
                currentNode = currentNode.Children[ch];
            }
            return currentNode.EndOfWord;
        }

        public bool ContainsPrefix(string value)
        {
            if (value == null)
                throw new ArgumentNullException();
            var currentNode = Root;

            foreach (char ch in value)
            {
                if (!currentNode.Children.ContainsKey(ch))
                    return false;
                currentNode = currentNode.Children[ch];
            }
            return true;
        }

        public void DeleteWord(string value)
        {
            if (!ContainsWord(value))
                return;

            MyTrieNode currentNode = Root;
            MyTrieNode parentNode = null;

            DeleteWordHelper(currentNode, parentNode, value, 0);
        }

        private void DeleteWordHelper(
            MyTrieNode currentNode, MyTrieNode parentNode,
            string value, int currentIndex)
        {
            if (currentIndex == value.Length)
                return;

            parentNode = currentNode;
            currentNode = currentNode.Children[
                value[currentIndex++]];

            DeleteWordHelper(currentNode, parentNode,
                value, currentIndex);

            if (currentNode.Children.Count > 0)
                currentNode.EndOfWord = false;
            else
                parentNode.Children.Remove(value[currentIndex - 1]);
        }
    }
}
