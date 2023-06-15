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

namespace Furion.Core.Tests;

public class InstanceType
{ }

public static class StaticType
{ }

public sealed class SealedType
{ }

public abstract class AbstractType
{ }

public enum EnumType
{ }

public record RecordType { }

public struct StructType
{ }

public interface IDependency
{ }

public class Dependency : IDependency
{ }

[AttributeUsage(AttributeTargets.Class)]
public class CustomAttribute : Attribute
{ }

[Custom]
public class WithAttribute
{
}

public class InheritWithAttribute : WithAttribute
{
}

public class StaticConstruct
{
    static StaticConstruct()
    {
    }
}

public class InternalConstruct
{
    internal InternalConstruct()
    {
    }
}

public class PrivateConstruct
{
    private PrivateConstruct()
    {
    }
}

public class WithParameterConstruct
{
    public WithParameterConstruct(string _)
    {
    }
}

public class WithParameterAndParameterlessConstruct
{
    public WithParameterAndParameterlessConstruct()
    {
    }

    public WithParameterAndParameterlessConstruct(string _)
    {
    }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class ScanningAttribute : Attribute
{ }

public interface IGenericType<T>
{ }

public interface IGenericType<T, U>
{ }

public interface IGenericType2<T>
{ }

public interface IGenericType2<T, U>
{ }

[Scanning]
public class GenericType<T> : IGenericType<T>, IGenericType2<string>, IGenericType<T, string>
{ }

[Scanning]
public class GenericType<T, U> : IGenericType<T, U>, IGenericType2<T, string>, IGenericType<T>
{ }