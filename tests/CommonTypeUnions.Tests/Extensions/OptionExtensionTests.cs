// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using static CommonTypeUnions.Extensions.OptionExtensions;
using CommonTypeUnions.Extensions;
using CommonTypeUnions.Unions;
using Xunit;

namespace CommonTypeUnions.Tests.Extensions;

/// <summary>
/// Tests for <see cref="OptionExtensions"/>.
/// </summary>
public class OptionExtensionTests
{
    /// <summary>
    /// Checks if a some option is some.
    /// </summary>
    [Fact]
    public void SomeOptionIsSome()
    {
        // Arrange
        var input = 5;
        Option<int> some = Some(input);

        // Act
        var result = some.IsSome(out var resultValue);

        // Assert
        Assert.True(result);
        Assert.Equal(input, resultValue);
        Assert.Equal(Option<int>.UnionKind.Some, some.Kind);
    }

    /// <summary>
    /// Checks if a some option is not none.
    /// </summary>
    [Fact]
    public void SomeOptionIsNotNone()
    {
        // Arrange
        Option<int> option = Some(5);

        // Act
        var result = option.IsNone();

        // Assert
        Assert.False(result);
        Assert.NotEqual(Option<int>.UnionKind.None, option.Kind);
    }

    /// <summary>
    /// Checks if a none option is none.
    /// </summary>
    [Fact]
    public void NoneOptionIsNone()
    {
        // Arrange
        Option<int> none = None();

        // Act
        var result = none.IsNone();

        // Assert
        Assert.True(result);
        Assert.Equal(Option<int>.UnionKind.None, none.Kind);
    }

    /// <summary>
    /// Checks if a none option is not some.
    /// </summary>
    [Fact]
    public void NoneOptionIsNotSome()
    {
        // Arrange
        Option<int> none = None();

        // Act
        var result = none.IsSome(out var resultValue);

        // Assert
        Assert.False(result);
        Assert.Equal(default, resultValue);
        Assert.NotEqual(Option<int>.UnionKind.Some, none.Kind);
    }
}
