Rationals
=========

*Implementation of rational number arithmetics for .NET.*

```csharp
Rational left = (Rational) 1 / 2;
Rational right = (Rational) 1 / 4;

Rational sum = left + right; // equals to: 3 / 4
```

Supported features
------------------


- **implicit conversions** - rationals integrate seamlessly with other number types
- **unlimited precision** - rationals use `BigInteger` inside
- **canonical form** - each rational can have its canonical form (irreducible fraction where denominator is always positive)
- **comparison & equality**
- **multiple formatting options** - `ToString("C")` (canonical form), `ToString("W")` (whole + fractional part), or normal fraction format