using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.AlgoExpert.Medium
{
    public class ValidStartingCity
    {
        // we have to find a valid starting city
        // input
        // distance [5,25,15,10,15] //duration of lenght of task
        // fuel [1,2,1,0,3]
        // mpg = 10

        // output
        // 4
        public void RunSolution()
        {
            var r = GetValidStartingCity4(new int[] { 5, 25, 15, 10, 15 }, new int[] { 1, 2, 1, 0, 3 }, 10);
        }

        private int GetValidStartingCity(int[] distance, int[] fuel, int mpg)
        {
            int counter = 0;
            while (counter < distance.Length)
            {
                int startNodeDistance = distance[counter];
                int startFule = fuel[counter];
                int milage = mpg * startFule;
                bool output = true;
                for (int i = 1; i < distance.Length; i++)
                {
                    int circulValue = (i + counter) % distance.Length;
                    if (milage < startNodeDistance)
                    {
                        output = false;
                        break;
                    }
                    milage = milage - startNodeDistance;
                    startNodeDistance = distance[circulValue];
                    milage += mpg * fuel[circulValue];
                }
                if (output)
                {
                    return counter;
                }
                counter++;
            }
            return -1;
        }

        private int GetValidStartingCity2(int[] distance, int[] fuel, int mpg)
        {
            int maxIndex = Array.IndexOf(fuel, fuel.Max());
            int startNodeDistance = distance[maxIndex];
            int startFule = fuel[maxIndex];
            int milage = mpg * startFule;
            bool output = true;
            for (int i = 1; i < distance.Length; i++)
            {
                int circulValue = (i + maxIndex) % distance.Length;
                if (milage < startNodeDistance)
                {
                    output = false;
                    break;
                }
                milage = milage - startNodeDistance;
                startNodeDistance = distance[circulValue];
                milage += mpg * fuel[circulValue];
            }

            if (output)
            {
                return maxIndex;
            }
            return -1;
        }

        private int GetValidStartingCity3(int[] distance, int[] fuel, int mpg)
        {
            int numberOfCities = distance.Length;

            for (int startCityIdx = 0; startCityIdx < numberOfCities; startCityIdx++)
            {
                int milesRemaining = 0;

                foreach (int currentCityIdx in System.Linq.Enumerable.Range(startCityIdx, startCityIdx + numberOfCities))
                {
                    if (milesRemaining < 0) { break; }
                    int currentCity = currentCityIdx % numberOfCities;
                    int fuelFromCurrentCity = fuel[currentCity];
                    int distanceToNextCity = distance[currentCity];
                    milesRemaining += fuelFromCurrentCity * mpg - distanceToNextCity;

                }
                if (milesRemaining >= 0)
                {
                    return startCityIdx;
                }
            }
            return -1;
        }

        private int GetValidStartingCity4(int[] distance, int[] fuel, int mpg)
        {
            int numberOfCities = distance.Length;
            int milesRemaining = 0;

            int indexOfStartingCityCandidate = 0;
            int milesRemainingAtStartingCityCandidate = 0;

            foreach (var cityIdx in Enumerable.Range(1,numberOfCities))
            {
                int distanceFromPreviousCity = distance[cityIdx - 1];
                int fuelFromPreviousCity = fuel[cityIdx - 1];
                milesRemaining += fuelFromPreviousCity * mpg - distanceFromPreviousCity;

                if(milesRemaining < milesRemainingAtStartingCityCandidate)
                {
                    milesRemainingAtStartingCityCandidate = milesRemaining;
                    indexOfStartingCityCandidate = cityIdx;
                }
            }

            return indexOfStartingCityCandidate;
        }
    }
}
