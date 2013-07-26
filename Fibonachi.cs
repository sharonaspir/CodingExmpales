using System;

namespace Fibonachi
{
    /// <summary>
    ///     This program will computer Fibonachi, 
    ///     And show the different run time with and with out 
    /// </summary>
    class Program
    {
        #region Private Members

        // Number of fibonachi numbers to compute (long run)
        private static int longFibonachiLength = 100;

        // Number of fibonachi numbers to compute (short run)
        private static int shortFibonachiLength = 15;

        // Counter for the number of function call made
        private static int callsCounter = 0;

        // Array of doubles, to remember all the fibonachi outcomes so far
        private static double[] fibMem = new double[longFibonachiLength];

        #endregion Private Members

        static void Main(string[] args)
        {
            for (int i = 0; i < longFibonachiLength; i++)
            {
                Console.WriteLine("Fib " + i + " = " + GetNFibonachi(i, true));
            }
            Console.WriteLine("#Calls to computer first {0} Fibonachis (with Memoization) = {1}", longFibonachiLength, callsCounter);

            callsCounter = 0;
            for (int i = 0; i < shortFibonachiLength; i++)
            {
                Console.WriteLine("Fib " + i + " = " + GetNFibonachi(i, false));
            }
            Console.WriteLine("#Calls to computer first {0} Fibonachi (no Memoization) = {1}", shortFibonachiLength, callsCounter);

            Console.Read();
        }

        /// <summary>
        ///     Compute Fibonachi for n
        /// </summary>
        /// <param name="n"></param>
        /// <param name="useMemoization">
        ///     True if the user wishes to use memoization
        /// </param>
        /// <returns>
        ///     Fibonachi for n
        /// </returns>
        public static double GetNFibonachi(int n, bool useMemoization)
        {
            // Add 1 to call counter
            callsCounter++;

            //  Base cases
            if (n <= 0) return 0;
            if (n == 1) return 1;

            if (useMemoization && fibMem[n] != 0)
            {
                // This fibonachi result was already computed
                return fibMem[n];
            }
            else
            {
                double fibN = GetNFibonachi(n - 1, useMemoization) + GetNFibonachi(n - 2, useMemoization);
                if (useMemoization) fibMem[n] = fibN;
                return fibN;
            }
        }
    }
}
