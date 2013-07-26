using System;
using System.Collections.Generic;

namespace AllSubSets
{
    /// <summary>
    ///     Compute all sub-sets of a string.
    ///     ** With out Recursion.
    /// </summary>
    class AllSubSets
    {
        static void Main(string[] args)
        {
            string set = "abcd";
            LinkedList<string> allSubSets = GetAllSubSets(set);

            Console.WriteLine("Original set is [{0}], All sub sets:", set);
            foreach (string subset in allSubSets)
            {
                 Console.WriteLine("[{0}]", subset);
            }

            Console.Read();
        }

        /// <summary>
        ///     Retrun a linked list of all the input set sub-sets.
        ///     ** With out Recursion.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static LinkedList<string> GetAllSubSets(string str)
        {
            LinkedList<string> allSets = new LinkedList<string>();

            // The empty group is a subset to all sets
            allSets.AddLast("");

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                // We will copy all the sets, and add the new char to them
                LinkedList<string> allSetsWithC = new LinkedList<string>();

                foreach (string set in allSets)
                {
                    allSetsWithC.AddLast(set);
                }

                // Add all new sets to the subset list
                foreach (string set in allSetsWithC)
                {
                    allSets.AddLast(set + c);
                }
            }
            return allSets;
        }
    }
}
