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

namespace Furion.DependencyInjection.Tests;

public class NamedServiceTests
{
    [Fact]
    public void INamedService_ExistsResolve_ReturnOK()
    {
        var name = "name1";
        var services = new ServiceCollection();
        services.AddNamed(name, ServiceDescriptor.Scoped<INamedClass, NamedClass>());

        var serviceProvider = services.BuildServiceProvider();
        var namedService = serviceProvider.GetRequiredService<INamedService<INamedClass>>();
        Assert.NotNull(namedService);

        var service1 = namedService[name];
        var service2 = namedService.Get(name);
        Assert.NotNull(service1);
        Assert.NotNull(service2);
        Assert.Equal(service1, service2);
    }

    [Fact]
    public void INamedService_EmptyRegister_ReturnOops()
    {
        var services = new ServiceCollection();
        services.AddNamed();

        Assert.Throws<InvalidOperationException>(() =>
        {
            var serviceProvider = services.BuildServiceProvider();
            var namedService = serviceProvider.GetRequiredService<INamedService<INamedClass>>();
            var service1 = namedService["name1"];
        });
    }

    [Fact]
    public void INamedService_EmptyRegister_ReturnOK()
    {
        var services = new ServiceCollection();
        services.AddNamed();

        var serviceProvider = services.BuildServiceProvider();
        var namedService = serviceProvider.GetRequiredService<INamedService<INamedClass>>();
        var service1 = namedService.Get("name1");
        Assert.Null(service1);
    }

    [Fact]
    public void INamedService_GetEnumerator_ReturnOK()
    {
        var name = "name1";
        var guid = Guid.NewGuid();

        var services = new ServiceCollection();
        services.AddNamed(name, ServiceDescriptor.Scoped<INamedClass, NamedClass>());
        services.AddNamed(name, ServiceDescriptor.Scoped<INamedClass>(sp =>
        {
            return new NamedClass
            {
                Id = guid
            };
        }));

        var serviceProvider = services.BuildServiceProvider();
        var namedService = serviceProvider.GetRequiredService<INamedService<INamedClass>>();
        var service1s = namedService.GetEnumerator(name);
        var count = service1s.LongCount();

        Assert.Equal(2, count);

        var service2 = service1s.Last();
        Assert.Equal(guid, service2.Id);
    }
}