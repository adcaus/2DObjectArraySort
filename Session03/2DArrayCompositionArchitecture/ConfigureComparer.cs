using System;
using System.Collections.Generic;
using System.Linq;

namespace _2DArrayCompositionArchitecture
{
    //I just removed this as it wasn't really related to the sorting functionality this follows the 
    //S.R.P (Single Responsibility Principal) where each class should strive to do just one thing.  This makes it easier to
    //compose objects together, unit test, track down bugs and make changes!
    public class ConfigureComparer<T> where T : IComparableWithProperties
    {
        public T[,] ObjectArray { get; set; }

        public ConfigureComparer(T[,] array)
        {
            ObjectArray = array;
        }

        public void SortBySelectedField(string propertyName)
        {
            for (int i = 0; i < ObjectArray.GetLength(0) * ObjectArray.GetLength(1); i++)
            {
                ObjectArray[i / ObjectArray.GetLength(1), i % ObjectArray.GetLength(1)].RegisterProperties(i == 0);
            }

            var propDictionary = GetSortingPropertyOptions();
            if (propDictionary.ContainsKey(propertyName))
            {
                SetFieldIndexToCompare(propDictionary[propertyName].Value);
            }
        }

        private void SetFieldIndexToCompare(int index)
        {
            ObjectArray[0, 0].SetPropertyIndexToCompare(index);
        }

        private Dictionary<string, Index> GetSortingPropertyOptions()
        {
            var dictionary = new Dictionary<string, Index>();

            for (int i = 0; i < ObjectArray[0, 0].GetUsedPropertyCount(); i++)
            {
                dictionary.Add(ObjectArray[0, 0].GetPropertyTitle(i), i);
            }

            return dictionary;
        }
    }
}