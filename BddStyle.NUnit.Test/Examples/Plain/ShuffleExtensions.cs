using System;

namespace BddStyle.NUnit.Test.Examples.Plain
{
    public static class ShuffleExtensions
    {
        public static void FisherYatesShuffle<T>(this T[] array, Random rnd)
        {
            var n = array.Length;
            for (var i = 0; i < n; i++)
            {
                var r = i + rnd.Next(n - i);
                (array[r], array[i]) = (array[i], array[r]);
            }
        }
    }
}