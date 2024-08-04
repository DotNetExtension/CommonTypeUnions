// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CommonTypeUnions.Unions;

namespace CommonTypeUnions.Extensions;

/// <summary>
/// Extension methods for <see cref="Option{TValue}"/>.
/// </summary>
public static class OptionExtensions
{
    /// <summary>
    /// Creates a <see cref="Unions.Some{TValue}"/> option.
    /// </summary>
    /// <typeparam name="TValue">The some value type.</typeparam>
    /// <param name="value">The some value.</param>
    /// <returns>The <see cref="Unions.Some{TValue}"/>.</returns>
    public static Some<TValue> Some<TValue>(TValue value)
    {
        return new(value);
    }

    /// <summary>
    /// Creates a <see cref="Unions.None"/> result.
    /// </summary>
    /// <returns>The <see cref="Unions.None"/>.</returns>
    public static None None()
    {
        return Unions.None.Singleton;
    }

    /// <summary>
    /// Checks if the <see cref="Option{TValue}"/> is a <see cref="Unions.Some{TValue}"/> and returns the some value.
    /// </summary>
    /// <typeparam name="TValue">The some value type.</typeparam>
    /// <param name="union">The <see cref="Option{TValue}"/>.</param>
    /// <param name="value">The value.</param>
    /// <returns>If the <see cref="Option{TValue}"/> is a <see cref="Unions.Some{TValue}"/>.</returns>
    public static bool IsSome<TValue>(this Option<TValue> union, out TValue value)
    {
        var success = union.TryGetSome(out var someValue);
        value = someValue.Value;
        return success;
    }

    /// <summary>
    /// Checks if the <see cref="Option{TValue}"/> is a <see cref="Unions.None"/>.
    /// </summary>
    /// <typeparam name="TValue">The some value type.</typeparam>
    /// <param name="union">The <see cref="Option{TValue}"/>.</param>
    /// <returns>If the <see cref="Option{TValue}"/> is a <see cref="Unions.None"/>.</returns>
    public static bool IsNone<TValue>(this Option<TValue> union)
    {
        return union.TryGetNone(out var _);
    }
}
