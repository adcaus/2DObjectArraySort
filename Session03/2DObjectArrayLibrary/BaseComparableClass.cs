using System;
using System.Collections.Generic;
using System.Globalization;

namespace _2DObjectArrayLibrary
{
    public abstract class BaseComparableClass : IComparableWithProperties, IComparable<BaseComparableClass>
    {
        /// <summary>
        /// <para>The number of properties the class has.</para>
        /// <para>For "FruitsBasket" class will be 4 ("FruitName", "Amount", "ExpiryDate" and "UsedPropertyValueArray"(non-static property of this class))</para>
        /// </summary>
        public static int PropertyCount { get; set; }
        /// <summary>
        /// <para>For "FruitsBasket" will be {"FruitName", "Amount", "ExpiryDate", "UsedPropertyValueArray"}</para>
        /// </summary>
        private static string[] PropertyNameArray { get; set; }
        /// <summary>
        /// <para>Corresponding titles for properties to be used for sorting.</para>
        /// <para>For "FruitsBasket" class will be {{"FruitName": "Fruit Name"}, {"ExpiryDate": "Expiry Date"} }</para>
        /// </summary>
        public static Dictionary<string, string> PropertyTitleDictionary { get; set; }
        /// <summary>
        /// <para>The number of properties which can be used for sorting.</para>
        /// <para>Depends on "PropertyTitleDictionay" property 
        /// which should be defined in each derived class in its "SetPropertyTitleDictionary()" method.</para>
        /// <para>For "FruitsBasket" class will be 2 ("FruitName" and "ExpiryDate" which are defined in "PropertyTitleDictionay" property)</para>
        /// </summary>
        public static int UsedPropertyCount { get; set; }
        /// <summary>
        /// <para>For "FruitBasket" will be {"FruitName", "ExpiryDate"}</para>
        /// </summary>
        public static string[] UsedPropertyNameArray { get; set; }
        /// <summary>
        /// <para>The values of properties to be used for sorting of each object</para>
        /// <para>For "Orange" object of "FruitsBasket" class will be {"Orange", new DateTime(2020, 7, 21)}</para>
        /// </summary>
        public IComparable[] UsedPropertyValueArray { get; set; }
        /// <summary>
        /// <para>Index to be used to define which property to used for sorting by user input.</para>
        /// <para>For "FruitBasket" class can be 0("FruitName") or 1("ExpiryDate")</para>
        /// </summary>
        public static int PropertyIndexToCompare { get; set; }
        
        // Get and Set methods for static properties
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

        protected abstract void SetPropertyTitleDictionary();

        /// <summary>
        /// Defines properties related information for UI and sorting.
        /// </summary>
        public void RegisterProperties(bool isFirstElement)
        {
            var propertiesArray = this.GetType().GetProperties();
            PropertyCount = propertiesArray.Length;

            if (isFirstElement)
            {
                // Update static properties
                PropertyNameArray = new string[PropertyCount];
                for (int i = 0; i < PropertyCount; i++)
                {
                    PropertyNameArray[i] = propertiesArray[i].Name;
                }

                SetPropertyTitleDictionary();
                int matchedPropertyCount = 0;

                for (int i = 0; i < PropertyCount; i++)
                {
                    if (PropertyTitleDictionary.ContainsKey(PropertyNameArray[i]))
                    {
                        matchedPropertyCount++;
                    }
                }

                UsedPropertyNameArray = new string[matchedPropertyCount];
                UsedPropertyCount = matchedPropertyCount;

                for (int i = 0, j = 0; i < PropertyCount; i++)
                {
                    if (PropertyTitleDictionary.ContainsKey(PropertyNameArray[i]))
                    {
                        UsedPropertyNameArray[j] = PropertyNameArray[i];
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
