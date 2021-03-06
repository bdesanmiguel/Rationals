﻿#region License

// Copyright (C) Tomáš Pažourek, 2016
// All rights reserved.
// 
// Distributed under MIT license as a part of project Rationals.
// https://github.com/tompazourek/Rationals

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace Rationals
{
    public partial struct Rational : IFormattable
    {
        /// <summary>
        /// Enumerates significant digits of the rational number.
        /// Omits leading and trailing zeros (only exception is number zero).
        /// </summary>
        /// <remarks>
        /// To see the right magnitude, see <seealso cref="Magnitude" /> (e.g. for writing in scientific notation).
        /// </remarks>
        public IEnumerable<char> Digits
        {
            get
            {
                var numerator = BigInteger.Abs(Numerator);
                var denominator = BigInteger.Abs(Denominator);
                var removeLeadingZeros = true;
                var returnedAny = false;
                while (numerator > 0)
                {
                    BigInteger rem;
                    var divided = BigInteger.DivRem(numerator, denominator, out rem);

                    var digits = divided.ToString(CultureInfo.InvariantCulture);

                    if (rem == 0)
                        digits = digits.TrimEnd('0'); // remove trailing zeros

                    foreach (var digit in digits)
                    {
                        if (removeLeadingZeros && digit == '0')
                            continue;

                        yield return digit;
                        removeLeadingZeros = false;
                        returnedAny = true;
                    }

                    numerator = rem * 10;
                }

                if (!returnedAny)
                    yield return '0';
            }
        }

        /// <summary>
        /// Formats rational number to string
        /// </summary>
        /// <param name="format">F for normal fraction, C for canonical fraction, W for whole+fractional</param>
        /// <param name="formatProvider">Ignored, custom format providers are not supported</param>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToString(format);
        }

        /// <summary>
        /// Formats rational number to string
        /// </summary>
        /// <param name="format">F for normal fraction, C for canonical fraction, W for whole+fractional</param>
        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format)) format = "F";

            switch (format.ToUpperInvariant())
            {
                case "F": // normal fraction
                    return ToString();

                case "W": // as whole + fractional part
                {
                    var whole = WholePart;
                    var fraction = FractionPart.CanonicalForm;
                    if (whole.IsZero)
                        return fraction.ToString();

                    if (fraction.IsZero)
                        return whole.ToString();

                    return string.Format(CultureInfo.InvariantCulture, "{0} + {1}", whole, fraction);
                }
                case "C": // in canonical form
                    return CanonicalForm.ToString();
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }

        public override string ToString()
        {
            if (Denominator.IsOne)
                return Numerator.ToString();

            if (Numerator.IsZero)
                return 0.ToString(CultureInfo.InvariantCulture);

            return string.Format(CultureInfo.InvariantCulture, "{0}/{1}", Numerator, Denominator);
        }
    }
}