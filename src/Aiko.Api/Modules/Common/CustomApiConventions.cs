using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Aiko.Api.Modules.Common;

/// <summary>
/// </summary>
public static class CustomApiConventions
{
    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void Create(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object model)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(409)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void Delete(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(409)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void Edit(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object model)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(409)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void Find(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(409)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void Get(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    [ProducesResponseType(409)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void List()
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(409)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void Post(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object model)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(409)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void Patch(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id,
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object model)
    {
        // Convention
    }

    /// <summary>
    /// </summary>
    [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
    [ProducesDefaultResponseType]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(409)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public static void Update(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object id,
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object model)
    {
        // Convention
    }
}