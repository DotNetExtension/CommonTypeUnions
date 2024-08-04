// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CommonTypeUnions.Unions;

/// <summary>
/// Represents a none option.
/// </summary>
public readonly record struct None
{
    /// <summary>
    /// The singleton instance.
    /// </summary>
    public static readonly None Singleton;
}
