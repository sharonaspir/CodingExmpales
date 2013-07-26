using System;

namespace CircularSortedArraySearch
{
    /// <summary>
    ///     Find the index of a element in a circular sorted array.
    ///     
    ///     Run time            - O( log(n) ).
    ///     Space complexity    - O( 1 ).
    /// </summary>
    class CircularSortedArraySearch
    {
        static void Main(string[] args)
        {
            int[] A = new int[0];
            int index = FindIndexInCircularArray(5, A);
            Console.WriteLine("A: [{0}]. \nVal = {1} . index = {2}.\n", string.Join(",", A), 5, index);

            A = new int[3] { 5, 5, 5 };
            index = FindIndexInCircularArray(5, A);
            Console.WriteLine("A: [{0}]. \nVal = {1} . index = {2}.\n", string.Join(",", A), 5, index);

            A = new int[6] { 1, 2, 3, 4, 5, 6 };
            index = FindIndexInCircularArray(5, A);
            Console.WriteLine("A: [{0}]. \nVal = {1} . index = {2}.\n", string.Join(",", A), 5, index);

            A = new int[10] { 7, 8, 9, 10, 1, 2, 3, 4, 4, 6 };
            index = FindIndexInCircularArray(5, A);
            Console.WriteLine("A: [{0}]. \nVal = {1} . index = {2}.\n", string.Join(",", A), 5, index);

            A = new int[3] { 5, 5, 5 };
            index = FindIndexInCircularArray(15, A);
            Console.WriteLine("A: [{0}]. \nVal = {1} . index = {2}.\n", string.Join(",", A), 15, index);

            A = new int[3] { 5, 5, 5 };
            index = FindIndexInCircularArray(-15, A);
            Console.WriteLine("A: [{0}]. \nVal = {1} . index = {2}.\n", string.Join(",", A), -15, index);

            A = new int[9] { 5, 5, 5, 5, 5, 5, 0, 5, 5 };
            index = FindIndexInCircularArray(0, A);
            Console.WriteLine("A: [{0}]. \nVal = {1} . index = {2}.\n", string.Join(",", A), 0, index);

            Console.Read();
        }

        /// <summary>
        ///     Finds Index of input int in circular sorted Array
        /// </summary>
        /// <param name="value">
        ///     Searched int.
        /// </param>
        /// <param name="A">
        ///     Circular sorted Array
        /// </param>
        /// <returns>
        ///     Index of input int in circular sorted Array
        /// </returns>
        public static int FindIndexInCircularArray(int value, int[] A)
        {
            if (A == null || A.Length == 0)
            {
                return -1;
            }
            int left = 0;
            int right = A.Length - 1;

            // While there are more elements in our segment
            while (left < right)
            {
                int middle = (left + right) / 2;

                // Value found
                if (A[middle] == value) return middle;

                if (A[left] <= A[middle]) // left side is sorted
                {
                    if (A[left] < value && A[middle] > value) // value in this range
                    {
                        right = middle - 1;
                    }
                    else // value not in range - it is in the second segment
                    {
                        left = middle + 1;
                    }
                }
                else // right side is sorted
                {
                    if (A[middle + 1] < value && A[right] > value) // value in this range
                    {
                        left = middle + 1;
                    }
                    else // value not in range - it is in the second segment
                    {
                        right = middle - 1;
                    }
                }
            }
            return -1; // Element not in array
        }
    }
}
