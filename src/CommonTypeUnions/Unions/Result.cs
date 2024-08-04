// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CommonTypeUnions.Unions;

/// <summary>
/// A result union type used for returning and propagating errors.
/// </summary>
/// <typeparam name="TValue">The success value type.</typeparam>
/// <typeparam name="TError">The failure error type.</typeparam>
/// <remarks>
/// This is a result union type that is implemented as closely to the proposed "Type Unions" feature to be released in a future C# version.
/// The proposal may be found <see href="https://github.com/dotnet/csharplang/blob/main/proposals/TypeUnions.md">here</see>.
/// This union type is based on the result type in that proposal, any changes to this type should be in an effort to stay consistant
/// with result section of the proposal found <see href="https://github.com/dotnet/csharplang/blob/main/proposals/TypeUnions.md#result">here</see>.
/// </remarks>
public readonly struct Result<TValue, TError>
{
    private readonly Success<TValue>? _success;
    private readonly Failure<TError>? _failure;

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
        /// A successful result.
        /// </summary>
        Success = 1,

        /// <summary>
        /// A failure result.
        /// </summary>
        Failure = 2
    };

    /// <summary>
    /// Creates a <see cref="Result{TValue, TError}"/> using a <see cref="Success{TValue}"/>.
    /// </summary>
    /// <param name="value">The <see cref="Success{TValue}"/>.</param>
    public Result(Success<TValue> value)
    {
        Kind = UnionKind.Success;
        _success = value;
    }

    /// <summary>
    /// Creates a <see cref="Result{TValue, TError}"/> using a <see cref="Failure{TError}"/>.
    /// </summary>
    /// <param name="value">The <see cref="Failure{TError}"/>.</param>
    public Result(Failure<TError> value)
    {
        Kind = UnionKind.Failure;
        _failure = value;
    }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    /// <param name="value">The <see cref="Success{TValue}"/> value.</param>
    public static implicit operator Result<TValue, TError>(Success<TValue> value)
    {
        return new(value);
    }

    /// <summary>
    /// Creates a failure result.
    /// </summary>
    /// <param name="value">The <see cref="Failure{TError}"/> value.</param>
    public static implicit operator Result<TValue, TError>(Failure<TError> value)
    {
        return new(value);
    }

    /// <summary>
    /// Gets the <see cref="Success{TValue}"/> from a result.
    /// </summary>
    /// <param name="union">The <see cref="Result{TValue, TError}"/> to get the <see cref="Success{TValue}"/> from.</param>
    public static explicit operator Success<TValue>(Result<TValue, TError> union)
    {
        if (union.Kind == UnionKind.Success && union._success.HasValue)
        {
            return union._success.Value;
        }
        else
        {
            throw new InvalidCastException($"Unable to cast object of type {typeof(Result<TValue, TError>)} to type {typeof(Success<TValue>)}.");
        }
    }

    /// <summary>
    /// Gets the <see cref="Failure{TError}"/> from a result.
    /// </summary>
    /// <param name="union">The <see cref="Result{TValue, TError}"/> to get the <see cref="Failure{TError}"/> from.</param>
    public static explicit operator Failure<TError>(Result<TValue, TError> union)
    {
        if (union.Kind == UnionKind.Failure && union._failure.HasValue)
        {
            return union._failure.Value;
        }
        else
        {
            throw new InvalidCastException($"Unable to cast object of type {typeof(Result<TValue, TError>)} to type {typeof(Failure<TError>)}.");
        }
    }

    /// <summary>
    /// Tries to get the <see cref="Success{TValue}"/> value.
    /// </summary>
    /// <param name="value">The <see cref="Success{TValue}"/> value.</param>
    /// <returns>If getting the value succeded.</returns>
    public bool TryGetSuccess(out Success<TValue> value)
    {
        if (Kind == UnionKind.Success && _success.HasValue)
        {
            value = _success.Value;
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }

    /// <summary>
    /// Tries to get the <see cref="Failure{TError}"/> value.
    /// </summary>
    /// <param name="value">The <see cref="Failure{TError}"/> value.</param>
    /// <returns>If getting the value succeded.</returns>
    public bool TryGetFailure(out Failure<TError> value)
    {
        if (Kind == UnionKind.Failure && _failure.HasValue)
        {
            value = _failure.Value;
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }
}
