using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentModel> EquipmentModels { get; set; }
        public DbSet<EquipmentModelStateHourlyEarning> EquipmentModelStateHourlyEarnings { get; set; }
        public DbSet<EquipmentPositionHistory> EquipmentPositionHistories { get; set; }
        public DbSet<EquipmentState> EquipmentStates { get; set; }
        public DbSet<EquipmentStateHistory> EquipmentStateHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tables
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentModelConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentModelStateHourlyEarningConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentPositionHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentStateConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentStateHistoryConfiguration());
        }
    }
}