using System;
using System.Collections.Generic;
using _2DArrayCompositionArchitecture;

namespace _2DArrayCompositionExample
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
        public string NewProp { get; set; }

        public FruitsBasket(string fruitName, DateTime expiryDate, string newProp)
        {
            FruitName = fruitName;
            ExpiryDate = expiryDate;
            NewProp = newProp;
        }

        /*
        // Registers a dictionary of corresponding titles for each property you want to use for sorting to "PropertyTitleDictionary".
        // Properties you do not register here cannot be used for sorting. - This is nice :D
        */
        protected override void SetPropertyTitleMappingDictionary()
        {
            //By using nameof() we don't have to use "Magic Strings" which makes it more robust.  
            //If we want to change the name of a property we can and dont have to worry about changing the string here!
            PropertyTitleDictionary = new Dictionary<string, string> {
                { nameof(FruitName), "FruitName" },
                { nameof(ExpiryDate), "ExpiryDate"},
                { nameof(NewProp), "NewProp" }
            };
        }

        public override string ToString()
        {
            return $"{FruitName}\t{ExpiryDate.Day}/{ExpiryDate.Month}/{ExpiryDate.Year}/{NewProp}\t";
        }
    }
}
