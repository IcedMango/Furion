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

namespace Furion.Exception.Tests;

public class UserFriendlyExceptionTests
{
    [Fact]
    public void New_ReturnOK()
    {
        var exception1 = new UserFriendlyException();
        var exception2 = new UserFriendlyException("出错了~");
        var exception3 = new UserFriendlyException("出错了~", new System.Exception());

        Assert.NotNull(exception1);
        Assert.Null(exception1.Code);
        Assert.Equal(ExceptionLevel.Service, exception1.Level);
        Assert.NotNull(exception2);
        Assert.Equal(ExceptionLevel.Service, exception2.Level);
        Assert.NotNull(exception3);
        Assert.Equal(ExceptionLevel.Service, exception3.Level);
    }

    [Fact]
    public void WithCode_Invalid_Parameters()
    {
        var exception = new UserFriendlyException();

        Assert.Throws<ArgumentNullException>(() =>
        {
            exception.WithCode(null!);
        });
    }

    [Fact]
    public void WithCode_ReturnOK()
    {
        var exception = new UserFriendlyException();

        exception.WithCode(ExceptionCodeModel.Default);
        Assert.Equal(ExceptionCodeModel.Default, exception.Code);
    }

    [Fact]
    public void SetLevel_ReturnOK()
    {
        var exception = new UserFriendlyException();

        exception.SetLevel(ExceptionLevel.System);
        Assert.Equal(ExceptionLevel.System, exception.Level);
    }

    [Fact]
    public void Throw_Parameterless_ReturnOK()
    {
        var exception = Assert.Throws<UserFriendlyException>(() =>
        {
            UserFriendlyException.Throw();
        });

        Assert.Equal(Constants.DEFAULT_EXCEPTION_MESSAGE, exception.Message);
        Assert.Equal(Constants.DEFAULT_EXCEPTION_MESSAGE, exception.Code);
    }

    [Fact]
    public void Throw_Invalid_Parameters()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            UserFriendlyException.Throw(null!);
        });
    }

    [Theory]
    [InlineData("出错啦", "出错啦")]
    [InlineData(true, "True")]
    [InlineData(false, "False")]
    [InlineData(0, "0")]
    [InlineData(ExceptionCodeModel.None, "None")]
    [InlineData(ExceptionCodeModel.Default, "缺省值")]
    [InlineData(ExceptionCodeModel.Other, "其他  的", "")]
    [InlineData("出错啦 {0} ~", "出错啦 furion ~", "furion")]
    [InlineData(ExceptionCodeModel.Other, "其他 furion 的", "furion")]
    public void Throw_ReturnOK(object code, string result, params object?[] args)
    {
        var exception = Assert.Throws<UserFriendlyException>(() =>
        {
            UserFriendlyException.Throw(code, args);
        });

        Assert.Equal(result, exception.Message);
        Assert.Equal(code, exception.Code);
    }

    [Fact]
    public void ThrowGeneric_Invalid_Parameters()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            UserFriendlyException.Throw<string>(null!);
        });
    }

    [Theory]
    [InlineData("出错啦", "出错啦")]
    [InlineData(true, "True")]
    [InlineData(false, "False")]
    [InlineData(0, "0")]
    [InlineData(ExceptionCodeModel.None, "None")]
    [InlineData(ExceptionCodeModel.Default, "缺省值")]
    [InlineData(ExceptionCodeModel.Other, "其他  的", "")]
    [InlineData("出错啦 {0} ~", "出错啦 furion ~", "furion")]
    [InlineData(ExceptionCodeModel.Other, "其他 furion 的", "furion")]
    public void ThrowGeneric_ReturnOK(object code, string result, params object?[] args)
    {
        var exception = Assert.Throws<UserFriendlyException>(() =>
        {
            string? name = null;
            var str = name ?? UserFriendlyException.Throw<string>(code, args);
        });

        Assert.Equal(result, exception.Message);
        Assert.Equal(code, exception.Code);
    }

    [Fact]
    public void ThrowGeneric_WithType_Invalid_Parameters()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            UserFriendlyException.Throw<string>(null!, (Type)null!);
        });

        Assert.Throws<ArgumentNullException>(() =>
        {
            UserFriendlyException.Throw<string>("", (Type)null!);
        });
    }

    [Theory]
    [InlineData("出错啦", "出错啦")]
    [InlineData(true, "True")]
    [InlineData(false, "False")]
    [InlineData(0, "0")]
    [InlineData(ExceptionCodeModel.None, "None")]
    [InlineData(ExceptionCodeModel.Default, "缺省值")]
    [InlineData(ExceptionCodeModel.Other, "其他  的", "")]
    [InlineData("出错啦 {0} ~", "出错啦 furion ~", "furion")]
    [InlineData(ExceptionCodeModel.Other, "其他 furion 的", "furion")]
    public void ThrowGeneric_WithType_ReturnOK(object code, string result, params object?[] args)
    {
        var exception = Assert.Throws<UserFriendlyException>(() =>
        {
            string? name = null;
            var str = name ?? UserFriendlyException.Throw<string>(code, typeof(InvalidOperationException), args);
        });

        Assert.NotNull(exception.Message);
        Assert.Equal(code, exception.Code);
        Assert.NotNull(exception.InnerException);
        Assert.True(exception.InnerException is InvalidOperationException);
        Assert.Equal(result, exception.InnerException.Message);
    }

    [Fact]
    public void ThrowIf_Parameterless_ReturnOK()
    {
        UserFriendlyException.ThrowIf(false);

        var exception = Assert.Throws<UserFriendlyException>(() =>
        {
            UserFriendlyException.ThrowIf(true);
        });

        Assert.Equal(Constants.DEFAULT_EXCEPTION_MESSAGE, exception.Message);
        Assert.Equal(Constants.DEFAULT_EXCEPTION_MESSAGE, exception.Code);
    }

    [Theory]
    [InlineData("出错啦", "出错啦")]
    [InlineData(true, "True")]
    [InlineData(false, "False")]
    [InlineData(0, "0")]
    [InlineData(ExceptionCodeModel.None, "None")]
    [InlineData(ExceptionCodeModel.Default, "缺省值")]
    [InlineData(ExceptionCodeModel.Other, "其他  的", "")]
    [InlineData("出错啦 {0} ~", "出错啦 furion ~", "furion")]
    [InlineData(ExceptionCodeModel.Other, "其他 furion 的", "furion")]
    public void ThrowIf_ReturnOK(object code, string result, params object?[] args)
    {
        UserFriendlyException.ThrowIf(false, code, args);

        var exception = Assert.Throws<UserFriendlyException>(() =>
        {
            UserFriendlyException.ThrowIf(true, code, args);
        });

        Assert.Equal(result, exception.Message);
        Assert.Equal(code, exception.Code);
    }

    [Fact]
    public void ThrowIfNull_ReturnOK()
    {
        UserFriendlyException.ThrowIfNull("furion");

        var excetpion = Assert.Throws<UserFriendlyException>(() =>
        {
            UserFriendlyException.ThrowIfNull(null, "furion");
        });

        Assert.NotNull(excetpion.Message);
        Assert.NotNull(excetpion.InnerException);

        var argumentException = excetpion.InnerException as ArgumentNullException;
        Assert.NotNull(argumentException);
        Assert.Equal("furion", argumentException.ParamName);
    }

    [Fact]
    public void ThrowIfNullOrWhiteSpace_ReturnOK()
    {
        UserFriendlyException.ThrowIfNullOrWhiteSpace("furion");

        var excetpion = Assert.Throws<UserFriendlyException>(() =>
        {
            UserFriendlyException.ThrowIfNullOrWhiteSpace(null!, "furion");
        });

        Assert.NotNull(excetpion.Message);
        Assert.NotNull(excetpion.InnerException);

        var argumentException = excetpion.InnerException as ArgumentNullException;
        Assert.NotNull(argumentException);
        Assert.Equal("furion", argumentException.ParamName);

        var excetpion1 = Assert.Throws<UserFriendlyException>(() =>
        {
            UserFriendlyException.ThrowIfNullOrWhiteSpace("  ", "furion");
        });

        Assert.NotNull(excetpion1.Message);
        Assert.NotNull(excetpion1.InnerException);

        var argumentException1 = excetpion1.InnerException as ArgumentException;
        Assert.NotNull(argumentException1);
        Assert.Equal("furion", argumentException1.ParamName);
        Assert.Equal("Argument is whitespace. (Parameter 'furion')", argumentException1.Message);
    }

    [Fact]
    public void ThrowIfNullOrEmpty_ReturnOK()
    {
        UserFriendlyException.ThrowIfNullOrEmpty("furion");

        var excetpion = Assert.Throws<UserFriendlyException>(() =>
        {
            UserFriendlyException.ThrowIfNullOrEmpty(null!, "furion");
        });

        Assert.NotNull(excetpion.Message);
        Assert.NotNull(excetpion.InnerException);

        var argumentException = excetpion.InnerException as ArgumentNullException;
        Assert.NotNull(argumentException);
        Assert.Equal("furion", argumentException.ParamName);

        var excetpion1 = Assert.Throws<UserFriendlyException>(() =>
        {
            UserFriendlyException.ThrowIfNullOrEmpty(string.Empty, "furion");
        });

        Assert.NotNull(excetpion1.Message);
        Assert.NotNull(excetpion1.InnerException);

        var argumentException1 = excetpion1.InnerException as ArgumentException;
        Assert.NotNull(argumentException1);
        Assert.Equal("furion", argumentException1.ParamName);
        Assert.Equal("Argument is empty. (Parameter 'furion')", argumentException1.Message);
    }

    [Fact]
    public void ThrowIfNullOrEmpty_Collection_ReturnOK()
    {
        UserFriendlyException.ThrowIfNullOrEmpty(new List<string> { "furion" });

        var excetpion = Assert.Throws<UserFriendlyException>(() =>
        {
            UserFriendlyException.ThrowIfNullOrEmpty((ICollection<string>)null!, "furion");
        });

        Assert.NotNull(excetpion.Message);
        Assert.NotNull(excetpion.InnerException);

        var argumentException = excetpion.InnerException as ArgumentNullException;
        Assert.NotNull(argumentException);
        Assert.Equal("furion", argumentException.ParamName);

        var excetpion1 = Assert.Throws<UserFriendlyException>(() =>
        {
            UserFriendlyException.ThrowIfNullOrEmpty(Array.Empty<string>(), "furion");
        });

        Assert.NotNull(excetpion1.Message);
        Assert.NotNull(excetpion1.InnerException);

        var argumentException1 = excetpion1.InnerException as ArgumentException;
        Assert.NotNull(argumentException1);
        Assert.Equal("furion", argumentException1.ParamName);
        Assert.Equal("Collection is empty. (Parameter 'furion')", argumentException1.Message);
    }
}