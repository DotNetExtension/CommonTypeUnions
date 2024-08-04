// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CommonTypeUnions.Unions;

/// <summary>
/// Represents a success result.
/// </summary>
/// <typeparam name="TValue">The success result value type.</typeparam>
/// <param name="Value">The success result value.</param>
public record struct Success<TValue>(TValue Value);
