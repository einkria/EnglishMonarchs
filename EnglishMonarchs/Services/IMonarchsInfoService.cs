using System;

namespace EnglishMonarchs.Services
{
    public interface IMonarchsInfoService
    {
        /*
         * Number of monarchs in the list received
         */
        int NumberOfMonarchs();

        /*
         * Get the name of the monarch who ruled for the longest time
         */
        String GetLongestRuler();

        /*
         * Get the number of years the longest ruling monarch ruled
         */
        int GetLongestRule();

        /*
         * Get the name of the house that ruled for the longest time
         */
        String GetLongestHouseRuler();

        /*
         * Get the number of years the longest ruling house ruled
         */
        int GetLongestHouseRule();

        /*
         * Get the most frequent first name in the list
         */
        String GetMostFrequentFirstName();
    }
}
