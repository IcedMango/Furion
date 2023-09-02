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

namespace Furion.DependencyInjection;

/// <summary>
/// 自动装配服务控制器激活器
/// </summary>
public class ServiceBasedAutowiredControllerActivator : IControllerActivator
{
    /// <inheritdoc cref="IAutowiredMemberActivator" />
    internal readonly IAutowiredMemberActivator _autowiredMemberActivator;

    /// <summary>
    /// <inheritdoc cref="ServiceBasedAutowiredControllerActivator"/>
    /// </summary>
    /// <param name="autowiredMemberActivator"><see cref="IAutowiredMemberActivator"/></param>
    public ServiceBasedAutowiredControllerActivator(IAutowiredMemberActivator autowiredMemberActivator)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(autowiredMemberActivator);

        _autowiredMemberActivator = autowiredMemberActivator;
    }

    /// <inheritdoc />
    public object Create(ControllerContext context)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(context.ActionDescriptor);
        ArgumentNullException.ThrowIfNull(context.ActionDescriptor.ControllerTypeInfo);

        // 获取控制器类型
        var controllerType = context.ActionDescriptor.ControllerTypeInfo.AsType();

        // 获取请求上下文服务提供器
        var requestServices = context.HttpContext.RequestServices;

        // 解析控制器实例
        var controller = requestServices.GetRequiredService(controllerType);

        // 自动装配控制器成员值
        _autowiredMemberActivator.AutowiredMembers(controller, requestServices);

        return controller;
    }

    /// <inheritdoc />
    public virtual void Release(ControllerContext context, object controller)
    {
    }
}