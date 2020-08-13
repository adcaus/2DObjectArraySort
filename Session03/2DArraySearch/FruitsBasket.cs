using System;

namespace _2DArraySearch
{
    /*
     * - Class has to inherit "BaseComparableClass"
     * - Class has to assign naming dictionary in "SetPropertyTitleMappingDictionary()" method
     * - Class should override "ToString" method to get expected output
     */    
    public class FruitsBasket
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

        public override string ToString()
        {
            return $"{FruitName}\t{ExpiryDate.Day}/{ExpiryDate.Month}/{ExpiryDate.Year}/{NewProp}\t";
        }
    }
}
