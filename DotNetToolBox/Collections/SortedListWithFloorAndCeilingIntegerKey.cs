using System;
using System.Collections.Generic;

namespace DotNetToolBox.Collections
{
    public class SortedListWithFloorAndCeilingIntegerKey<TV> : SortedList<int, TV>
    {
        public void AddListItem(int floor, TV value)
        {
            Add(floor, value);
        }

        public int FloorIndexFor(int searchKey)
        {
            RaiseExceptionIfListIsEmpty();

            // If the lowest value is higher than the search key, then there is no floor value possible.
            if(Keys[0] > searchKey)
            {
                throw new ArgumentOutOfRangeException("No floor value exists. Lowest key value is higher than search key value.");
            }

            // If the search key value exists as an exact match, return its index.
            if(ContainsKey(searchKey))
            {
                return Keys.IndexOf(searchKey);
            }

            // If the search key value is greater than the highest value, then the highest value is the floor value.
            if(Keys[Count - 1] < searchKey)
            {
                return (Count - 1);
            }

            // There weren't any short-circuit solutions, so do the search.
            return FindFloorObjectIndex(searchKey);
        }

        public int FloorKeyFor(int searchKey)
        {
            return Keys[FloorIndexFor(searchKey)];
        }

        public TV FloorValueFor(int searchKey)
        {
            return Values[FloorIndexFor(searchKey)];
        }

        public int CeilingIndexFor(int searchKey)
        {
            RaiseExceptionIfListIsEmpty();

            // If the highest value is lower than the search key, then there is no ceiling value possible.
            if(Keys[Count - 1] < searchKey)
            {
                throw new ArgumentOutOfRangeException("No ceiling value exists. Highest key value is lower than search key value.");
            }

            // If the search key value exists as an exact match, return it.
            if(ContainsKey(searchKey))
            {
                return Keys.IndexOf(searchKey);
            }

            // If the search key value is lower than the lowest value, then the lowest value is the ceiling value.
            if(Keys[0] > searchKey)
            {
                return 0;
            }

            // There weren't any short-circuit solutions, so do the search.
            return (FindFloorObjectIndex(searchKey) + 1);
        }

        public int CeilingKeyFor(int searchKey)
        {
            return Keys[CeilingIndexFor(searchKey)];
        }

        public TV CeilingValueFor(int searchKey)
        {
            return Values[CeilingIndexFor(searchKey)];
        }

        private void RaiseExceptionIfListIsEmpty()
        {
            if(Count == 0)
            {
                throw new ArgumentOutOfRangeException("List does not contain any values.");
            }
        }

        private int FindFloorObjectIndex(double searchKey)
        {
            int lowIndex = 0;
            int highIndex = Count;
            int midIndex = lowIndex + ((highIndex - lowIndex) / 2);

            bool continueSearching = true;

            while(continueSearching)
            {
                midIndex = lowIndex + ((highIndex - lowIndex) / 2);

                if((midIndex == lowIndex) || (midIndex == highIndex))
                {
                    continueSearching = false;
                }
                else if(Keys[midIndex] < searchKey)
                {
                    lowIndex = midIndex;
                }
                else
                {
                    highIndex = midIndex;
                }
            }

            return midIndex;
        }
    }
}
