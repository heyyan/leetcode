using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.HackerRank.Taptapsend
{
    public class RestAPICountry
    {
        public void RunSolution()
        {
            getCapitalCity("Pakistan");
        }

        public async Task<string> getCapitalCity(string country)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonmock.hackerrank.com/api/countries?name=pakistan");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();

                return "";
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
    }
}
