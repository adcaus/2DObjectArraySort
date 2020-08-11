using System;
using System.Collections.Generic;
using System.Reflection;

namespace _2DArrayCompositionArchitecture
{
    //This is still pretty much the same.  I just changed some for loops into foreach loops for ease of readability!
    public abstract class BaseComparableClass : IComparableWithProperties, IComparable<BaseComparableClass>
    {
        private static int PropertyCount { get; set; }
        private static int PropertyIndexToCompare { get; set; }
        private static string[] PropertyNameMappingArray { get; set; }
        public List<IComparable> UsedPropertyValueArray { get; set; }
        public Dictionary<string, string> AvailableProperties { get; set; }
        protected static Dictionary<string, string> PropertyTitleDictionary { get; set; }
        public static List<string> UsedPropertyNameArray { get; set; }

        protected BaseComparableClass()
        {
            UsedPropertyNameArray = new List<string>();
            PropertyTitleDictionary = new Dictionary<string, string>();
            UsedPropertyValueArray = new List<IComparable>();
            InitializeAvailablePropertiesFromPropertyDictionary();
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

        private void InitializeAvailablePropertiesFromPropertyDictionary()
        {
            SetPropertyTitleMappingDictionary();
            AvailableProperties = PropertyTitleDictionary;
        }

        protected abstract void SetPropertyTitleMappingDictionary();

        public Dictionary<string, string> GetAvailableProperties()
        {
            return AvailableProperties;
        }

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
