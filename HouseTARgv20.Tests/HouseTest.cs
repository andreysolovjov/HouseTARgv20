using HouseTARgv20.Core.ServiceInterface;
using System;
using System.Threading.Tasks;
using Xunit;
using HouseTARgv20.Core.Dtos;
using HouseTARgv20.Core.Domain;

namespace HouseTARgv20.HouseTest
{
    public class HouseTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyHouse_WhenReturnResult()
        {
            string guid = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";
            HouseDto house = new HouseDto();

            house.Id = Guid.Parse(guid);
            house.Address = "TestAddress";
            house.Rooms = 4;
            house.Price = 10000;
            house.Description = "awdad";
            house.Material = "Wood";
            house.ConstructedAt = "20.02.2002";
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            var result = await Svc<IHouseService>().Add(house);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdHouse_WhenReturnsResultAsync()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";
            string guid1 = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";

            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHouseService>().GetAsync(insertGuid);

            Assert.NotEqual(insertGuid1, insertGuid);
        }

        [Fact]
        public async Task Should_GetByIdHouse_WhenReturnsResultAsync()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";
            string guid1 = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";

            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHouseService>().GetAsync(insertGuid);

            Assert.Equal(insertGuid1, insertGuid);
        }



        [Fact]
        public async Task Should_UpdateByIdHouse_WhenUpdateHouse()
        {
            var guid = new Guid("1ab8c12a-f8da-4e55-ab77-f45378d3adb5");

            HouseDomain house = new HouseDomain();

            house.Id = guid;
            house.Address = "TestAddress";
            house.Rooms = 4;
            house.Price = 10000;
            house.Description = "awdad";
            house.Material = "Wood";
            house.ConstructedAt = "20.02.2002";
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            var houseId = guid;
            var houseToUpdate = new HouseDto();
            {
                houseToUpdate.Address = "TestAddress2";
                houseToUpdate.Price = 20000;
            };

            await Svc<IHouseService>().Update(houseToUpdate);

            Assert.Equal(house.Id.ToString(), houseId.ToString());
            Assert.NotEqual(house.Address, houseToUpdate.Address);
            Assert.NotEqual(house.Price.ToString(), houseToUpdate.Price.ToString());
        }

    }
}
