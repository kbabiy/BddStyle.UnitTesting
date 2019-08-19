using System;

namespace BddStyle.NUnit.Test.Examples.Plain
{
    public static class ShuffleExtensions
    {
        public static void FisherYatesShuffle<T>(this T[] array, Random rnd)
        {
            var n = array.Length;
            for (int i = 0; i < n; i++)
            {
                var r = i + rnd.Next(n - i);
                var tmp = array[r];
                array[r] = array[i];
                array[i] = tmp;
            }
        }
    }
}