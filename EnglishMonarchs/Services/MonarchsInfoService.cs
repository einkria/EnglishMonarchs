using System;
using System.Collections.Generic;
using System.Linq;

using EnglishMonarchs.Models;


namespace EnglishMonarchs.Services
{
    public class MonarchsInfoService
    {
        private Monarchs _monarchs;
        private IList<String> _firstNames;
        private IDictionary<String, int> _houses;
        private String _longestRuler;
        private int _longestRule;
        private String _longestHouseRuler;
        private int _longestHouseRule;

        public MonarchsInfoService(Monarchs monarchs)
        {
            _monarchs = monarchs;
            _firstNames = new List<String>();
            _houses = new Dictionary<String, int>();
            _longestRuler = "";
            _longestRule = 0;
            _longestHouseRuler = "";
            _longestHouseRule = 0;

            SortThroughData();
        }

        public int NumberOfMonarchs()
        {
            return _monarchs.Count();
        }

        public String GetLongestRuler()
        {
            return _longestRuler;
        }

        public int GetLongestRule()
        {
            return _longestRule;
        }

        public String GetLongestHouseRuler()
        {
            return _longestHouseRuler;
        }

        public int GetLongestHouseRule()
        {
            return _longestHouseRule;
        }

        public String GetMostFrequentFirstName()
        {
            return FindMostFrequentFirstName();
        }

        /************ Private functions *************/

        /*
         * Run throuch Monarchs data and find out relevant info
         */
        private void SortThroughData()
        {
            int lengthOfRule = 0;
            
            for (int i = 0; i < _monarchs.Count(); i++)
            {
                Monarch monarch = _monarchs.GetMonarch(i);
                lengthOfRule = GetLengthOfRule(monarch.yrs);
                AddHouseAndRule(monarch.hse, lengthOfRule);
                AddRulerToList(monarch.nm);
                
                if (i == 0)
                {
                    _longestRuler = monarch.nm;
                    _longestRule = lengthOfRule;
                    continue;   
                }

                CompareLenghtOfRule(monarch.nm, lengthOfRule, ref _longestRule, ref _longestRuler);
            }

            FindLongestHouseRule();
        }

        /*
         * Convert string representation to int, and calculate lenght of rule
         */
        private int GetLengthOfRule(String years)
        {
            String[] stringRule = years.Split("-");

            if (stringRule.Length != 2)
            {
                // If ruler has only one ruling year on record, it is counted as 0
                return 0;
            }
            try
            {
                int startYear = Int32.Parse(stringRule[0]);
                int endYear = 0;

                if (stringRule[1].Equals(""))
                {
                    // Special case for current ruler
                    endYear = 2020;
                }
                else
                {
                    endYear = Int32.Parse(stringRule[1]);
                }

                return endYear - startYear;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /*
         * Adding a new house to the dictionary, otherwise, add to the lenght of rule.
         */
        private void AddHouseAndRule(String house, int lengthOfRule)
        {
            if (_houses.ContainsKey(house))
            {
                _houses[house] += lengthOfRule;
                return;
            }

            _houses.Add(house, lengthOfRule);
        }

        /*
         * Identifying a rulers first name, and adding it to the list of first names
         */
        private void AddRulerToList(String fullName)
        {
            var names = fullName.Split(" ");

            if (names.Length < 1)
            {
                return;
            }

            _firstNames.Add(names[0]);
        }

        /*
         * Check if current ruler/house has a longer rule than the currently longest ruler/house. Change them out if so.
         */
        private void CompareLenghtOfRule(String name, int currentLengthOfRule, ref int longestRule, ref String longestRuler)
        {
            if (currentLengthOfRule < longestRule)
            {
                return;
            }

            longestRule = currentLengthOfRule;
            longestRuler = name;
        }

        /*
         * Run through freshly created dictionary of houses and figure out which house ruled for longest.
         */
        private void FindLongestHouseRule()
        {
            bool firstEntry = true;

            foreach (var house in _houses)
            {
                String houseName = house.Key;
                int houseRule = house.Value;
                
                if (firstEntry)
                {
                    _longestHouseRule = houseRule;
                    _longestHouseRuler = houseName;
                    firstEntry = false;
                    continue;
                }

                CompareLenghtOfRule(houseName, houseRule, ref _longestHouseRule, ref _longestHouseRuler);
            }
        }

        /*
         * Find the most frequent first name in the list
         */
        private String FindMostFrequentFirstName()
        {
            try
            {
                return _firstNames
                .GroupBy(i => i)
                .OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key)
                .First();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
