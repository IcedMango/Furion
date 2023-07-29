﻿// 麻省理工学院许可证
//
// 版权所有 © 2020-2023 百小僧，百签科技（广东）有限公司
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

namespace Furion.Validation.Fluent.Tests;

public class ObjectValidatorTests
{
    [Fact]
    public void New_ReturnOK()
    {
        var validator = new ObjectValidator<ObjectModel>();

        Assert.NotNull(validator._propertyValidators);
        Assert.Empty(validator._propertyValidators);
        Assert.NotNull(validator._annotationValidator);
        Assert.True(validator.SuppressAnnotationValidation);
        Assert.Null(validator.ConditionExpression);
        Assert.Null(validator.Items);
    }

    [Fact]
    public void Create_ReturnOK()
    {
        var validator = ObjectValidator<ObjectModel>.Create();
        Assert.NotNull(validator);

        var validator2 = ObjectValidator<ObjectModel>.Create(v =>
        {
            v.SuppressAnnotationValidation = false;
        });
        Assert.NotNull(validator2);
        Assert.False(validator2.SuppressAnnotationValidation);
    }

    [Fact]
    public void Property_Invalid_Parameters()
    {
        var validator = new ObjectValidator<ObjectModel>();

        Assert.Throws<ArgumentNullException>(() =>
        {
            validator.Property<string>(null!);
        });
    }

    [Fact]
    public void Property_ReturnOK()
    {
        var validator = new ObjectValidator<ObjectModel>();
        var propertyValidator = validator.Property(u => u.Name);

        Assert.NotNull(propertyValidator);
        Assert.Single(validator._propertyValidators);

        var propertyValidator2 = validator._propertyValidators.First() as PropertyValidator<ObjectModel, string>;
        Assert.NotNull(propertyValidator2);
        Assert.Equal("Name", propertyValidator2.PropertyName);
    }

    [Theory]
    [InlineData(true, false)]
    [InlineData(false, true)]
    public void WithAnnotationValidation(bool enable, bool result)
    {
        var validator = new ObjectValidator<ObjectModel>();
        validator.WithAnnotationValidation(enable);

        Assert.Equal(result, validator.SuppressAnnotationValidation);
    }

    [Fact]
    public void When_Invalid_Parameters()
    {
        var validator = new ObjectValidator<ObjectModel>();

        Assert.Throws<ArgumentNullException>(() =>
        {
            validator.When(null!);
        });
    }

    [Fact]
    public void When_ReturnOK()
    {
        var validator = new ObjectValidator<ObjectModel>();
        validator.When(u => u.Name != null);

        Assert.NotNull(validator.ConditionExpression);
    }

    [Fact]
    public void WhenContext_Invalid_Parameters()
    {
        var validator = new ObjectValidator<ObjectModel>();

        Assert.Throws<ArgumentNullException>(() =>
        {
            validator.WhenContext(null!);
        });
    }

    [Fact]
    public void WhenContext_ReturnOK()
    {
        var validator = new ObjectValidator<ObjectModel>();
        validator.WhenContext(u => u.ObjectInstance != null);

        Assert.NotNull(validator.ConditionExpression);
    }

    [Fact]
    public void Reset_ReturnOK()
    {
        var validator = new ObjectValidator<ObjectModel>();
        validator.Reset();

        Assert.Null(validator.ConditionExpression);
        Assert.Null(validator.Items);
    }

    [Fact]
    public void CanValidate_Invalid_Parameters()
    {
        var validator = new ObjectValidator<ObjectModel>();

        Assert.Throws<ArgumentNullException>(() =>
        {
            validator.CanValidate(null!);
        });
    }

    [Fact]
    public void CanValidate_ReturnOK()
    {
        var validator = new ObjectValidator<ObjectModel>();
        var instance = new ObjectModel
        {
            Name = "Furion"
        };

        Assert.True(validator.CanValidate(instance));

        validator.When(u => u.Name == "Furion");
        Assert.True(validator.CanValidate(instance));

        validator.When(u => u.Name != "Furion");
        Assert.False(validator.CanValidate(instance));
    }

    [Fact]
    public void IsValid_Invalid_Parameters()
    {
        var validator = new ObjectValidator<ObjectModel>();

        Assert.Throws<ArgumentNullException>(() =>
        {
            validator.IsValid(null!);
        });
    }

    [Fact]
    public void IsValid_EmptyValidators_ReturnOK()
    {
        var validator = new ObjectValidator<ObjectModel>();
        var instance = new ObjectModel
        {
            Id = 1,
            Name = "Furion"
        };

        Assert.True(validator.IsValid(instance));
    }

    [Fact]
    public void IsValid_WithCondition_ReturnOK()
    {
        var validator = ObjectValidator<ObjectModel>.Create(v =>
        {
            v.When(u => u.Id > 1);
        });

        validator.Property(u => u.Id).GreaterThan(1);
        var instance = new ObjectModel
        {
            Id = 1,
            Name = "Furion"
        };

        Assert.True(validator.IsValid(instance));

        validator.Reset();

        Assert.False(validator.IsValid(instance));
    }

    [Fact]
    public void IsValid_WithAnnotationValidation()
    {
        var validator = ObjectValidator<ObjectModel>.Create();
        validator.Property(u => u.Name).Equal("furion");

        var instance = new ObjectModel
        {
            Id = 0,
            Name = "furion"
        };

        Assert.True(validator.IsValid(instance));

        validator.WithAnnotationValidation();

        Assert.False(validator.IsValid(instance));
    }

    [Fact]
    public void GetValidationResults_Invalid_Parameters()
    {
        var validator = new ObjectValidator<ObjectModel>();

        Assert.Throws<ArgumentNullException>(() =>
        {
            validator.GetValidationResults(null!);
        });
    }

    [Fact]
    public void GetValidationResults_EmptyValidators_ReturnOK()
    {
        var validator = new ObjectValidator<ObjectModel>();
        var instance = new ObjectModel
        {
            Id = 1,
            Name = "Furion"
        };

        Assert.Null(validator.GetValidationResults(instance));
    }

    [Fact]
    public void GetValidationResults_WithCondition_ReturnOK()
    {
        var validator = ObjectValidator<ObjectModel>.Create(v =>
        {
            v.When(u => u.Id > 1);
        });

        validator.Property(u => u.Id).GreaterThan(1);
        var instance = new ObjectModel
        {
            Id = 1,
            Name = "Furion"
        };

        Assert.Null(validator.GetValidationResults(instance));

        validator.Reset();

        var validationResults = validator.GetValidationResults(instance);
        Assert.NotNull(validationResults);
        Assert.Single(validationResults);
        Assert.Equal("The field Id must be greater than '1'.", validationResults.First().ErrorMessage);
    }

    [Fact]
    public void GetValidationResults_WithAnnotationValidation()
    {
        var validator = ObjectValidator<ObjectModel>.Create();
        validator.Property(u => u.Name).Equal("furion");

        var instance = new ObjectModel
        {
            Id = 0,
            Name = "furion"
        };

        Assert.Null(validator.GetValidationResults(instance));

        validator.WithAnnotationValidation();

        instance.Name = "百小僧";
        var validationResults = validator.GetValidationResults(instance);
        Assert.NotNull(validationResults);
        Assert.Equal(3, validationResults.Count);

        var errorMessages = new[] { "The field Id must be between 1 and 10."
            , "The field Name must be a string or array type with a minimum length of '10'."
            ,"The field Name must be equal to 'furion'."};
        Assert.Equal(errorMessages, validationResults.Select(u => u.ErrorMessage).ToArray());
    }

    [Fact]
    public void Validate_Invalid_Parameters()
    {
        var validator = new ObjectValidator<ObjectModel>();

        Assert.Throws<ArgumentNullException>(() =>
        {
            validator.Validate(null!);
        });
    }

    [Fact]
    public void Validate_EmptyValidators_ReturnOK()
    {
        var validator = new ObjectValidator<ObjectModel>();
        var instance = new ObjectModel
        {
            Id = 1,
            Name = "Furion"
        };

        validator.Validate(instance);
    }

    [Fact]
    public void Validate_WithCondition_ReturnOK()
    {
        var validator = ObjectValidator<ObjectModel>.Create(v =>
        {
            v.When(u => u.Id > 1);
        });

        validator.Property(u => u.Id).GreaterThan(1);
        var instance = new ObjectModel
        {
            Id = 1,
            Name = "Furion"
        };

        validator.Validate(instance);

        validator.Reset();

        var exception = Assert.Throws<AggregateValidationException>(() =>
        {
            validator.Validate(instance);
        });

        Assert.NotNull(exception);
        Assert.Single(exception.InnerExceptions);
        Assert.Equal("The field Id must be greater than '1'.", exception.InnerExceptions.First().Message);
    }

    [Fact]
    public void Validate_WithAnnotationValidation()
    {
        var validator = ObjectValidator<ObjectModel>.Create();
        validator.Property(u => u.Name).Equal("furion");

        var instance = new ObjectModel
        {
            Id = 0,
            Name = "furion"
        };

        validator.Validate(instance);

        validator.WithAnnotationValidation();

        instance.Name = "百小僧";
        var exception = Assert.Throws<AggregateValidationException>(() =>
        {
            validator.Validate(instance);
        });
        Assert.NotNull(exception);
        Assert.Equal(3, exception.InnerExceptions.Count);

        var errorMessages = new[] { "The field Id must be between 1 and 10."
            , "The field Name must be a string or array type with a minimum length of '10'."
            ,"The field Name must be equal to 'furion'."};
        Assert.Equal(errorMessages, exception.InnerExceptions.Select(u => u.Message).ToArray());
    }
}