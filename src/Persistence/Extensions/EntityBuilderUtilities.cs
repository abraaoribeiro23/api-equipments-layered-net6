using System.Reflection;
using Domain.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Extensions;

public static class EntityBuilderUtilities
{
    public static void InsertSeedData<TEntity>(
        this EntityTypeBuilder<TEntity> builder, string seedJsonPath) where TEntity : BaseEntity
    {
        var assembly = Assembly.GetAssembly(typeof(JsonUtilities));
        var entities =
            JsonUtilities.GetListFromJson<TEntity>(assembly?.GetManifestResourceStream(seedJsonPath));
        var hydratedEntities = HydrateValues(entities);

        if (hydratedEntities != null) builder.HasData(hydratedEntities);
    }

    private static IEnumerable<TEntity>? HydrateValues<TEntity>(IEnumerable<TEntity>? entities) where TEntity : BaseEntity
    {
        return entities?.Select(entity =>
        {
            if (Guid.Empty == entity.Id)
                entity.Id = Guid.NewGuid();

            return entity;
        });
    }
}
