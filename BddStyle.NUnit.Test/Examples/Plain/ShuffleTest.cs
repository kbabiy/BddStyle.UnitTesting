using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace BddStyle.NUnit.Test.Examples.Plain
{
    [TestFixture]
    public class ShuffleTest
    {
        [Test, Category("Unit")]
        [Description("Testing Fisher-Yates shuffle algorithm by validating the output size and randomness")]
        public void FisherYatesShuffleTest()
        {
            //Arrange
            const int n = 10;
            var source = Enumerable.Range(1, n).ToArray();
            var rnd = new Random(1);

            //Act
            var result = new int[n];
            Array.Copy(source, result, n);
            result.FisherYatesShuffle(rnd);

            //Assert
            result.Should().NotBeNullOrEmpty();
            result.Length.Should().Be(n);
            
            var join = source.Join(result, x => x, y => y, (x1, y1) => new {x1, y1}).ToArray();
            join.Length.Should().Be(n, "All result elements should match source elements");

            var difference = source.Where((sourceItem, index) => sourceItem != result[index]).Count();
            difference.Should().BeGreaterOrEqualTo(n / 2, "At least half of elements should differ");
        }

    }
}