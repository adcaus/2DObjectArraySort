using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            FruitsBasket[,] fArray = {
                                        { new FruitsBasket("Orange", new DateTime(2020, 7, 21)), new FruitsBasket("Apple", new DateTime(2020, 8, 1)) },
                                        { new FruitsBasket("Grape", new DateTime(2020, 6, 30)), new FruitsBasket("Pineapple", new DateTime(2020, 8, 15)) }
                                     };

            int[,] nArray = {
                                { 8, 2, 10},
                                { 1, 3, 2 },
                                { 5, 4, 6 }
                            };

            fArray.DumpArray();
            fArray.SortBySelectedField();
            fArray.DumpArray();

            nArray.DumpArray();
            nArray.Sort();
            nArray.DumpArray();
        }
    }
}
