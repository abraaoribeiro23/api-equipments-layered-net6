using Xunit;

namespace Api.Tests.Integration.Docker;

[CollectionDefinition(nameof(SharedTestCollection))]
public class SharedTestCollection : ICollectionFixture<CustomWebApplicationFactory>
{
    
}