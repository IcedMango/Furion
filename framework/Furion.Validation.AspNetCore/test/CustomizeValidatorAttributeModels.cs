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

using Microsoft.AspNetCore.Mvc;

namespace Furion.Validation.AspNetCore.Tests;

public class FluentModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

[CustomizeValidator]
public class FluentModel2
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [CustomizeValidator<FluentModelValidator2>]
    public FluentModel2? Model { get; set; }
}

public class FluentModelValidator : AbstractValidator<FluentModel>
{
    public FluentModelValidator()
    {
        RuleFor(x => x.Id).GreaterThan(1);
        RuleFor(u => u.Name).NotNull().NotEqual("furion");

        RuleSet("furion", () =>
        {
            RuleFor(u => u.Name).NotNull().NotEqual("furion");
        });
    }
}

public class FluentModelValidator2 : AbstractValidator<FluentModel2>
{
    public FluentModelValidator2()
    {
        RuleFor(x => x.Id).GreaterThan(1);
        RuleFor(u => u.Name).NotNull().NotEqual("furion");
    }
}

public abstract class FluentModelValidator3 : AbstractValidator<FluentModel>
{
}

public class FluentModelValidator4 : IObjectValidator<FluentModel>
{
    public ValidatorOptions Options => throw new NotImplementedException();

    public List<ValidationResult>? GetValidationResults(object instance, string? ruleSet = null) => throw new NotImplementedException();

    public bool IsInRuleSet(string? ruleSet = null) => throw new NotImplementedException();

    public bool IsValid(object instance, string? ruleSet = null) => throw new NotImplementedException();

    public IObjectValidator<FluentModel> Reset() => throw new NotImplementedException();

    public void Validate(object instance, string? ruleSet = null) => throw new NotImplementedException();

    public IObjectValidator<FluentModel> When(Func<FluentModel, bool> condition) => throw new NotImplementedException();

    public IObjectValidator<FluentModel> WhenContext(Func<ValidationContext, bool> condition) => throw new NotImplementedException();
}

[ApiController]
[Route("[controller]/[action]")]
public class CustomizeController : ControllerBase
{
    [HttpPost]
    public FluentModel TestParameter([CustomizeValidator] FluentModel model)
    {
        return model;
    }

    [HttpPost]
    public FluentModel2 TestClass(FluentModel2 model)
    {
        return model;
    }
}