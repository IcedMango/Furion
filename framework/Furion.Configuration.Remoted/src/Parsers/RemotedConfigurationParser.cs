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

namespace Furion.Configuration;

/// <summary>
/// 远程配置解析器
/// </summary>
internal sealed class RemotedConfigurationParser
{
    /// <summary>
    /// 媒体类型和文件拓展名映射集合
    /// </summary>
    internal readonly IDictionary<string, string> _mediaTypeMappings;

    /// <inheritdoc cref="FileConfigurationParser" />
    internal readonly FileConfigurationParser _fileConfigurationParser;

    /// <summary>
    /// <inheritdoc cref="RemotedConfigurationParser"/>
    /// </summary>
    /// <param name="fileConfigurationParser"><see cref="FileConfigurationParser"/></param>
    /// <param name="mediaTypeMappings">媒体类型和文件拓展名映射集合</param>
    internal RemotedConfigurationParser(FileConfigurationParser fileConfigurationParser
        , IDictionary<string, string> mediaTypeMappings)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(fileConfigurationParser);
        ArgumentNullException.ThrowIfNull(mediaTypeMappings);

        _mediaTypeMappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"application/json", ".json" },
            {"application/vnd.api+json", ".json" },
            {"application/x-json", ".json" },
            {"text/json", ".json" },
            {"text/x-json", ".json" }
        };

        // 遍历集合添加/更新 媒体类型和文件拓展名映射
        foreach (var (mediaType, extension) in mediaTypeMappings)
        {
            _mediaTypeMappings[mediaType] = extension;
        }

        _fileConfigurationParser = fileConfigurationParser;
    }

    /// <summary>
    /// 解析远程请求地址并返回配置集合
    /// </summary>
    /// <param name="remotedConfigurationModel"><see cref="RemotedConfigurationModel"/></param>
    /// <returns><see cref="IDictionary{TKey, TValue}"/></returns>
    internal IDictionary<string, string?> ParseRequestUri(RemotedConfigurationModel remotedConfigurationModel)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(remotedConfigurationModel);

        // 请求远程地址并返回响应流
        using var stream = ReadAsStream(remotedConfigurationModel, out var extension);

        // 空检查
        if (stream is null)
        {
            return new Dictionary<string, string?>();
        }

        // 调用文件配置解析器对象进行解析
        var keyValues = _fileConfigurationParser.Parse(extension!, stream);

        // 调试事件信息
        var debugMessage = "The remote address `{0}` has been successfully loaded into the configuration.";

        // 检查是否设置了前缀
        if (!string.IsNullOrWhiteSpace(remotedConfigurationModel.Prefix))
        {
            // 遍历字典集合并包装 Key
            keyValues = keyValues.ToDictionary(u => $"{remotedConfigurationModel.Prefix.TrimEnd(':')}:{u.Key}"
                , u => u.Value
                , StringComparer.OrdinalIgnoreCase);

            debugMessage += " (Prefix is `{1}`)";
        }

        // 输出调试事件
        Debugging.File(debugMessage, remotedConfigurationModel.RequestUri, remotedConfigurationModel.Prefix?.TrimEnd(':'));

        return keyValues;
    }

    /// <summary>
    /// 请求远程地址并返回响应流
    /// </summary>
    /// <param name="remotedConfigurationModel"><see cref="RemotedConfigurationModel"/></param>
    /// <param name="extension">文件拓展名</param>
    /// <returns><see cref="Stream"/></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="NotSupportedException"></exception>
    internal Stream? ReadAsStream(RemotedConfigurationModel remotedConfigurationModel, out string? extension)
    {
        // 空检查
        ArgumentNullException.ThrowIfNull(remotedConfigurationModel);

        // 创建 HttpClient 请求对象
        using var httpClient = new HttpClient
        {
            Timeout = remotedConfigurationModel.Timeout
        };

        // 添加默认 User-Agent
        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(nameof(RemotedConfigurationParser));

        // 限制最大的响应流大小为 10M
        httpClient.MaxResponseContentBufferSize = 1024 * 1024 * 10;

        // 若请求为 GET 请求则禁用 HTTP 缓存
        if (remotedConfigurationModel.HttpMethod == HttpMethod.Get)
        {
            httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true
            };
        }

        // 调用自定义 HttpClient 配置委托
        remotedConfigurationModel.ClientConfigurator?.Invoke(httpClient);

        // 声明 HTTP 请求响应信息
        HttpResponseMessage httpResponseMessage;

        // 处理可选配置
        try
        {
            // 发送 HTTP 请求
            httpResponseMessage = httpClient.Send(
                new HttpRequestMessage(remotedConfigurationModel.HttpMethod, remotedConfigurationModel.RequestUri));

            // 确保请求成功
            httpResponseMessage.EnsureSuccessStatusCode();
        }
        catch
        {
            // 检查是否设置可选配置
            if (!remotedConfigurationModel.Optional)
            {
                throw;
            }

            // 输出调试事件
            Debugging.Warn("The HTTP request encountered an error but has been processed.");

            extension = null;
            return null;
        }

        // 读取响应报文中的 Content-Type
        if (!httpResponseMessage.Content.Headers.TryGetValues("Content-Type", out var contentTypes))
        {
            throw new InvalidOperationException("Content-Type definition not found in the response message.");
        }

        // 取出首个 Content-Type 并根据 ; 切割，目的是处理携带 charset 的值
        var mediaType = contentTypes.First()
            .Split(';', StringSplitOptions.RemoveEmptyEntries)
            .First();

        // 检查当前媒体类型是否是受支持的类型
        if (!_mediaTypeMappings.TryGetValue(mediaType, out var extensionValue))
        {
            throw new NotSupportedException($"`{mediaType}` is not a supported media type.");
        }

        // 设置拓展名
        extension = extensionValue;

        // 读取响应流
        var stream = httpResponseMessage.Content.ReadAsStream();

        return stream;
    }
}