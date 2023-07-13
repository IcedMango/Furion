﻿// 麻省理工学院许可证
//
// 版权所有 (c) 2020-2023 百小僧，百签科技（广东）有限公司
//
// 特此免费授予获得本软件及其相关文档文件（以下简称“软件”）副本的任何人以处理本软件的权利，
// 包括但不限于使用、复制、修改、合并、发布、分发、再许可、销售软件的副本，
// 以及允许拥有软件副本的个人进行上述行为，但须遵守以下条件：
//
// 在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，
// 无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

namespace Furion.Validation.Tests;

public class ValidatorBaseTests
{
    [Fact]
    public void NewInstance_Default()
    {
        ValidatorBase validator = new TestValidator();

        Assert.NotNull(validator);
        Assert.NotNull(validator._errorMessageResourceAccessor);
        Assert.Equal("The field {0} is invalid.", validator._errorMessageResourceAccessor());
        Assert.Null(validator.ErrorMessage);
        Assert.Equal("The field {0} is invalid.", ((TestValidator)validator).GetErrorMessageString());
    }

    [Fact]
    public void NewInstance_With_ErrorMessageAccessor()
    {
        ValidatorBase validator = new TestValidator(() => "这是错误消息");

        Assert.NotNull(validator);
        Assert.NotNull(validator._errorMessageResourceAccessor);
        Assert.Equal("这是错误消息", validator._errorMessageResourceAccessor());
        Assert.Null(validator.ErrorMessage);
        Assert.Equal("这是错误消息", ((TestValidator)validator).GetErrorMessageString());
    }

    [Fact]
    public void NewInstanceOfT_Default()
    {
        ValidatorBase validator = new TestValidator<string>();

        Assert.NotNull(validator);
        Assert.NotNull(validator._errorMessageResourceAccessor);
        Assert.Equal("The field {0} is invalid.", validator._errorMessageResourceAccessor());
        Assert.Null(validator.ErrorMessage);
        Assert.Equal("The field {0} is invalid.", ((TestValidator<string>)validator).GetErrorMessageString());
    }

    [Fact]
    public void NewInstanceOfT_With_ErrorMessageAccessor()
    {
        ValidatorBase validator = new TestValidator<string>(() => "这是错误消息");

        Assert.NotNull(validator);
        Assert.NotNull(validator._errorMessageResourceAccessor);
        Assert.Equal("这是错误消息", validator._errorMessageResourceAccessor());
        Assert.Null(validator.ErrorMessage);
        Assert.Equal("这是错误消息", ((TestValidator<string>)validator).GetErrorMessageString());
    }

    [Fact]
    public void NewInstance_Throw()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var validator = new TestValidator<string>(null!);
        });
    }

    [Fact]
    public void GetValidationResults()
    {
        var validator = new TestValidator();

        var nullResults = validator.GetValidationResults(null, null!);
        Assert.Null(nullResults);

        var successResults = validator.GetValidationResults("test", null!);
        Assert.Null(successResults);

        var name = "test";
        var failureResults = validator.GetValidationResults("some", name);
        Assert.NotNull(failureResults);
        Assert.Single(failureResults);
        Assert.Equal("The field test is invalid.", failureResults.First().ErrorMessage);
    }

    [Fact]
    public void GetValidationResults_ErrorMessage()
    {
        var validator = new TestValidator
        {
            ErrorMessage = "这里的{0}有一个错误"
        };

        var failureResults = validator.GetValidationResults("some", null!);
        Assert.NotNull(failureResults);
        Assert.Single(failureResults);
        Assert.Equal("这里的有一个错误", failureResults.First().ErrorMessage);

        var name = "Name";
        var failureResults2 = validator.GetValidationResults("some", name);
        Assert.NotNull(failureResults2);
        Assert.Single(failureResults2);
        Assert.Equal("这里的Name有一个错误", failureResults2.First().ErrorMessage);
    }

    [Fact]
    public void GetValidationResult()
    {
        var validator = new TestValidator();

        var nullResult = validator.GetValidationResult(null, null!);
        Assert.Null(nullResult);

        var successResult = validator.GetValidationResult("test", null!);
        Assert.Null(successResult);

        var name = "test";
        var failureResult = validator.GetValidationResult("some", name);
        Assert.NotNull(failureResult);
        Assert.Equal("The field test is invalid.", failureResult.ErrorMessage);
    }

    [Fact]
    public void GetValidationResult_ErrorMessage()
    {
        var validator = new TestValidator
        {
            ErrorMessage = "这里的{0}有一个错误"
        };

        var failureResult = validator.GetValidationResult("some", null!);
        Assert.NotNull(failureResult);
        Assert.Equal("这里的有一个错误", failureResult.ErrorMessage);

        var name = "Name";
        var failureResult2 = validator.GetValidationResult("some", name);
        Assert.NotNull(failureResult2);
        Assert.Equal("这里的Name有一个错误", failureResult2.ErrorMessage);
    }

    [Fact]
    public void WithErrorMessage()
    {
        var validator = new TestValidator();
        Assert.Null(validator.ErrorMessage);

        validator.WithErrorMessage("错误消息");
        Assert.NotNull(validator.ErrorMessage);
        Assert.Equal("错误消息", validator.ErrorMessage);
    }

    [Fact]
    public void Validate_Pass_ReturnOK()
    {
        var validator = new TestValidator();

        validator.Validate(null, null!);
        validator.Validate("test", null!);
    }

    [Fact]
    public void Validate_NotPass_Throw()
    {
        var validator = new TestValidator
        {
            ErrorMessage = "这里的{0}有一个错误"
        };
        Assert.Throws<AggregateValidationException>(() =>
        {
            validator.Validate("some", "Name");
        });
    }

    [Theory]
    [InlineData(null, true)]
    [InlineData("test", true)]
    [InlineData("some", false)]
    public void IsValid(object? value, bool result)
    {
        var validator = new TestValidator();
        Assert.Equal(result, validator.IsValid(value));
    }

    [Fact]
    public void FormatErrorMessage()
    {
        var validator = new TestValidator()
        {
            ErrorMessage = "测试数据 {0} 验证失败"
        };

        Assert.Equal("测试数据 Value 验证失败", validator.FormatErrorMessage("Value"));
    }

    [Theory]
    [InlineData(typeof(AgeValidator), false)]
    [InlineData(typeof(TestValidator), true)]
    public void IsSameAs(Type type, bool result)
    {
        var validator = new TestValidator();
        Assert.Equal(result, validator.IsSameAs(type));
    }
}