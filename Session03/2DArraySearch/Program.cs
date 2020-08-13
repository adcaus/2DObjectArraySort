using System;

namespace _2DArraySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortSearch = new BinarySearch2D<FruitsBasket>();

            FruitsBasket[,] fArray = 
            {
                { new FruitsBasket("Orange", new DateTime(2020, 7, 21), "CTest1"), new FruitsBasket("Apple", new DateTime(2020, 8, 1), "BTest1") },
                { new FruitsBasket("Grape", new DateTime(2020, 6, 30), "ATest1"), new FruitsBasket("Lemon", new DateTime(2020, 8, 15), "DTest1") }
            };

            Student[,] sArray =
            {
                {new Student(1, "Bob", 66.50f), new Student(2, "William", 55.60f), new Student(3, "Grace", 99.98f)},
                {new Student(4, "Graham", 99.99f), new Student(5, "Hallburn", 78.73f), new Student(6, "Ciaci", 55.43f)}
            };

            var searchVal = new FruitsBasket("Orange", new DateTime(2020, 7, 21), "CTest1");
            var cord = sortSearch.BinarySearch(fArray, "ExpiryDated", searchVal);
            Console.WriteLine("Found Value " + searchVal + " At Position: " + (cord.X) + (cord.Y));
        }
    }
}
