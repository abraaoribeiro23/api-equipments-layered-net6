using System.Reflection;
using Aiko.Domain.Bases;
using Aiko.Domain.Models;
using Aiko.Infra.Context;
using Aiko.Infra.Extensions;

namespace Aiko.UnitTests.DataInjectors;

public static class InjectDataOnContext
{
    private static readonly Type ClassType = typeof(InjectDataOnContext);
    private static readonly Assembly? Assembly = Assembly.GetAssembly(ClassType);
    private static readonly string JsonPath = $"{ClassType.Namespace}.SeedData";

    internal static void AddInContext<TEntity>(AppDbContext context, string path) where TEntity : BaseEntity
    {
        try
        {
            if (Assembly is null) return;
            var json = Assembly.GetManifestResourceStream(path);
            AddInContext<TEntity>(context, json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void AddInContext<TEntity>(AppDbContext context, Stream? json) where TEntity : BaseEntity
    {
        try
        {
            var entities = JsonUtilities.GetListFromJson<TEntity>(json);
            AddInContext(context, entities);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void AddInContext<TEntity>(AppDbContext context, IEnumerable<TEntity>? entities)
        where TEntity : BaseEntity
    {
        try
        {
            if (entities == null) return;
            context.AddRange(entities);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void InitializeDbForTests(AppDbContext? context)
    {
        try
        {
            if (context == null || Assembly is null) return;

            AddInContext<EquipmentModel>(context, $"{JsonPath}.equipment_model.json");
            AddInContext<EquipmentState>(context, $"{JsonPath}.equipment_state.json");
            AddInContext<Equipment>(context, $"{JsonPath}.equipment.json");
            AddInContext<EquipmentModelStateHourlyEarning>(context,
                $"{JsonPath}.equipment_model_state_hourly_earnings.json");
            AddInContext<EquipmentStateHistory>(context, $"{JsonPath}.equipment_state_history.json");
            AddInContext<EquipmentPositionHistory>(context, $"{JsonPath}.equipment_position_history.json");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}