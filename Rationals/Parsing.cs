﻿#region License

// Copyright (C) Tomáš Pažourek, 2014
// All rights reserved.
// 
// Distributed under MIT license as a part of project Rationals.
// https://github.com/tompazourek/Rationals

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Rationals
{
    public partial struct Rational
    {
        private static readonly Regex FractionFormat = new Regex(@"^\s*(?<Numerator>-?\d+)/(?<Denominator>-?\d+)\s*$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
        private static readonly Regex WholeFractionalFormat = new Regex(@"^\s*(?<Whole>-?\d+)\s*[+]\s*(?<Numerator>-?\d+)/(?<Denominator>-?\d+)\s*$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public static Rational Parse(string s)
        {
            Rational result;
            if (!TryParse(s, out result))
            {
                throw new FormatException("Cannot parse string as Rational, the input is in incorrect format.");
            }

            return result;
        }

        public static bool TryParse(string s, out Rational result)
        {
            result = default(BigInteger);

            try
            {
                Match match = FractionFormat.Match(s);
                if (match.Success)
                {
                    var numerator = BigInteger.Parse(match.Groups["Numerator"].Value);
                    var denominator = BigInteger.Parse(match.Groups["Denominator"].Value);
                    result = new Rational(numerator, denominator);
                    return true;
                }

                match = WholeFractionalFormat.Match(s);
                if (match.Success)
                {
                    var whole = BigInteger.Parse(match.Groups["Whole"].Value);
                    var numerator = BigInteger.Parse(match.Groups["Numerator"].Value);
                    var denominator = BigInteger.Parse(match.Groups["Denominator"].Value);
                    result = new Rational(whole) + new Rational(numerator, denominator);
                    return true;
                }
            }
            catch (DivideByZeroException)
            {
                return false;
            }

            BigInteger justWhole;
            if (BigInteger.TryParse(s, out justWhole))
            {
                result = new Rational(justWhole);
                return true;
            }

            return false;
        }

    }
}