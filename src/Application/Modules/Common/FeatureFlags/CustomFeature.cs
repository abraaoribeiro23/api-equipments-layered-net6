namespace Api.Modules.Common.FeatureFlags;

/// <summary>
///     Features Flags Enum.
/// </summary>
public enum CustomFeature
{
    /// <summary>
    ///     Get Equipment.
    /// </summary>
    Equipment,

    /// <summary>
    ///     Use Swagger.
    /// </summary>
    Swagger,

    /// <summary>
    ///     Use MsSqlServer.
    /// </summary>
    MsSqlServer,

    /// <summary>
    ///     Use PostgresSql.
    /// </summary>
    PostgresSql,

    /// <summary>
    ///     Use In-Memory Database.
    /// </summary>
    InMemoryDatabase,

    /// <summary>
    ///     Inject Initial Data on memory Db.
    /// </summary>
    InjectInitialData
}