// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CommonTypeUnions.Unions;

namespace CommonTypeUnions.Extensions;

/// <summary>
/// Extension methods for <see cref="Result{TValue, TError}"/>.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Creates a <see cref="Unions.Success{TValue}"/> result.
    /// </summary>
    /// <typeparam name="TValue">The success value type.</typeparam>
    /// <param name="value">The success value.</param>
    /// <returns>The <see cref="Unions.Success{TValue}"/>.</returns>
    public static Success<TValue> Success<TValue>(TValue value)
    {
        return new(value);
    }

    /// <summary>
    /// Creates a <see cref="Unions.Failure{TError}"/> result.
    /// </summary>
    /// <typeparam name="TError">The failure error type.</typeparam>
    /// <param name="error">The failure error.</param>
    /// <returns>The <see cref="Unions.Failure{TError}"/>.</returns>
    public static Failure<TError> Failure<TError>(TError error)
    {
        return new(error);
    }

    /// <summary>
    /// Checks if the <see cref="Result{TValue, TError}"/> is a <see cref="Unions.Success{TValue}"/> and returns the success value.
    /// </summary>
    /// <typeparam name="TValue">The success value type.</typeparam>
    /// <typeparam name="TError">The failure error type.</typeparam>
    /// <param name="union">The <see cref="Result{TValue, TError}"/>.</param>
    /// <param name="value">The value.</param>
    /// <returns>If the <see cref="Result{TValue, TError}"/> is a <see cref="Unions.Success{TValue}"/>.</returns>
    public static bool IsSuccess<TValue, TError>(this Result<TValue, TError> union, out TValue value)
    {
        var success = union.TryGetSuccess(out var successValue);
        value = successValue.Value;
        return success;
    }

    /// <summary>
    /// Checks if the <see cref="Result{TValue, TError}"/> is a <see cref="Unions.Failure{TError}"/> and returns the failure error.
    /// </summary>
    /// <typeparam name="TValue">The success value type.</typeparam>
    /// <typeparam name="TError">The failure error type.</typeparam>
    /// <param name="union">The <see cref="Result{TValue, TError}"/>.</param>
    /// <param name="error">The error.</param>
    /// <returns>If the <see cref="Result{TValue, TError}"/> is a <see cref="Unions.Failure{TError}"/>.</returns>
    public static bool IsFailure<TValue, TError>(this Result<TValue, TError> union, out TError error)
    {
        var success = union.TryGetFailure(out var failureValue);
        error = failureValue.Error;
        return success;
    }
}
