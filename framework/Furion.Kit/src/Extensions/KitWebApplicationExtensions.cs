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

using System.Net.Mime;

namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// Kit 模块 <see cref="WebApplication"/> 拓展类
/// </summary>
public static class KitWebApplicationExtensions
{
    /// <summary>
    /// 添加 Kit 中间件
    /// </summary>
    /// <param name="webApplication"><see cref="WebApplication"/></param>
    /// <param name="configure"></param>
    /// <returns><see cref="WebApplication"/></returns>
    public static WebApplication UseKit(this WebApplication webApplication, Action<KitOptions>? configure = null)
    {
        var kitOptions = new KitOptions();
        configure?.Invoke(kitOptions);

        return webApplication.UseKit(kitOptions);
    }

    /// <summary>
    /// 添加 Kit 中间件
    /// </summary>
    /// <param name="webApplication"><see cref="WebApplication"/></param>
    /// <param name="kitOptions"></param>
    /// <returns><see cref="WebApplication"/></returns>
    public static WebApplication UseKit(this WebApplication webApplication, KitOptions kitOptions)
    {
        webApplication.MapGroup(kitOptions.Root)
            .MapGetSSE("endpoint-sse", async (HttpContext context, CancellationToken cancellationToken) =>
            {
                await new EndpointDiagnosticListener(kitOptions.Capacity).SSEHandler(context, cancellationToken);
            });

        webApplication.MapGroup(kitOptions.Root)
            .MapGet("configuration", async (HttpContext httpContext, IConfiguration configuration) =>
            {
                var jsonString = ConfigurationToJson(configuration);

                httpContext.Response.Headers.AccessControlAllowOrigin = "*";
                httpContext.Response.Headers.AccessControlAllowHeaders = "*";

                httpContext.Response.ContentType = MediaTypeNames.Application.Json;
                httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(jsonString);

                httpContext.Response.Headers.CacheControl = "no-cache";

                await httpContext.Response.WriteAsync(jsonString);
            }).ExcludeFromDescription();

        // 获取当前类型所在程序集
        var currentAssembly = typeof(KitWebApplicationExtensions).Assembly;

        // 添加 Kit 静态资源
        webApplication.UseFileServer(new FileServerOptions
        {
            FileProvider = new EmbeddedFileProvider(currentAssembly, $"{currentAssembly.GetName().Name}.Assets"),
            RequestPath = kitOptions.Root,
            EnableDirectoryBrowsing = false
        });

        return webApplication;
    }

    public static string ConfigurationToJson(IConfiguration configuration)
    {
        using var stream = new MemoryStream();
        using (var jsonWriter = new Utf8JsonWriter(stream, new JsonWriterOptions { Indented = true }))
        {
            jsonWriter.WriteStartObject();

            foreach (var section in configuration.GetChildren())
            {
                if (section.GetChildren().Any())
                {
                    jsonWriter.WritePropertyName(section.Key);
                    BuildJson(section, jsonWriter);
                }
                else
                {
                    jsonWriter.WriteString(section.Key, section.Value);
                }
            }

            jsonWriter.WriteEndObject();
        }

        var jsonString = Encoding.UTF8.GetString(stream.ToArray());
        return jsonString;
    }

    private static void BuildJson(IConfiguration configuration, Utf8JsonWriter jsonWriter)
    {
        jsonWriter.WriteStartObject();

        foreach (var section in configuration.GetChildren())
        {
            if (section.GetChildren().Any())
            {
                jsonWriter.WritePropertyName(section.Key);
                BuildJson(section, jsonWriter);
            }
            else
            {
                jsonWriter.WriteString(section.Key, section.Value);
            }
        }

        jsonWriter.WriteEndObject();
    }
}