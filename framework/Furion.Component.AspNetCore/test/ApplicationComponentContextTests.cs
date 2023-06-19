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

namespace Furion.Component.AspNetCore.Tests;

public class ApplicationComponentContextTests
{
    [Fact]
    public void NewInstance_Default()
    {
        var webApplication = WebApplication.CreateBuilder().AddComponentCore().Build();
        var applicationComponentContext = new ApplicationComponentContext(webApplication);

        Assert.NotNull(applicationComponentContext);
        Assert.NotNull(applicationComponentContext.Application);
        Assert.NotNull(applicationComponentContext.Configuration);
        Assert.NotNull(applicationComponentContext.Options);
        Assert.NotNull(applicationComponentContext.Environment);
    }

    [Fact]
    public void GetOptionsAction_NotExists_ReturnNull()
    {
        var webApplication = WebApplication.CreateBuilder().AddComponentCore().Build();
        var applicationComponentContext = new ApplicationComponentContext(webApplication);

        var action = applicationComponentContext.GetOptionsAction<ComponentActionOptions>();
        Assert.Null(action);
    }

    [Fact]
    public void GetOptionsAction_Exists_ReturnAction()
    {
        var webApplication = WebApplication.CreateBuilder().AddComponentCore().Build();
        var applicationComponentContext = new ApplicationComponentContext(webApplication);

        static void Action(ComponentActionOptions options)
        {
        }
        applicationComponentContext.Options.OptionsActions.Add(typeof(ComponentActionOptions), new List<Delegate> { Action });

        var action = applicationComponentContext.GetOptionsAction<ComponentActionOptions>();
        Assert.NotNull(action);
    }

    [Fact]
    public void GetOptions_NotExists_ReturnNull()
    {
        var webApplication = WebApplication.CreateBuilder().AddComponentCore().Build();
        var applicationComponentContext = new ApplicationComponentContext(webApplication);

        var action = applicationComponentContext.GetOptions<ComponentActionOptions>();
        Assert.Null(action);
    }

    [Fact]
    public void GetOptions_Exists_ReturnAction()
    {
        var webApplication = WebApplication.CreateBuilder().AddComponentCore().Build();
        var applicationComponentContext = new ApplicationComponentContext(webApplication);

        static void Action(ComponentActionOptions options)
        {
        }
        applicationComponentContext.Options.OptionsActions.Add(typeof(ComponentActionOptions), new List<Delegate> { Action });

        var action = applicationComponentContext.GetOptions<ComponentActionOptions>();
        Assert.NotNull(action);
    }

    [Fact]
    public void GetOptionsOrNew_NotExists_ReturnNull()
    {
        var webApplication = WebApplication.CreateBuilder().AddComponentCore().Build();
        var applicationComponentContext = new ApplicationComponentContext(webApplication);

        var action = applicationComponentContext.GetOptionsOrNew<ComponentActionOptions>();
        Assert.NotNull(action);
    }

    [Fact]
    public void GetOptionsOrNew_Exists_ReturnAction()
    {
        var webApplication = WebApplication.CreateBuilder().AddComponentCore().Build();
        var applicationComponentContext = new ApplicationComponentContext(webApplication);

        static void Action(ComponentActionOptions options)
        {
        }
        applicationComponentContext.Options.OptionsActions.Add(typeof(ComponentActionOptions), new List<Delegate> { Action });

        var action = applicationComponentContext.GetOptionsOrNew<ComponentActionOptions>();
        Assert.NotNull(action);
    }
}