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

namespace Furion.Kit.Tests;

public class EndpointDiagnosticModelTests
{
    [Fact]
    public void New_Invalid_Parameters()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var endpointDiagnosticModel = new EndpointDiagnosticModel(null!);
        });
    }

    [Fact]
    public async Task New_ReturnOK()
    {
        var port = Helpers.GetIdlePort();
        var urls = new[] { "--urls", $"http://localhost:{port}" };
        var builder = WebApplication.CreateBuilder(urls);

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(EndpointModelTests).Assembly);

        await using var app = builder.Build();

        app.Use(async (context, next) =>
        {
            var endpointDiagnosticModel = new EndpointDiagnosticModel(context);
            Assert.NotNull(endpointDiagnosticModel);
            Assert.NotNull(endpointDiagnosticModel._httpContext);
            Assert.NotNull(endpointDiagnosticModel.TraceIdentifier);
            Assert.Equal("GET", endpointDiagnosticModel.HttpMethod);
            Assert.Equal($"/Test/Test", endpointDiagnosticModel.Path);
            Assert.Equal($"http://localhost:{port}/Test/Test", endpointDiagnosticModel.UrlAddress);
            Assert.NotEqual(new DateTimeOffset(), endpointDiagnosticModel.RequestStartTime);
            Assert.NotNull(endpointDiagnosticModel.Query);
            Assert.NotNull(endpointDiagnosticModel.Cookies);
            Assert.NotNull(endpointDiagnosticModel.RequestHeaders);
            Assert.NotNull(endpointDiagnosticModel.RouteValues);
            Assert.NotNull(endpointDiagnosticModel.Endpoint);
            Assert.NotNull(endpointDiagnosticModel.ControllerAction);
            Assert.NotNull(endpointDiagnosticModel.Filters);
            Assert.Empty(endpointDiagnosticModel.Filters);
            Assert.Null(endpointDiagnosticModel.Exception);

            await next();
        });

        app.MapControllers();

        await app.StartAsync();

        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(nameof(EndpointModelTests));

        var httpResponseMessage = await httpClient.GetAsync($"http://localhost:{port}/Test/Test");
        httpResponseMessage.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Initialize_ReturnOK()
    {
        var port = Helpers.GetIdlePort();
        var urls = new[] { "--urls", $"http://localhost:{port}" };
        var builder = WebApplication.CreateBuilder(urls);

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(EndpointModelTests).Assembly);

        await using var app = builder.Build();

        app.Use(async (context, next) =>
        {
            var endpointDiagnosticModel = new EndpointDiagnosticModel(context);
            endpointDiagnosticModel.Initialize();

            await next();
        });

        app.MapControllers();

        await app.StartAsync();

        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(nameof(EndpointModelTests));

        var httpResponseMessage = await httpClient.GetAsync($"http://localhost:{port}/Test/Test");
        httpResponseMessage.EnsureSuccessStatusCode();
    }

    [Fact]
    public void SetResponseInfo_Invalid_Parameters()
    {
        var endpointDiagnosticModel = new EndpointDiagnosticModel(new DefaultHttpContext());

        Assert.Throws<ArgumentNullException>(() =>
        {
            endpointDiagnosticModel.SyncResponseData(null!);
        });
    }

    [Fact]
    public async Task SetResponseInfo_ReturnOK()
    {
        var port = Helpers.GetIdlePort();
        var urls = new[] { "--urls", $"http://localhost:{port}" };
        var builder = WebApplication.CreateBuilder(urls);

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(EndpointModelTests).Assembly);

        await using var app = builder.Build();

        app.Use(async (context, next) =>
        {
            await next();

            var endpointDiagnosticModel = new EndpointDiagnosticModel(context);
            endpointDiagnosticModel.SyncResponseData(context.Response);
            Assert.NotEqual(new DateTimeOffset(), endpointDiagnosticModel.RequestEndTime);
            Assert.Equal(200, endpointDiagnosticModel.StatusCode);
            Assert.Equal("OK", endpointDiagnosticModel.StatusText);
            Assert.Null(endpointDiagnosticModel.ContentType);
            Assert.NotNull(endpointDiagnosticModel.ResponseHeaders);
        });

        app.MapControllers();

        await app.StartAsync();

        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(nameof(EndpointModelTests));

        var httpResponseMessage = await httpClient.GetAsync($"http://localhost:{port}/Test/Test");
        httpResponseMessage.EnsureSuccessStatusCode();
    }
}