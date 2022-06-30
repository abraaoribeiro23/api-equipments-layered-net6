using System.Text;
using Aiko.Api.Modules.Common.FeatureFlags;
using Microsoft.FeatureManagement;
using Microsoft.IdentityModel.Tokens;

namespace Aiko.Api.Modules.Common;

/// <summary>
///     Authentication Extensions.
/// </summary>
public static class AuthenticationExtensions
{
    /// <summary>
    ///     Add Authentication Extensions.
    /// </summary>
    public static IServiceCollection AddAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}