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

namespace Furion.Validation;

/// <summary>
/// 验证器选项
/// </summary>
public sealed class ValidatorOptions
{
    /// <inheritdoc cref="ValidatorCascadeMode" />
    public ValidatorCascadeMode CascadeMode { get; set; }

    /// <summary>
    /// 禁用注解（特性）验证
    /// </summary>
    public bool SuppressAnnotationValidation { get; set; } = true;

    /// <inheritdoc cref="ValidateAllPropertiesForObjectAnnotationValidator" />
    private bool _validateAllPropertiesForObjectAnnotationValidator = true;

    /// <summary>
    /// 为对象注解（特性）配置是否验证所有属性
    /// </summary>
    public bool ValidateAllPropertiesForObjectAnnotationValidator
    {
        get => _validateAllPropertiesForObjectAnnotationValidator;
        set
        {
            _validateAllPropertiesForObjectAnnotationValidator = value;

            // 触发属性变更事件
            OnPropertyChanged(nameof(ValidateAllPropertiesForObjectAnnotationValidator));
        }
    }

    /// <summary>
    /// 属性变更事件
    /// </summary>
    public event EventHandler? PropertyChanged;

    /// <summary>
    /// 属性变更事件触发方法
    /// </summary>
    /// <param name="propertyName">属性名称</param>
    internal void OnPropertyChanged(string propertyName)
    {
        // 空检查
        ArgumentException.ThrowIfNullOrWhiteSpace(propertyName);

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}