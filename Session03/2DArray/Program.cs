using System;

namespace _2DArray
{
    class Program
    {
        static int rowCount;
        static int columnCount;
        static void Main(string[] args)
        {
            int[,] nArray = {
                                { 38, 8, 7 },
                                { 9, 12, 21 },
                                { 45, 2, 1 },
                                { 7, 19, 36 }
                            };

            rowCount = nArray.GetLength(0);
            columnCount = nArray.GetLength(1);

            DumpArray(nArray);

            for (int i = 0; i < rowCount * columnCount; i++)
            {
                int minIndex = FindMinIndex(nArray, i);
                if (minIndex != i)
                {
                    Swap(ref nArray, i, minIndex);
                }
            }

            DumpArray(nArray);
        }

        static int GetValue(int[,] nArray, int index)
        {
            return nArray[index / columnCount, index % columnCount];
        }

        static void SetValue(int[,] nArray, int index,int value)
        {
            nArray[index / nArray.GetLength(1), index % nArray.GetLength(1)] = value;
        }

        static int FindMinIndex(int[,] nArray, int startIndex)
        {
            int min = GetValue(nArray,startIndex);
            int minIndex = startIndex;

            for (int i = startIndex + 1; i < rowCount * columnCount; i++)
            {
                if (GetValue(nArray, i) < min)
                {
                    min = GetValue(nArray, i);
                    minIndex = i;
                }
            }

            return minIndex;
        }

        static void Swap(ref int[,] nArray, int i1, int i2)
        {
            int temp = GetValue(nArray, i1);
            SetValue(nArray, i1, GetValue(nArray, i2));
            SetValue(nArray, i2, temp);
        }

        static void DumpArray(int[,] nArray)
        {
            for (int i = 0; i < rowCount * columnCount; i++)
            {
                if (i % columnCount == 0)
                {
                    Console.Write("\n");
                }

                Console.Write(GetValue(nArray,i) + " ");
            }
            Console.Write("\n");
        }
    }
}
