using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class MinimumCharactersForWords
    {
        // input  ["this","that","did","deed","them!","a"]
        // output ["t","t","h","i","s","a","d","d","e","e","m","!"]
        public void RunSolution()
        {
            var result = GetMinimumCharactersForWords1(new string[] { "this", "that", "did", "deed", "them!", "a" });
        }

        private List<string> GetMinimumCharactersForWords1(string[] words)
        {
            Dictionary<char, int> maximumCharacterFrequencies = new Dictionary<char, int>();
            foreach (var word in words)
            {
                var characterFrequencies = countCharacterFrequencies(word);
                UpdateMaximumFrequencies(characterFrequencies, maximumCharacterFrequencies);
            }

            return makeArrayFromCharacterFrequencies(maximumCharacterFrequencies);
        }

        private List<string> makeArrayFromCharacterFrequencies(Dictionary<char, int> characterFrequencies)
        {
            List<string> characters = new List<string>();
            foreach (var character in characterFrequencies)
            {
                var frequency = characterFrequencies[character.Key];
                for (int i = 0; i < frequency; i++)
                {
                    characters.Add(character.Key.ToString());
                }
            }

            return characters;
        }

        private void UpdateMaximumFrequencies(Dictionary<char, int> frequencies, Dictionary<char, int> maximumFrequencies)
        {
            foreach (var character in frequencies)
            {
                var frequency = frequencies[character.Key];

                if(maximumFrequencies.ContainsKey(character.Key))
                {
                    maximumFrequencies[character.Key] = Math.Max( frequency, maximumFrequencies[character.Key]);
                }
                else
                {
                    maximumFrequencies[character.Key] = frequency;
                }
            }
        }

        private Dictionary<char, int> countCharacterFrequencies(string word)
        {
            var characterFrequencies = new Dictionary<char, int>();
            foreach (var character in word)
            {
                if (!characterFrequencies.ContainsKey(character))
                {
                    characterFrequencies.Add(character, 0);
                }
                characterFrequencies[character]++;
            }
            return characterFrequencies;
        }

        private List<string> GetMinimumCharactersForWords(string[] words)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            foreach (var word in words)
            {
                Dictionary<char, int> localDict = new Dictionary<char, int>();
                for (int i = 0; i < word.Length; i++)
                {
                    if (localDict.ContainsKey(word[i]))
                    {
                        localDict[word[i]]++;
                    }
                    else
                    {
                        localDict.Add(word[i], 1);
                    }

                    if (result.ContainsKey(word[i]))
                    {
                        if (localDict[word[i]] > result[word[i]])
                            result[word[i]] = localDict[word[i]];
                    }
                    else
                    {
                        result.Add(word[i], 1);
                    }
                }

            }

            List<string> output = new List<string>();
            foreach (var item in result)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    output.Add(item.Key.ToString());
                }
            }

            return output;
        }
    }
}
