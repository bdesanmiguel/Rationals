﻿using System;
using System.Globalization;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture(Category = "Approximation")]
    public class ApproximateTests
    {
        [TestCase(0.333f, 0.0001f, 333, 1000, Category = "ApproximateFloat")]
        [TestCase(-0.333f, 0.0001f, -333, 1000, Category = "ApproximateFloat")]
        [TestCase(0.333f, 0.001f, 1, 3, Category = "ApproximateFloat")]
        [TestCase(-0.333f, 0.001f, -1, 3, Category = "ApproximateFloat")]
        [TestCase(2.5f, 0f, 5, 2, Category = "ApproximateFloat")]
        [TestCase(-2.5f, 0f, -5, 2, Category = "ApproximateFloat")]
        [TestCase(-1f, 0f, -1, 1, Category = "ApproximateFloat")]
        [TestCase(1f, 0f, 1, 1, Category = "ApproximateFloat")]
        public void ApproximateFloat(float input, float tolerance, int expectedNumerator, int expectedDenominator)
        {
            // action
            var rational = Rational.Approximate(input, tolerance);

            // assert
            Assert.AreEqual((Rational) expectedNumerator / expectedDenominator, rational);
        }

        [TestCase(0.333d, 0.0001d, 333, 1000, Category = "ApproximateDouble")]
        [TestCase(-0.333d, 0.0001d, -333, 1000, Category = "ApproximateDouble")]
        [TestCase(0.333d, 0.001d, 1, 3, Category = "ApproximateDouble")]
        [TestCase(-0.333d, 0.001d, -1, 3, Category = "ApproximateDouble")]
        [TestCase(2.5d, 0d, 5, 2, Category = "ApproximateDouble")]
        [TestCase(-2.5d, 0d, -5, 2, Category = "ApproximateDouble")]
        [TestCase(-1d, 0d, -1, 1, Category = "ApproximateDouble")]
        [TestCase(1d, 0d, 1, 1, Category = "ApproximateDouble")]
        public void ApproximateDouble(double input, double tolerance, int expectedNumerator, int expectedDenominator)
        {
            // action
            var rational = Rational.Approximate(input, tolerance);

            // assert
            Assert.AreEqual((Rational) expectedNumerator / expectedDenominator, rational);
        }

        [TestCase(3, 1, 1.42E-1, Category = "ApproximatePI")]
        [TestCase(22, 7, 1.27E-3, Category = "ApproximatePI")]
        [TestCase(333, 106, 8.33E-5, Category = "ApproximatePI")]
        [TestCase(355, 113, 2.67E-7, Category = "ApproximatePI")]
        [TestCase(103993, 33102, 5.78E-10, Category = "ApproximatePI")]
        [TestCase(104348, 33215, 3.32E-10, Category = "ApproximatePI")]
        [TestCase(208341, 66317, 1.23E-10, Category = "ApproximatePI")]
        [TestCase(312689, 99532, 2.92E-11, Category = "ApproximatePI")]
        [TestCase(833719, 265381, 8.72E-12, Category = "ApproximatePI")]
        [TestCase(1146408, 364913, 1.62E-12, Category = "ApproximatePI")]
        public void ApproximatePI(int expectedNumerator, int expectedDenominator, double tolerance)
        {
            // action
            var rational = Rational.Approximate(Math.PI, tolerance);

            // assert
            Assert.AreEqual((Rational) expectedNumerator / expectedDenominator, rational);
        }

        [TestCase("0.333", "0.0001", 333, 1000, Category = "ApproximateDecimal")]
        [TestCase("-0.333", "0.0001", -333, 1000, Category = "ApproximateDecimal")]
        [TestCase("0.333", "0.001", 1, 3, Category = "ApproximateDecimal")]
        [TestCase("-0.333", "0.001", -1, 3, Category = "ApproximateDecimal")]
        [TestCase("2.5", "0", 5, 2, Category = "ApproximateDecimal")]
        [TestCase("-2.5", "0", -5, 2, Category = "ApproximateDecimal")]
        [TestCase("-1", "0", -1, 1, Category = "ApproximateDecimal")]
        [TestCase("1", "0", 1, 1, Category = "ApproximateDecimal")]
        public void ApproximateDecimal(string inputStr, string toleranceStr, int expectedNumerator,
            int expectedDenominator)
        {
            // arrange
            var input = decimal.Parse(inputStr, CultureInfo.InvariantCulture);
            var tolerance = decimal.Parse(toleranceStr, CultureInfo.InvariantCulture);

            // action
            var rational = Rational.Approximate(input, tolerance);

            // assert
            Assert.AreEqual((Rational) expectedNumerator / expectedDenominator, rational);
        }
    }
}