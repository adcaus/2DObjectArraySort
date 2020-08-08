using System;
using System.Collections.Generic;
using _2DObjectArrayLibrary;

namespace _2DObjectArray
{
    /*
     * - Class has to inherit "BaseComparableClass"
     * - Class has to assign naming dictionary in "SetPropertyTitleMappingDictionary()" method
     * - Class should override "ToString" method to get expected output
     */    
    public class FruitsBasket : BaseComparableClass
    {
        public string FruitName { get; set; }
        public DateTime ExpiryDate { get; set; }

        public FruitsBasket(string fruitName, DateTime expiryDate)
        {
            FruitName = fruitName;
            ExpiryDate = expiryDate;
        }

        /*
        // Registers a dictionary of corresponding titles for each property you want to use for sorting to "PropertyTitleDictionary".
        // Properties you do not register here cannot be used for sorting.
        */
        protected override void SetPropertyTitleMappingDictionary()
        {
            PropertyTitleDictionary = new Dictionary<string, string> {
                { "FruitName", "Fruit Name"},
                { "ExpiryDate", "Expiry Date"}
            };
        }

        public override string ToString()
        {
            return $"{FruitName}\t{ExpiryDate.Day}/{ExpiryDate.Month}/{ExpiryDate.Year}\t";
        }
    }
}
