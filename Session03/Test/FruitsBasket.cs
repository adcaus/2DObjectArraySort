using System;
using System.Collections;
using System.Collections.Generic;

namespace Test
{
    public class FruitsBasket : BaseComparableClass, IComparable<FruitsBasket>
    {
        public string FruitName { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        public FruitsBasket(string fruitName, DateTime expiryDate)
        {
            if (PropertyMappingDictionary == null)
            {
                PropertyMappingDictionary = new Dictionary<int, string> {
                                                                            { 1, "Fruit Name"},
                                                                            { 2, "Expiry Date"}
                                                                        };
            }
            FruitName = fruitName;
            ExpiryDate = expiryDate;
        }

        public int CompareTo(FruitsBasket other)
        {
            switch (PropertyIndexToCompare)
            {
                case 1: return FruitName.CompareTo(other.FruitName);
                case 2: return ExpiryDate.CompareTo(other.ExpiryDate);
                default: return FruitName.CompareTo(other.FruitName);
            }
        }

        public override string ToString()
        {
            return FruitName + "\t\t" + ExpiryDate;
        }
    }
}
