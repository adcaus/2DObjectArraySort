using System;
using System.Collections.Generic;
using System.Globalization;

namespace _2DObjectArrayLibrary
{
    public abstract class BaseComparableClass : IComparableWithProperties, IComparable<BaseComparableClass>
    {
        public static int PropertyCount { get; set; }
        public static int UsedPropertyCount { get; set; }
        public static int PropertyIndexToCompare { get; set; }
        public static string[] PropertyNameMappingArray { get; set; }
        public IComparable[] UsedPropertyValueArray { get; set; }
        public static Dictionary<string, string> PropertyTitleDictionary { get; set; }
        public static string[] UsedPropertyNameArray { get; set; }

        public void SetPropertyIndexToCompare(int index)
        {
            PropertyIndexToCompare = index;
        }

        public int GetUsedPropertyCount()
        {
            return PropertyTitleDictionary.Count;
        }

        public string GetPropertyTitle(int index)
        {
            return PropertyTitleDictionary[UsedPropertyNameArray[index]];
        }

        protected abstract void SetPropertyTitleMappingDictionary();

        /// <summary>
        /// Defines properties related information for UI and sorting.
        /// </summary>
        public void RegisterProperties(bool isFirstElement)
        {
            var propertiesArray = this.GetType().GetProperties();
            PropertyCount = propertiesArray.Length;


            if (isFirstElement)
            {
                PropertyNameMappingArray = new string[PropertyCount];
                for (int i = 0; i < PropertyCount; i++)
                {
                    PropertyNameMappingArray[i] = propertiesArray[i].Name;
                }

                SetPropertyTitleMappingDictionary();
                int matchedPropertyCount = 0;

                for (int i = 0; i < PropertyCount; i++)
                {
                    if (PropertyTitleDictionary.ContainsKey(PropertyNameMappingArray[i]))
                    {
                        matchedPropertyCount++;
                    }
                }

                UsedPropertyNameArray = new string[matchedPropertyCount];
                UsedPropertyCount = matchedPropertyCount;

                for (int i = 0, j = 0; i < PropertyCount; i++)
                {
                    if (PropertyTitleDictionary.ContainsKey(PropertyNameMappingArray[i]))
                    {
                        UsedPropertyNameArray[j] = PropertyNameMappingArray[i];
                        j++;
                    }
                }
            }

            UsedPropertyValueArray = new IComparable[UsedPropertyCount];

            for (int i = 0; i < UsedPropertyCount; i++)
            {
                foreach (var property in propertiesArray)
                {
                    if (property.Name == UsedPropertyNameArray[i])
                    {
                        UsedPropertyValueArray[i] = property.GetValue(this) as IComparable;
                        break;
                    }
                }
            }
        }

        public int CompareTo(BaseComparableClass other)
        {
            IComparable valueToBeCompared = UsedPropertyValueArray[PropertyIndexToCompare];
            IComparable valueToCompare = other.UsedPropertyValueArray[PropertyIndexToCompare];
            return valueToBeCompared.CompareTo(valueToCompare);
        }
    }
}
