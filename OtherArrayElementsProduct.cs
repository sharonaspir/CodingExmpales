using System;
using System.Collections.Generic;

namespace OtherArrayElementsProduct
{
    /// <summary>
    ///     Given an array of numbers, 
    ///     replace each number with the product of all the numbers in the array except the number itself 
    ///     *without* using division.
    ///     
    ///     Run time            - O(n)
    ///     Space complexity    - O(n) 
    /// </summary>
    class Program
    {
        /// <summary>
        ///     Testint our function using a few base cases.
        ///     And printing the outcome to console.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<int> list = new List<int> { };
            Console.WriteLine("Original Array : " + string.Join(",", list));
            Console.WriteLine("Product Array  : " + string.Join(",", Product(list.ToArray())));
            Console.WriteLine();

            list = new List<int> { 1 };
            Console.WriteLine("Original Array : " + string.Join(",", list));
            Console.WriteLine("Product Array  : " + string.Join(",", Product(list.ToArray())));
            Console.WriteLine();

            list = new List<int> { 3, 4 };
            Console.WriteLine("Original Array : " + string.Join(",", list));
            Console.WriteLine("Product Array  : " + string.Join(",", Product(list.ToArray())));
            Console.WriteLine();

            list = new List<int> { 2, 3, 4 };
            Console.WriteLine("Original Array : " + string.Join(",", list));
            Console.WriteLine("Product Array  : " + string.Join(",", Product(list.ToArray())));
            Console.WriteLine();

            list = new List<int> { 1, 2, 5, 6, 19, 5 };
            Console.WriteLine("Original Array : " + string.Join(",", list));
            Console.WriteLine("Product Array  : " + string.Join(",", Product(list.ToArray())));
            Console.WriteLine();

            list = new List<int> { 1, -2, 5, 6, 19, 5 };
            Console.WriteLine("Original Array : " + string.Join(",", list));
            Console.WriteLine("Product Array  : " + string.Join(",", Product(list.ToArray())));
            Console.WriteLine();

            Console.Read();
        }

        /// <summary>
        ///     Given an array of numbers, 
        ///     replace each number with the product of all the numbers in the array except the number itself 
        ///     *without* using division.
        ///     
        ///     Run time            - O(n)
        ///     Space complexity    - O(n) 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[] Product(int[] A)
        {
            if (A == null || A.Length < 2) return A;

            // product of all elements from 0 untill i (Including i)
            int[] productUntill = new int[A.Length];

            // product of all elements from i untill the end (Including i)
            int[] productFrom = new int[A.Length];

            productUntill[0] = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                productUntill[i] = productUntill[i - 1] * A[i];
            }

            productFrom[A.Length - 1] = A[A.Length - 1];
            for (int i = A.Length - 2; i >= 0; i--)
            {
                productFrom[i] = productFrom[i + 1] * A[i];
            }


            //  A[i] =  ( A[0] * … *  A[i-1]) * ( A[i+1] * …. * A[A.length-1] )
            //       =  productUntill[i - 1] * productFrom[i + 1]
            A[0] = productFrom[1];
            A[A.Length - 1] = productUntill[A.Length - 2];
            for (int i = 1; i < A.Length - 1; i++)
            {
                A[i] = productUntill[i - 1] * productFrom[i + 1];
            }
            return A;
        }
    }
}
