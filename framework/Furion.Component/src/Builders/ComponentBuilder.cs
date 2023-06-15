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

namespace Furion.Component;

/// <summary>
/// 组件模块构建器
/// </summary>
public sealed class ComponentBuilder : ComponentBuilderBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public ComponentBuilder()
        : base()
    {
    }

    /// <summary>
    /// 禁用组件重复调用
    /// </summary>
    public bool SuppressDuplicateCall { get; set; } = true;

    /// <summary>
    /// 构建模块
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    internal override void Build(IServiceCollection services)
    {
        // 将自身注册为组件参数
        Configure<ComponentBuilder>(builder =>
        {
            builder.SuppressDuplicateCall = SuppressDuplicateCall;
        });

        // 获取组件模块配置选项
        var componentOptions = services.GetComponentOptions();

        // 配置组件选项
        componentOptions.SuppressDuplicateCall = SuppressDuplicateCall;
        componentOptions.OptionsActions.AddOrUpdate(_optionsActions);
        _optionsActions.Clear();
    }
}