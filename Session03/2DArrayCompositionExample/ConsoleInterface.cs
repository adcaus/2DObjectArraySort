using System;
using System.Collections.Generic;
using System.Linq;
using _2DArrayCompositionArchitecture;

namespace _2DArrayCompositionExample
{
    public class ConsoleInterface<T> where T : BaseComparableClass, IComparableWithProperties, IComparable<T>
    {
        public List<string> propertyNames;

        public ConsoleInterface(T[,] array)
        {
            var instance = array[0,0];
            var dic = instance.GetAvailableProperties();
            this.propertyNames = dic.Keys.ToList();
        }

        public string GetUserChoice()
        {
            string userInput;
            bool isInvalid = false;

            do
            {
                if (isInvalid)
                {
                    Console.WriteLine("\n******************\nINVALID INPUT\n******************\n");
                }

                Console.WriteLine("Sort By ?\n");

                foreach (var property in propertyNames)
                {
                    Console.WriteLine($"{property}");
                }

                Console.WriteLine();

                userInput = Console.ReadLine();
            } 
            while (!Validate(userInput, ref isInvalid));

            return userInput;
        }

        private bool Validate(string userInput, ref bool isInvalid)
        {
            if (!propertyNames.Contains(userInput))
            {
                isInvalid = true;
                return false;
            }
            else
            {
                isInvalid = false;
                return true;
            }
        }
    }
}
