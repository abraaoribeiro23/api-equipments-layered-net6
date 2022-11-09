using System;

namespace Api.Tests.Integration.Docker;

/// <summary>
/// </summary>
public sealed class CustomWebApplicationFactoryFixture : IDisposable
{
    public CustomWebApplicationFactoryFixture()
    {
        CustomWebApplicationFactory = new CustomWebApplicationFactory();
    }

    public CustomWebApplicationFactory CustomWebApplicationFactory { get; }

    public void Dispose()
    {
    }
}