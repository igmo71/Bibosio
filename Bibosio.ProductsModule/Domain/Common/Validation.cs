﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Bibosio.ProductsModule.Domain.Common
{
    internal static class Validation
    {
        public static string AssertNotEmpty(this string? value,
            [CallerArgumentExpression(nameof(value))] string? argumentName = null)
        {
            return !string.IsNullOrWhiteSpace(value) 
                ? value 
                : throw new ArgumentOutOfRangeException(argumentName);
        }

        public static string AssertMatchesRegex(this string value, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern,
            [CallerArgumentExpression(nameof(value))] string? argumentName = null)
        {
            return Regex.IsMatch(value.AssertNotEmpty(), pattern)
                ? value
                : throw new ArgumentOutOfRangeException(argumentName);
        }
    }
}
