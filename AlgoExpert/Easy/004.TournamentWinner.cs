using System.Collections.Generic;
using System.Linq;

namespace leetcode.AlgoExpert.Easy
{
    public class TournamentWinner
    {
        public void RunSolution()
        {
            var result = GetTournamentWinner(new string[,] { { "HTML", "C#" }, { "C#", "Python" }, { "Python", "HTML" } }, new int[] { 0, 0, 1 });
        }

        private string GetTournamentWinner(string[,] strings, int[] results)
        {
            Dictionary<string, int> scores = new Dictionary<string, int>();
            scores.Add("", 0);
            string bestTeam = string.Empty;
            for (int i = 0; i < strings.GetLength(0); i++)
            {
                string result;
                
                if (results[i] == 0)
                {
                    result = strings[i, 1];
                }
                else
                {
                    result = strings[i, 0];
                }
                if (scores.ContainsKey(result))
                {
                    scores[result] += 3;
                }
                else
                {
                    scores.Add(result, 3);
                }
                if(scores.ContainsKey(bestTeam))
                {
                    if(scores[result] > scores[bestTeam])
                    {
                        bestTeam = result;
                    }
                }

            }
            return bestTeam;
        }
    }
}
