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

namespace System;

/// <summary>
/// 向事件管理器中输出事件消息
/// </summary>
internal static class Debugging
{
    /// <summary>
    /// 输出一行事件消息
    /// </summary>
    /// <param name="level">
    /// <para>消息级别</para>
    /// <list type="number">
    /// <item>
    /// <description>跟踪</description>
    /// </item>
    /// <item>
    /// <description>信息</description>
    /// </item>
    /// <item>
    /// <description>警告</description>
    /// </item>
    /// <item>
    /// <description>错误</description>
    /// </item>
    /// <item>
    /// <description>文件</description>
    /// </item>
    /// </list>
    /// </param>
    /// <param name="message">事件消息</param>
    internal static void WriteLine(int level, string message)
    {
        // 获取消息级别对应的 emoji
        var category = GetLevelEmoji(level);
        Debug.WriteLine(message, category);
    }

    /// <summary>
    /// 输出一行事件消息
    /// </summary>
    /// <param name="level">
    /// <para>消息级别</para>
    /// <list type="number">
    /// <item>
    /// <description>跟踪</description>
    /// </item>
    /// <item>
    /// <description>信息</description>
    /// </item>
    /// <item>
    /// <description>警告</description>
    /// </item>
    /// <item>
    /// <description>错误</description>
    /// </item>
    /// <item>
    /// <description>文件</description>
    /// </item>
    /// </list>
    /// </param>
    /// <param name="message">事件消息</param>
    /// <param name="args">格式化参数</param>
    internal static void WriteLine(int level, string message, params object?[] args)
    {
        WriteLine(level, string.Format(message, args));
    }

    /// <summary>
    /// 输出跟踪级别事件消息
    /// </summary>
    /// <param name="message">事件消息</param>
    internal static void Trace(string message)
    {
        WriteLine(1, message);
    }

    /// <summary>
    /// 输出跟踪级别事件消息
    /// </summary>
    /// <param name="message">事件消息</param>
    /// <param name="args">格式化参数</param>
    internal static void Trace(string message, params object?[] args)
    {
        WriteLine(1, message, args);
    }

    /// <summary>
    /// 输出信息级别事件消息
    /// </summary>
    /// <param name="message">事件消息</param>
    internal static void Info(string message)
    {
        WriteLine(2, message);
    }

    /// <summary>
    /// 输出信息级别事件消息
    /// </summary>
    /// <param name="message">事件消息</param>
    /// <param name="args">格式化参数</param>
    internal static void Info(string message, params object?[] args)
    {
        WriteLine(2, message, args);
    }

    /// <summary>
    /// 输出警告级别事件消息
    /// </summary>
    /// <param name="message">事件消息</param>
    internal static void Warn(string message)
    {
        WriteLine(3, message);
    }

    /// <summary>
    /// 输出警告级别事件消息
    /// </summary>
    /// <param name="message">事件消息</param>
    /// <param name="args">格式化参数</param>
    internal static void Warn(string message, params object?[] args)
    {
        WriteLine(3, message, args);
    }

    /// <summary>
    /// 输出错误级别事件消息
    /// </summary>
    /// <param name="message">事件消息</param>
    internal static void Error(string message)
    {
        WriteLine(4, message);
    }

    /// <summary>
    /// 输出错误级别事件消息
    /// </summary>
    /// <param name="message">事件消息</param>
    /// <param name="args">格式化参数</param>
    internal static void Error(string message, params object?[] args)
    {
        WriteLine(4, message, args);
    }

    /// <summary>
    /// 输出文件级别事件消息
    /// </summary>
    /// <param name="message">事件消息</param>
    internal static void File(string message)
    {
        WriteLine(5, message);
    }

    /// <summary>
    /// 输出文件级别事件消息
    /// </summary>
    /// <param name="message">事件消息</param>
    /// <param name="args">格式化参数</param>
    internal static void File(string message, params object?[] args)
    {
        WriteLine(5, message, args);
    }

    /// <summary>
    /// 获取消息级别对应的 emoji
    /// </summary>
    /// <param name="level">
    /// <para>消息级别</para>
    /// <list type="number">
    /// <item>
    /// <description>跟踪</description>
    /// </item>
    /// <item>
    /// <description>信息</description>
    /// </item>
    /// <item>
    /// <description>警告</description>
    /// </item>
    /// <item>
    /// <description>错误</description>
    /// </item>
    /// <item>
    /// <description>文件</description>
    /// </item>
    /// </list>
    /// </param>
    /// <returns><see cref="string"/></returns>
    internal static string GetLevelEmoji(int level)
    {
        return level switch
        {
            1 => "🛠️",
            2 => "ℹ️",
            3 => "⚠️",
            4 => "❌",
            5 => "📄",
            _ => string.Empty
        };
    }
}