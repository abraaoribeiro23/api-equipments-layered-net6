using System.Reflection;
using Aiko.Domain.Models;
using Aiko.Infra.Extensions;

namespace Aiko.Infra.Context;

public static class InMemoryContextFake
{
    private const string JsonPath = "Aiko.Infra.SeedData";
    private static readonly object SyncLock = new();

    /// <summary>
    ///     To reset memory database use -> context.Database.EnsureDeleted().
    /// </summary>
    public static void AddDataFakeContext(AppDbContext? context)
    {
        var assembly = Assembly.GetAssembly(typeof(JsonUtilities));
        

        lock (SyncLock)
        {
            if (context == null || assembly is null) return;


            if (!context.EquipmentModels.Any())
            {
                var entities =
                    JsonUtilities.GetListFromJson<EquipmentModel>(
                        assembly.GetManifestResourceStream($"{JsonPath}.equipment_model.json"));
                context.EquipmentModels.AddRange(entities!);
            }

            if (!context.EquipmentStates.Any())
            {
                var entities =
                    JsonUtilities.GetListFromJson<EquipmentState>(
                        assembly.GetManifestResourceStream($"{JsonPath}.equipment_state.json"));
                context.EquipmentStates.AddRange(entities!);
            }

            if (!context.EquipmentModelStateHourlyEarnings.Any())
            {
                var entities =
                    JsonUtilities.GetListFromJson<EquipmentModelStateHourlyEarning>(
                        assembly.GetManifestResourceStream($"{JsonPath}.equipment_model_state_hourly_earnings.json"));
                context.EquipmentModelStateHourlyEarnings.AddRange(entities!);
            }

            if (!context.EquipmentStateHistories.Any())
            {
                var entities =
                    JsonUtilities.GetListFromJson<EquipmentStateHistory>(
                        assembly.GetManifestResourceStream($"{JsonPath}.equipment_state_history.json"));
                context.EquipmentStateHistories.AddRange(entities!);
            }


            if (!context.EquipmentPositionHistories.Any())
            {
                var entities =
                    JsonUtilities.GetListFromJson<EquipmentPositionHistory>(
                        assembly.GetManifestResourceStream($"{JsonPath}.equipment_position_history.json"));
                context.EquipmentPositionHistories.AddRange(entities!);
            }

            if (!context.Equipments.Any())
            {
                var entities =
                    JsonUtilities.GetListFromJson<Equipment>(
                        assembly.GetManifestResourceStream($"{JsonPath}.equipment.json"));
                context.Equipments.AddRange(entities!);
            }

            context.SaveChanges();
        }
    }
}