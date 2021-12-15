using AspnetRun.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetRun.Infrastructure.Data
{
    public class AspnetRunContext : DbContext
    {
        public AspnetRunContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Building>(ConfigureBuilding);
            builder.Entity<Room>(ConfigureRoom);
            builder.Entity<WareHouse>(ConfigureWareHouse);
        }


        private void ConfigureBuilding(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Building");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.BuildingName)
                .IsRequired()
                .HasMaxLength(200);
        }

        private void ConfigureRoom(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.RoomName)
                .IsRequired()
                .HasMaxLength(200);
        }

        private void ConfigureWareHouse(EntityTypeBuilder<WareHouse> builder)
        {
            builder.ToTable("WareHouse");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.WareHouseName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
