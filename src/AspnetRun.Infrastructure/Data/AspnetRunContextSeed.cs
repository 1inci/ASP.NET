using AspnetRun.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Data
{
    public class AspnetRunContextSeed
    {
        public static async Task SeedAsync(AspnetRunContext aspnetrunContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // TODO: Only run this if using a real database
                aspnetrunContext.Database.Migrate();
                aspnetrunContext.Database.EnsureCreated();

              

                if (!aspnetrunContext.Buildings.Any())
                {
                    aspnetrunContext.Buildings.AddRange(GetPreconfiguredBuildings());
                    await aspnetrunContext.SaveChangesAsync();
                }

                if (!aspnetrunContext.Rooms.Any())
                {
                    aspnetrunContext.Rooms.AddRange(GetPreconfiguredRooms());
                    await aspnetrunContext.SaveChangesAsync();
                }

                if (!aspnetrunContext.WareHouses.Any())
                {
                    aspnetrunContext.WareHouses.AddRange(GetPreconfiguredWareHouses());
                    await aspnetrunContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AspnetRunContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(aspnetrunContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }



        private static IEnumerable<Building> GetPreconfiguredBuildings()
        {
            return new List<Building>()
            {
                new Building() { BuildingName = "Yıldız",Description="Arka Komşu",Location="Batıkent",NumberOfFloors=2,BuildingAge=20},
                new Building() { BuildingName = "Kilic",Description="Arka Komşu",Location="Batıkent",NumberOfFloors=2,BuildingAge=20}
            };
        }
        private static IEnumerable<Room> GetPreconfiguredRooms()
        {
            return new List<Room>()
            {
                new Room() {RoomName="Köşe",Description="Köşe geniş manzaralı",BuildingId=1,NumberOfBathroom=2,NumberOfBedRoom=1,NumberOfLivingRoom=3,SquareMeters=135},
                new Room() {RoomName="Ara",Description="Ara ,manzaralı",BuildingId=2,NumberOfBathroom=1,NumberOfBedRoom=1,NumberOfLivingRoom=2,SquareMeters=100},
                new Room() {RoomName="Ara",Description="Ara ,Deniz manzaralı",BuildingId=2,NumberOfBathroom=1,NumberOfBedRoom=1,NumberOfLivingRoom=1,SquareMeters=80}

            };
        }
        private static IEnumerable<WareHouse> GetPreconfiguredWareHouses()
        {
            return new List<WareHouse>()
            {
                new WareHouse() {WareHouseName="Yeni Depo",SquareMeters=60,BuildingId=1,Description="Ferah ve dolaplı"},
                new WareHouse() {WareHouseName="Giriş",SquareMeters=25,BuildingId=1,Description="2 katlı"},
                new WareHouse() {WareHouseName="Geniş ve pencereli",SquareMeters=150,BuildingId=2,Description="Ortak kullanım, çok geniş"},
            };
        }

    }
}
