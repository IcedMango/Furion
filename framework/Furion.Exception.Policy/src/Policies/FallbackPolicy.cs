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

namespace Furion.Exception;

/// <summary>
/// 后备策略
/// </summary>
public sealed class FallbackPolicy : FallbackPolicy<object>
{
}

/// <summary>
/// 后备策略
/// </summary>
/// <typeparam name="TResult">操作返回值类型</typeparam>
public class FallbackPolicy<TResult> : AbstractPolicy<TResult>
{
    /// <summary>
    /// 后备操作方法
    /// </summary>
    public Func<FallbackPolicyContext<TResult>, TResult?>? FallbackAction { get; set; }

    /// <summary>
    /// 操作结果条件集合
    /// </summary>
    public IList<Func<FallbackPolicyContext<TResult>, bool>>? ResultConditions { get; set; }

    /// <summary>
    /// 捕获的异常集合
    /// </summary>
    public IList<Type>? HandleExceptions { get; set; }

    /// <summary>
    /// 捕获的内部异常集合
    /// </summary>
    public IList<Type>? HandleInnerExceptions { get; set; }

    /// <summary>
    /// 添加捕获异常类型
    /// </summary>
    /// <typeparam name="TException"><see cref="System.Exception"/></typeparam>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> Handle<TException>()
        where TException : System.Exception
    {
        HandleExceptions ??= new List<Type>();
        HandleExceptions.Add(typeof(TException));

        return this;
    }

    /// <summary>
    /// 添加捕获异常类型
    /// </summary>
    /// <typeparam name="TException"><see cref="System.Exception"/></typeparam>
    /// <param name="exceptionCondition">异常条件</param>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> Handle<TException>(Func<TException, bool> exceptionCondition)
        where TException : System.Exception
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(exceptionCondition);

        // 添加捕获异常类型和条件
        Handle<TException>();
        HandleResult(context => context.Exception is TException exception && exceptionCondition(exception));

        return this;
    }

    /// <summary>
    /// 添加捕获异常类型
    /// </summary>
    /// <typeparam name="TException"><see cref="System.Exception"/></typeparam>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> Or<TException>()
        where TException : System.Exception
    {
        return Handle<TException>();
    }

    /// <summary>
    /// 添加捕获异常类型
    /// </summary>
    /// <typeparam name="TException"><see cref="System.Exception"/></typeparam>
    /// <param name="exceptionCondition">异常条件</param>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> Or<TException>(Func<TException, bool> exceptionCondition)
        where TException : System.Exception
    {
        return Handle(exceptionCondition);
    }

    /// <summary>
    /// 添加捕获内部异常类型
    /// </summary>
    /// <typeparam name="TException"><see cref="System.Exception"/></typeparam>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> HandleInner<TException>()
        where TException : System.Exception
    {
        HandleInnerExceptions ??= new List<Type>();
        HandleInnerExceptions.Add(typeof(TException));

        return this;
    }

    /// <summary>
    /// 添加捕获内部异常类型
    /// </summary>
    /// <typeparam name="TException"><see cref="System.Exception"/></typeparam>
    /// <param name="exceptionCondition">异常条件</param>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> HandleInner<TException>(Func<TException, bool> exceptionCondition)
        where TException : System.Exception
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(exceptionCondition);

        // 添加捕获异常类型和条件
        HandleInner<TException>();
        HandleResult(context => context.Exception?.InnerException is TException exception && exceptionCondition(exception));

        return this;
    }

    /// <summary>
    /// 添加捕获内部异常类型
    /// </summary>
    /// <typeparam name="TException"><see cref="System.Exception"/></typeparam>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> OrInner<TException>()
        where TException : System.Exception
    {
        return HandleInner<TException>();
    }

    /// <summary>
    /// 添加捕获内部异常类型
    /// </summary>
    /// <typeparam name="TException"><see cref="System.Exception"/></typeparam>
    /// <param name="exceptionCondition">异常条件</param>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> OrInner<TException>(Func<TException, bool> exceptionCondition)
        where TException : System.Exception
    {
        return HandleInner(exceptionCondition);
    }

    /// <summary>
    /// 添加操作结果条件
    /// </summary>
    /// <param name="resultCondition">操作结果条件</param>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> HandleResult(Func<FallbackPolicyContext<TResult>, bool> resultCondition)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(resultCondition);

        ResultConditions ??= new List<Func<FallbackPolicyContext<TResult>, bool>>();
        ResultConditions.Add(resultCondition);

        return this;
    }

    /// <summary>
    /// 添加操作结果条件
    /// </summary>
    /// <param name="resultCondition">操作结果条件</param>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> OrResult(Func<FallbackPolicyContext<TResult>, bool> resultCondition)
    {
        return HandleResult(resultCondition);
    }

    /// <summary>
    /// 检查是否可以执行后备操作
    /// </summary>
    /// <param name="context"><see cref="FallbackPolicy{TResult}"/></param>
    /// <returns><see cref="bool"/></returns>
    internal bool ShouldFallback(FallbackPolicyContext<TResult> context)
    {
        // 检查异常或内部异常是否能够捕获处理
        if (WhenCatchException(context, HandleExceptions, context.Exception)
            || WhenCatchException(context, HandleInnerExceptions, context.Exception?.InnerException))
        {
            return true;
        }

        // 检查是否配置了操作结果条件
        if (ResultConditions is not null && ResultConditions.Count > 0)
        {
            return ResultConditions.Any(condition => condition(context));
        }

        return false;
    }

    /// <summary>
    /// 添加后备操作方法
    /// </summary>
    /// <param name="fallbackAction">后备操作方法</param>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> OnFallback(Func<FallbackPolicyContext<TResult>, TResult?> fallbackAction)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(fallbackAction);

        FallbackAction = fallbackAction;

        return this;
    }

    /// <summary>
    /// 添加后备操作方法
    /// </summary>
    /// <param name="fallbackAction">后备操作方法</param>
    /// <returns><see cref="FallbackPolicy{TResult}"/></returns>
    public FallbackPolicy<TResult> OnFallback(Action<FallbackPolicyContext<TResult>> fallbackAction)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(fallbackAction);

        FallbackAction = context =>
        {
            fallbackAction(context);

            return default;
        };

        return this;
    }

    /// <inheritdoc />
    public override async Task<TResult?> ExecuteAsync(Func<Task<TResult?>> operation, CancellationToken cancellationToken = default)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(operation);

        // 初始化后备策略上下文
        var context = new FallbackPolicyContext<TResult>
        {
            PolicyName = PolicyName
        };

        try
        {
            // 获取操作方法执行结果
            context.Result = await operation();
        }
        catch (System.Exception exception)
        {
            // 获取操作方法执行异常
            context.Exception = exception;
            context.TimeForFailure = DateTimeOffset.UtcNow;
        }

        // 检查是否可以执行后备操作
        if (ShouldFallback(context))
        {
            // 调用后备操作方法
            if (FallbackAction is not null)
            {
                return FallbackAction(context);
            }
        }

        return ReturnResultOrThrow(context);
    }

    /// <summary>
    /// 返回结果或抛出异常
    /// </summary>
    /// <param name="context"><see cref="FallbackPolicyContext{TResult}"/></param>
    /// <returns><typeparamref name="TResult"/></returns>
    internal static TResult? ReturnResultOrThrow(FallbackPolicyContext<TResult> context)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(context);

        // 检查是否存在异常
        if (context.Exception is not null)
        {
            // 抛出操作异常
            throw context.Exception;
        }

        return context.Result;
    }

    /// <summary>
    /// 检查异常信息是否匹配
    /// </summary>
    /// <param name="context"><see cref="FallbackPolicyContext{TResult}"/></param>
    /// <param name="exceptionTypes">异常类型集合</param>
    /// <param name="exception"><see cref="System.Exception"/></param>
    /// <returns><see cref="bool"/></returns>
    internal bool WhenCatchException(FallbackPolicyContext<TResult> context, IList<Type>? exceptionTypes, System.Exception? exception)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(context);

        // 检查是否存在异常
        if (exception is null)
        {
            return false;
        }

        // 检查是否配置了需要捕获的异常
        if (exceptionTypes?.Any(ex => ex.IsInstanceOfType(exception)) == true)
        {
            // 检查是否配置了操作结果条件
            if (ResultConditions is not null && ResultConditions.Count > 0)
            {
                return ResultConditions.Any(condition => condition(context));
            }

            return true;
        }

        return false;
    }
}