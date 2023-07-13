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

public class ValidatorAttributeTests
{
    [Theory]
    [InlineData(typeof(AgeAttribute))]
    [InlineData(typeof(ChineseAttribute))]
    [InlineData(typeof(ChineseNameAttribute))]
    [InlineData(typeof(ColorValueAttribute))]
    [InlineData(typeof(DomainAttribute))]
    [InlineData(typeof(EndsWithAttribute))]
    [InlineData(typeof(IDCardNumberAttribute))]
    [InlineData(typeof(NotEmptyAttribute))]
    [InlineData(typeof(PasswordAttribute))]
    [InlineData(typeof(PhoneNumberAttribute))]
    [InlineData(typeof(PostalCodeAttribute))]
    [InlineData(typeof(SingleAttribute))]
    [InlineData(typeof(StartsWithAttribute))]
    [InlineData(typeof(StringContainsAttribute))]
    [InlineData(typeof(StrongPasswordAttribute))]
    [InlineData(typeof(TelephoneAttribute))]
    [InlineData(typeof(UserNameAttribute))]
    [InlineData(typeof(NotEqualAttribute))]
    [InlineData(typeof(EqualAttribute))]
    [InlineData(typeof(GreaterThanAttribute))]
    [InlineData(typeof(GreaterThanOrEqualToAttribute))]
    [InlineData(typeof(LessThanAttribute))]
    [InlineData(typeof(LessThanOrEqualToAttribute))]
    public void Attribute_Defined(Type attributeType)
    {
        Assert.True(typeof(ValidationAttribute).IsAssignableFrom(attributeType));
        var attributeUsageAttribute = attributeType.GetCustomAttribute<AttributeUsageAttribute>();
        Assert.NotNull(attributeUsageAttribute);

        Assert.Equal(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, attributeUsageAttribute.ValidOn);
        Assert.False(attributeUsageAttribute.AllowMultiple);
    }

    [Fact]
    public void IsValid()
    {
        var model = new ValidatorModel
        {
            Age = 130,
            Chinese = "很6啊",
            ChineseName = "蒙奇·D·路飞",
            ColorValue = "#ffff",
            Domain = "https://furion.net",
            EndsWith = "furions",
            IDCardNumber = "1234569910101933",
            NotEmpty = Array.Empty<string>(),
            Password = "123456",
            PhoneNumber = "12345678900",
            PostalCode = "1001001",
            Single = new List<string> { "furion", "fur" },
            StartsWith = "monksoul",
            StringContains = "dotnetchina",
            StrongPassword = "q1w2e3r4",
            Telephone = "076088809963",
            UserName = "😐monk",
            NotEqual = "furion",
            Equal = "fur",
            GreaterThan = 9,
            GreaterThanOrEqualTo = 9.0d,
            LessThan = 11,
            LessThanOrEqualTo = 11.0d
        };

        var validator = new ObjectAnnotationValidator();
        Assert.False(validator.IsValid(model));

        var validationResults = validator.GetValidationResults(model, null!);
        Assert.NotNull(validationResults);

        Assert.Equal(23, validationResults.Count);
    }
}