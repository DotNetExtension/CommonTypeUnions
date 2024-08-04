// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CommonTypeUnions.Unions;

/// <summary>
/// Represents a failure result.
/// </summary>
/// <typeparam name="TError">The failure result error type.</typeparam>
/// <param name="Error">The failure result error.</param>
public record struct Failure<TError>(TError Error);
