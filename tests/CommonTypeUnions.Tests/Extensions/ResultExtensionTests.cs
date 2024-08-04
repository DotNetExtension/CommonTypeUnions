// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using static CommonTypeUnions.Extensions.ResultExtensions;
using CommonTypeUnions.Extensions;
using CommonTypeUnions.Unions;
using Xunit;

namespace CommonTypeUnions.Tests.Extensions;

/// <summary>
/// Tests for <see cref="ResultExtensions"/>.
/// </summary>
public class ResultExtensionTests
{
    /// <summary>
    /// Checks if a successful result is success.
    /// </summary>
    [Fact]
    public void SuccessfulResultIsSuccess()
    {
        // Arrange
        var input = 5;
        Result<int, string> success = Success(input);

        // Act
        var result = success.IsSuccess(out var resultValue);

        // Assert
        Assert.True(result);
        Assert.Equal(input, resultValue);
        Assert.Equal(Result<int, string>.UnionKind.Success, success.Kind);
    }

    /// <summary>
    /// Checks if a successful result is not failure.
    /// </summary>
    [Fact]
    public void SuccessfulResultIsNotFailure()
    {
        // Arrange
        Result<int, string> success = Success(5);

        // Act
        var result = success.IsFailure(out var resultValue);

        // Assert
        Assert.False(result);
        Assert.Null(resultValue);
        Assert.NotEqual(Result<int, string>.UnionKind.Failure, success.Kind);
    }

    /// <summary>
    /// Checks if a failure result is failure.
    /// </summary>
    [Fact]
    public void FailureResultIsFailure()
    {
        // Arrange
        var input = "Failed";
        Result<int, string> failure = Failure(input);

        // Act
        var result = failure.IsFailure(out var resultValue);

        // Assert
        Assert.True(result);
        Assert.Equal(input, resultValue);
        Assert.Equal(Result<int, string>.UnionKind.Failure, failure.Kind);
    }

    /// <summary>
    /// Checks if a failure result is not success.
    /// </summary>
    [Fact]
    public void FailureResultIsNotSuccess()
    {
        // Arrange
        Result<int, string> failure = Failure("Failed");

        // Act
        var result = failure.IsSuccess(out var resultValue);

        // Assert
        Assert.False(result);
        Assert.Equal(default, resultValue);
        Assert.NotEqual(Result<int, string>.UnionKind.Success, failure.Kind);
    }
}
