using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class ValidIpAddresses
    {
        // input  "1921680"
        // output xyzzyx
        public void RunSolution()
        {
            var result = GetValidIpAddresses("1921680");
        }

        private List<string> GetValidIpAddresses(string str)
        {
            List<string> ipAddressesFound = new List<string>();

            for (int i = 1; i < Math.Min(str.Length, 4); i++)
            {
                string[] currentIPAddressParts = new string[] { "", "", "", "" };
                currentIPAddressParts[0] = str.Substring(0, i);
                if (!isValidPart(currentIPAddressParts[0]))
                {
                    continue;
                }

                for (int j = i + 1; j < i + Math.Min(str.Length - i, 4); j++)
                {
                    currentIPAddressParts[1] = str.Substring(i, j - i);
                    if (!isValidPart(currentIPAddressParts[1]))
                    {
                        continue;
                    }

                    for (int k = j + 1; k < j + Math.Min(str.Length - j, 4); k++)
                    {
                        currentIPAddressParts[2] = str.Substring(j, k - j);
                        currentIPAddressParts[3] = str.Substring(k);
                        if (isValidPart(currentIPAddressParts[2]) && isValidPart(currentIPAddressParts[3]))
                        {
                            ipAddressesFound.Add(string.Join(".", currentIPAddressParts));
                        }
                    }
                }
            }
            return ipAddressesFound;
        }

        private bool isValidPart(string str)
        {
            var stringAsInt = Convert.ToInt32(str);
            if (stringAsInt > 255)
            {
                return false;
            }
            return str.Length == stringAsInt.ToString().Length;
        }
    }
}
