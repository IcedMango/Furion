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
/// 组件模块配置选项
/// </summary>
internal sealed class ComponentOptions
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public ComponentOptions()
    {
        OptionsActions ??= new();
        CallRegistration ??= new();
    }

    /// <summary>
    /// 组件参数委托字典
    /// </summary>
    internal Dictionary<Type, List<Delegate>> OptionsActions { get; init; }

    /// <summary>
    /// 组件调用登记
    /// </summary>
    internal ConcurrentBag<string> CallRegistration { get; init; }

    /// <summary>
    /// 禁用组件重复调用
    /// </summary>
    internal bool SuppressDuplicateCall { get; set; } = true;

    /// <summary>
    /// 禁用组件重复调用（Web 组件）
    /// </summary>
    internal bool SuppressDuplicateCallForWeb { get; set; } = true;

    /// <summary>
    /// 获取组件参数委托
    /// </summary>
    /// <typeparam name="TOptions">组件参数类型</typeparam>
    /// <returns><see cref="Action{T}"/></returns>
    internal Action<TOptions>? GetOptionsAction<TOptions>()
        where TOptions : class, new()
    {
        // 组件参数类型
        var optionsType = typeof(TOptions);

        // 如果未找到组件类型参数则返回空
        if (!OptionsActions.TryGetValue(optionsType, out var values))
        {
            return null;
        }

        // 生成级联委托
        var cascadeAction = values.Cast<Action<TOptions>>()
                                                .Aggregate((previous, current) => (t) =>
                                                {
                                                    previous(t);
                                                    current(t);
                                                });
        return cascadeAction;
    }

    /// <summary>
    /// 获取组件参数委托
    /// </summary>
    /// <typeparam name="TOptions">组件参数类型</typeparam>
    /// <returns><see cref="Action{T}"/></returns>
    internal Action<TOptions> GetOptionsActionOrNew<TOptions>()
        where TOptions : class, new()
    {
        var cascadeAction = GetOptionsAction<TOptions>();

        if (cascadeAction is null)
        {
            Action<TOptions> action = options => { };
            OptionsActions.AddOrUpdate(typeof(TOptions), action);
            return action;
        }

        return cascadeAction;
    }

    /// <summary>
    /// 获取组件参数委托
    /// </summary>
    /// <param name="optionsType">组件参数类型</param>
    /// <returns><see cref="Action{T}"/></returns>
    internal Delegate GetOptionsActionOrNew(Type optionsType)
    {
        var @delegate = GetOptionsActionOrNewMethodInfo.MakeGenericMethod(optionsType)
                                                             .Invoke(this, null);
        return (Delegate)@delegate!;
    }

    internal static MethodInfo GetOptionsActionOrNewMethodInfo = typeof(ComponentOptions).GetMethod(nameof(GetOptionsActionOrNew), 1, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly, null, Type.EmptyTypes, null)!;
}