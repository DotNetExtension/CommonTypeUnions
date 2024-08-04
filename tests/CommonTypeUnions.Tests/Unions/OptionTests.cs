// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CommonTypeUnions.Unions;
using Xunit;

namespace CommonTypeUnions.Tests.Unions;

/// <summary>
/// Tests for <see cref="Option{TValue}"/>.
/// </summary>
public class OptionTests
{
    /// <summary>
    /// Checks if a default option is empty.
    /// </summary>
    [Fact]
    public void DefaultOptionIsEmpty()
    {
        // Arrange
        Option<int> option = default;

        // Act
        var someResult = option.TryGetSome(out var someResultValue);
        var noneResult = option.TryGetNone(out var noneResultValue);

        // Assert
        Assert.False(someResult);
        Assert.False(noneResult);
        Assert.Equal(default, someResultValue);
        Assert.Equal(default, noneResultValue);
        Assert.Equal(0, (int)option.Kind);
    }

    /// <summary>
    /// Checks if a default option throws if casted.
    /// </summary>
    [Fact]
    public void DefaultOptionThrowsOnCast()
    {
        // Arrange
        Option<int> option = default;

        // Assert
        Assert.Throws<InvalidCastException>(() => (Some<int>)option);
        Assert.Throws<InvalidCastException>(() => (None)option);
    }

    /// <summary>
    /// Checks if a some option is some.
    /// </summary>
    [Fact]
    public void SomeOptionIsSome()
    {
        // Arrange
        var input = 5;
        Option<int> some = new Some<int>(input);

        // Act
        var result = some.TryGetSome(out var resultValue);

        // Assert
        Assert.True(result);
        Assert.Equal(some, resultValue);
        Assert.Equal(input, resultValue.Value);
        Assert.Equal(Option<int>.UnionKind.Some, some.Kind);
    }

    /// <summary>
    /// Checks if a some option is not none.
    /// </summary>
    [Fact]
    public void SomeOptionIsNotNone()
    {
        // Arrange
        Option<int> option = new Some<int>(5);

        // Act
        var result = option.TryGetNone(out var resultValue);

        // Assert
        Assert.False(result);
        Assert.NotEqual(option, resultValue);
        Assert.NotEqual(Option<int>.UnionKind.None, option.Kind);
    }

    /// <summary>
    /// Checks if a some option can be casted to a some value.
    /// </summary>
    [Fact]
    public void SomeOptionCanBeCastToSome()
    {
        // Arrange
        Option<int> some = new Some<int>(5);

        // Act
        var someValue = (Some<int>)some;

        // Assert
        Assert.Equal(some, someValue);
    }

    /// <summary>
    /// Checks if a some option throws if casted to none.
    /// </summary>
    [Fact]
    public void SomeOptionThrowsOnNoneCast()
    {
        // Arrange
        Option<int> some = new Some<int>(5);

        // Assert
        Assert.Throws<InvalidCastException>(() => (None)some);
    }

    /// <summary>
    /// Checks if a none option is none.
    /// </summary>
    [Fact]
    public void NoneOptionIsNone()
    {
        // Arrange
        Option<int> none = new None();

        // Act
        var result = none.TryGetNone(out var resultValue);

        // Assert
        Assert.True(result);
        Assert.Equal(none, resultValue);
        Assert.Equal(Option<int>.UnionKind.None, none.Kind);
    }

    /// <summary>
    /// Checks if a none option is not some.
    /// </summary>
    [Fact]
    public void NoneOptionIsNotSome()
    {
        // Arrange
        Option<int> none = new None();

        // Act
        var result = none.TryGetSome(out var resultValue);

        // Assert
        Assert.False(result);
        Assert.NotEqual(none, resultValue);
        Assert.NotEqual(Option<int>.UnionKind.Some, none.Kind);
    }

    /// <summary>
    /// Checks if a none option can be casted to none.
    /// </summary>
    [Fact]
    public void NoneOptionCanBeCastToNone()
    {
        // Arrange
        Option<int> none = new None();

        // Act
        var noneValue = (None)none;

        // Assert
        Assert.Equal(none, noneValue);
    }

    /// <summary>
    /// Checks if a none result throws if casted to some.
    /// </summary>
    [Fact]
    public void NoneOptionThrowsOnSomeCast()
    {
        // Arrange
        Option<int> none = new None();

        // Assert
        Assert.Throws<InvalidCastException>(() => (Some<int>)none);
    }
}
