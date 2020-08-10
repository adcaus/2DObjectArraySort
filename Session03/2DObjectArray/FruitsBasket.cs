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
        public int Amount { get; set; }
        public DateTime ExpiryDate { get; set; }

        public FruitsBasket(string fruitName, int amount, DateTime expiryDate)
        {
            FruitName = fruitName;
            Amount = amount;
            ExpiryDate = expiryDate;
        }

        /*
        // Registers a dictionary of corresponding titles for each property you want to use for sorting to "PropertyTitleDictionary".
        // Properties you do not register here cannot be used for sorting.
        */
        protected override void SetPropertyTitleDictionary()
        {
            PropertyTitleDictionary = new Dictionary<string, string> {
                { "FruitName", "Fruit Name"},
                // { "Amount", "Amount" },
                { "ExpiryDate", "Expiry Date"}
            };
        }

        public override string ToString()
        {
            return $"{FruitName}\t{Amount}\t{ExpiryDate.Day}/{ExpiryDate.Month}/{ExpiryDate.Year}\t";
        }
    }
}
