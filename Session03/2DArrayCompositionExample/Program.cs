using System;
using _2DArrayCompositionArchitecture;

namespace _2DArrayCompositionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            FruitsBasket[,] fArray = {
                { new FruitsBasket("Orange", new DateTime(2020, 7, 21), "CTest1"), new FruitsBasket("Apple", new DateTime(2020, 8, 1), "BTest1") },
                { new FruitsBasket("Grape", new DateTime(2020, 6, 30), "ATest1"), new FruitsBasket("Lemon", new DateTime(2020, 8, 15), "DTest1") }
            };

            Country[,] cArray = {
                { new Country("US", 331, 87_265_226), new Country("Japan", 126, 5_154_475), new Country("Australia", 25, 1_376_255)},
                { new Country("China", 1_439, 14_140_163), new Country("Spain", 46, 1_397_870), new Country("India", 1_380, 2_935_570)}
            };

            //This is our Factory that returns a ready instance of the sorter ready to sort.  
            var sorter = SortingAlgorithmFactory.CreateSorter(cArray, SortingAlgorithm.Quick);

            //Here the console interface is separated from our main class as this logic is not really related
            //To the sorting or comparison logic
            var console = new ConsoleInterface<Country>(cArray);

            //The Dump method should also be removed in production however i have left it in for convenience!
            sorter.Dump();
            sorter.SortBySelectedField(console.GetUserChoice());
            sorter.Dump();
        }
    }
}
