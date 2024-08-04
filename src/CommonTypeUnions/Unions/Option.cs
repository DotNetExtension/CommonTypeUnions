// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CommonTypeUnions.Unions;

/// <summary>
/// A option union type used for representing an optional value.
/// </summary>
/// <typeparam name="TValue">The some value type.</typeparam>
/// <remarks>
/// This is a option union type that is implemented as closely to the proposed "Type Unions" feature to be released in a future C# version.
/// The proposal may be found <see href="https://github.com/dotnet/csharplang/blob/main/proposals/TypeUnions.md">here</see>.
/// This union type is based on the option type in that proposal, any changes to this type should be in an effort to stay consistant
/// with option section of the proposal found <see href="https://github.com/dotnet/csharplang/blob/main/proposals/TypeUnions.md#option">here</see>.
/// </remarks>
public readonly struct Option<TValue>
{
    private readonly Some<TValue>? _some;
    private readonly None? _none;

    /// <summary>
    /// The <see cref="UnionKind"/>.
    /// </summary>
    public UnionKind Kind { get; }

    /// <summary>
    /// The union kinds.
    /// </summary>
    public enum UnionKind
    {
        /// <summary>
        /// A some option.
        /// </summary>
        Some = 1,

        /// <summary>
        /// A none option.
        /// </summary>
        None = 2
    };

    /// <summary>
    /// Creates a <see cref="Option{TValue}"/> using <see cref="Some{TValue}"/>.
    /// </summary>
    /// <param name="value">The <see cref="Some{TValue}"/>.</param>
    public Option(Some<TValue> value)
    {
        Kind = UnionKind.Some;
        _some = value;
    }

    /// <summary>
    /// Creates a <see cref="Option{TValue}"/> using <see cref="None"/>.
    /// </summary>
    /// <param name="value">The <see cref="None"/>.</param>
    public Option(None value)
    {
        Kind = UnionKind.None;
        _none = value;
    }

    /// <summary>
    /// Creates a some option.
    /// </summary>
    /// <param name="value">The <see cref="Some{TValue}"/> value.</param>
    public static implicit operator Option<TValue>(Some<TValue> value)
    {
        return new(value);
    }

    /// <summary>
    /// Creates a none option.
    /// </summary>
    /// <param name="value">The <see cref="None"/> value.</param>
    public static implicit operator Option<TValue>(None value)
    {
        return new(value);
    }

    /// <summary>
    /// Gets the <see cref="Some{TValue}"/> from a option.
    /// </summary>
    /// <param name="union">The <see cref="Option{TValue}"/> to get the <see cref="Some{TValue}"/> from.</param>
    public static explicit operator Some<TValue>(Option<TValue> union)
    {
        if (union.Kind == UnionKind.Some && union._some.HasValue)
        {
            return union._some.Value;
        }
        else
        {
            throw new InvalidCastException($"Unable to cast object of type {typeof(Option<TValue>)} to type {typeof(Some<TValue>)}.");
        }
    }

    /// <summary>
    /// Gets the <see cref="None"/> from a option.
    /// </summary>
    /// <param name="union">The <see cref="Option{TValue}"/> to get the <see cref="None"/> from.</param>
    public static explicit operator None(Option<TValue> union)
    {
        if (union.Kind == UnionKind.None && union._none.HasValue)
        {
            return union._none.Value;
        }
        else
        {
            throw new InvalidCastException($"Unable to cast object of type {typeof(Option<TValue>)} to type {typeof(None)}.");
        }
    }

    /// <summary>
    /// Tries to get the <see cref="Some{TValue}"/> value.
    /// </summary>
    /// <param name="value">The <see cref="Some{TValue}"/> value.</param>
    /// <returns>If getting the value succeded.</returns>
    public bool TryGetSome(out Some<TValue> value)
    {
        if (Kind == UnionKind.Some && _some.HasValue)
        {
            value = _some.Value;
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    /// <summary>
    /// Tries to get the <see cref="None"/> value.
    /// </summary>
    /// <param name="value">The <see cref="None"/> value.</param>
    /// <returns>If getting the value succeded.</returns>
    public bool TryGetNone(out None value)
    {
        if (Kind == UnionKind.None && _none.HasValue)
        {
            value = _none.Value;
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }
}
