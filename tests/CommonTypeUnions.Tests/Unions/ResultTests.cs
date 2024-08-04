// Licensed to the .NET Extension Contributors under one or more agreements.
// The .NET Extension Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CommonTypeUnions.Unions;
using Xunit;

namespace CommonTypeUnions.Tests.Unions;

/// <summary>
/// Tests for <see cref="Result{TValue, TError}"/>.
/// </summary>
public class ResultTests
{
    /// <summary>
    /// Checks if a default result is empty.
    /// </summary>
    [Fact]
    public void DefaultResultIsEmpty()
    {
        // Arrange
        Result<int, string> result = default;

        // Act
        var successResult = result.TryGetSuccess(out var successResultValue);
        var failureResult = result.TryGetFailure(out var failureResultValue);

        // Assert
        Assert.False(successResult);
        Assert.False(failureResult);
        Assert.Equal(default, successResultValue);
        Assert.Equal(default, failureResultValue);
        Assert.Equal(0, (int)result.Kind);
    }

    /// <summary>
    /// Checks if a default result throws if casted.
    /// </summary>
    [Fact]
    public void DefaultResultThrowsOnCast()
    {
        // Arrange
        Result<int, string> result = default;

        // Assert
        Assert.Throws<InvalidCastException>(() => (Success<int>)result);
        Assert.Throws<InvalidCastException>(() => (Failure<string>)result);
    }

    /// <summary>
    /// Checks if a successful result is success.
    /// </summary>
    [Fact]
    public void SuccessfulResultIsSuccess()
    {
        // Arrange
        var input = 5;
        Result<int, string> success = new Success<int>(input);

        // Act
        var result = success.TryGetSuccess(out var resultValue);

        // Assert
        Assert.True(result);
        Assert.Equal(success, resultValue);
        Assert.Equal(input, resultValue.Value);
        Assert.Equal(Result<int, string>.UnionKind.Success, success.Kind);
    }

    /// <summary>
    /// Checks if a successful result is not failure.
    /// </summary>
    [Fact]
    public void SuccessfulResultIsNotFailure()
    {
        // Arrange
        Result<int, string> success = new Success<int>(5);

        // Act
        var result = success.TryGetFailure(out var resultValue);

        // Assert
        Assert.False(result);
        Assert.NotEqual(success, resultValue);
        Assert.NotEqual(Result<int, string>.UnionKind.Failure, success.Kind);
    }

    /// <summary>
    /// Checks if a successful result can be casted to a success value.
    /// </summary>
    [Fact]
    public void SuccessfulResultCanBeCastToSuccess()
    {
        // Arrange
        Result<int, string> success = new Success<int>(5);

        // Act
        var successValue = (Success<int>)success;

        // Assert
        Assert.Equal(success, successValue);
    }

    /// <summary>
    /// Checks if a successful result throws if casted to a failure.
    /// </summary>
    [Fact]
    public void SuccessfulResultThrowsOnFailureCast()
    {
        // Arrange
        Result<int, string> success = new Success<int>(5);

        // Assert
        Assert.Throws<InvalidCastException>(() => (Failure<string>)success);
    }

    /// <summary>
    /// Checks if a failure result is failure.
    /// </summary>
    [Fact]
    public void FailureResultIsFailure()
    {
        // Arrange
        var input = "Failed";
        Result<int, string> failure = new Failure<string>(input);

        // Act
        var result = failure.TryGetFailure(out var resultValue);

        // Assert
        Assert.True(result);
        Assert.Equal(failure, resultValue);
        Assert.Equal(input, resultValue.Error);
        Assert.Equal(Result<int, string>.UnionKind.Failure, failure.Kind);
    }

    /// <summary>
    /// Checks if a failure result is not success.
    /// </summary>
    [Fact]
    public void FailureResultIsNotSuccess()
    {
        // Arrange
        Result<int, string> failure = new Failure<string>("Failed");

        // Act
        var result = failure.TryGetSuccess(out var resultValue);

        // Assert
        Assert.False(result);
        Assert.NotEqual(failure, resultValue);
        Assert.NotEqual(Result<int, string>.UnionKind.Success, failure.Kind);
    }

    /// <summary>
    /// Checks if a failure result can be casted to a failure value.
    /// </summary>
    [Fact]
    public void FailureResultCanBeCastToFailure()
    {
        // Arrange
        Result<int, string> failure = new Failure<string>("Failed");

        // Act
        var failureValue = (Failure<string>)failure;

        // Assert
        Assert.Equal(failure, failureValue);
    }

    /// <summary>
    /// Checks if a failure result throws if casted to a success.
    /// </summary>
    [Fact]
    public void FailureResultThrowsOnSuccessCast()
    {
        // Arrange
        Result<int, string> failure = new Failure<string>("Failed");

        // Assert
        Assert.Throws<InvalidCastException>(() => (Success<int>)failure);
    }
}
