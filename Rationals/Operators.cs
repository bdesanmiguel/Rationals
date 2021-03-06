﻿#region License

// Copyright (C) Tomáš Pažourek, 2016
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

namespace Rationals
{
    public partial struct Rational
    {
        public static Rational operator +(Rational left, Rational right)
        {
            return Add(left, right);
        }

        public static Rational operator -(Rational p)
        {
            return Negate(p);
        }

        public static Rational operator -(Rational left, Rational right)
        {
            return Subtract(left, right);
        }

        public static Rational operator *(Rational left, Rational right)
        {
            return Multiply(left, right);
        }

        public static Rational operator /(Rational left, Rational right)
        {
            return Divide(left, right);
        }

        public static Rational operator ++(Rational p)
        {
            return p + One;
        }

        public static Rational operator --(Rational p)
        {
            return p - One;
        }

        public static bool operator ==(Rational left, Rational right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Rational left, Rational right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Rational left, Rational right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Rational left, Rational right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Rational left, Rational right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Rational left, Rational right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}