using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class ReverseWordsInString
    {
        // input  "AlgoExpert is the Best!"
        // output Best! the is AlgoExpert
        public void RunSolution()
        {
            var result = GetReverseWordsInStringInPlace4("AlgoExpert is the Best!");
            // var result = GetReverseWordsInStringInPlace3("    a  b ");
        }

        private string GetReverseWordsInStringInPlace4(string strings)
        {
            List<string> words = new List<string>();
            int startOfWord = 0;
            for (int idx = 0; idx < strings.Length; idx++)
            {
                var character = strings[idx];

                if (character == ' ')
                {
                    words.Add(strings.Substring(startOfWord, idx - startOfWord));
                    startOfWord = idx;
                }else if (strings[startOfWord] == ' ')
                {
                    words.Add(" ");
                    startOfWord = idx;
                }
            }

            words.Add(strings.Substring(startOfWord, strings.Length - startOfWord));

            reverseList(words);
            return string.Join("",words);
        }

        private void reverseList(List<string> words)
        {
            int start = 0;
            int end = words.Count - 1;

            while (start < end)
            {
                var temp = words[start];
                words[start] = words[end];
                words[end] = temp;
                start++;
                end--;
            }
        }

        private string GetReverseWordsInString1(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            char[] str = input.ToCharArray();

            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString().TrimEnd();
        }


        private string GetReverseWordsInString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            string[] str = input.Split(' ');

            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i] + " ");
            }
            return sb.ToString().TrimEnd();
        }

        private string GetReverseWordsInStringInPlace(string input)
        {

            List<string> list = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    // find next non space
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] != ' ')
                        {
                            list.Add(input.Substring(i, j - i));
                            i = j - 1;
                            break;
                        }
                        if (j + 1 == input.Length)
                        {
                            list.Add(input.Substring(i, input.Length - i));
                            i = input.Length;
                            break;
                        }
                    }
                }
                else
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] == ' ')
                        {
                            list.Add(input.Substring(i, j - i));
                            i = j - 1;
                            break;
                        }
                        if (j + 1 == input.Length)
                        {
                            list.Add(input.Substring(i, input.Length - i));
                            i = input.Length;
                            break;
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                sb.Append(list[i]);
            }


            return sb.ToString();
        }
        private string GetReverseWordsInStringInPlace3(string input)
        {
            List<string> list = new List<string>();
            int startOfWord = 0;
            int startOfSpace = 0;
            bool isWord = false;
            bool isSpace = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    isWord = true;
                    isSpace = false;
                }
                else
                {
                    isSpace = true;
                    isWord = false;
                }

                if (!isWord)
                {
                    list.Add(input.Substring(startOfWord, i - startOfWord - 1));
                    startOfSpace = i;
                }
                if (!isSpace)
                {
                    list.Add(input.Substring(startOfSpace, i - startOfSpace - 1));
                    startOfWord = i;
                }
            }

            return string.Join("", list.ToArray());
        }

    }
}
