using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace _2DObjectArrayLibrary
{
    public abstract class BaseComparableClass : IComparableWithProperties, IComparable<BaseComparableClass>
    {
        private static int PropertyCount { get; set; }
        private static int PropertyIndexToCompare { get; set; }
        private static string[] PropertyNameMappingArray { get; set; }
        public List<IComparable> UsedPropertyValueArray { get; set; }
        protected static Dictionary<string, string> PropertyTitleDictionary { get; set; }
        private static List<string> UsedPropertyNameArray { get; set; }

        protected BaseComparableClass()
        {
            UsedPropertyNameArray = new List<string>();
            PropertyTitleDictionary = new Dictionary<string, string>();
            UsedPropertyValueArray = new List<IComparable>();
        }

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
                Initialize(propertiesArray);
            }

            foreach (var usedName in UsedPropertyNameArray)
            {
                foreach (var property in propertiesArray)
                {
                    if (property.Name == usedName)
                    {
                        UsedPropertyValueArray.Add(property.GetValue(this) as IComparable);
                        break;
                    }
                }
            }
        }

        private void Initialize(PropertyInfo[] propertiesArray)
        {
            UsedPropertyNameArray = new List<string>();

            PropertyNameMappingArray = new string[PropertyCount];
            for (int i = 0; i < PropertyCount; i++)
            {
                PropertyNameMappingArray[i] = propertiesArray[i].Name;
            }

            SetPropertyTitleMappingDictionary();

            //This Step is Unnecessary if we use a list as we are not required to initialize it with a particular length - woohoo!  
            //for (int i = 0; i < PropertyCount; i++)
            //{
            //    if (PropertyTitleDictionary.ContainsKey(PropertyNameMappingArray[i]))
            //    {
            //        matchedPropertyCount++;
            //    }
            //}

            foreach (var propertyName in PropertyNameMappingArray)
            {
                if (PropertyTitleDictionary.ContainsKey(propertyName))
                {
                    UsedPropertyNameArray.Add(propertyName);
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
