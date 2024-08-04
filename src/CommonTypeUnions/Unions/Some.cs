// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CommonTypeUnions.Unions;

/// <summary>
/// Represents a some option.
/// </summary>
/// <typeparam name="TValue">The some option value type.</typeparam>
/// <param name="Value">The some option value.</param>
public record struct Some<TValue>(TValue Value);
