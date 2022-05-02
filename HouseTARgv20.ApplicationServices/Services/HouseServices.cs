using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using HouseTARgv20.Core.Domain;
using HouseTARgv20.Core.Dtos;
using HouseTARgv20.Core.ServiceInterface;
using HouseTARgv20.Data;

namespace HouseTARgv20.ApplicationServices.Services
{
    public class HouseServices : IHouseService
    {
        private readonly HouseTARgv20DbContext _context;


        public HouseServices
            (
                HouseTARgv20DbContext context
            )
        {
            _context = context;
        }

        public async Task<HouseDomain> Edit(Guid id)
        {
            var result = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<HouseDomain> Add(HouseDto dto)
        {
            HouseDomain house = new HouseDomain();

            house.Id = Guid.NewGuid();
            house.Address = dto.Address;
            house.Rooms = dto.Rooms;
            house.Price = dto.Price;
            house.Description = dto.Description;
            house.Material = dto.Material;
            house.ConstructedAt = dto.ConstructedAt;
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;


            await _context.House.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }

        public async Task<HouseDomain> Update(HouseDto dto)
        {
            HouseDomain house = new HouseDomain();

            house.Id = dto.Id;
            house.Address = dto.Address;
            house.Rooms = dto.Rooms;
            house.Price = dto.Price;
            house.Description = dto.Description;
            house.Material = dto.Material;
            house.ConstructedAt = dto.ConstructedAt;
            house.CreatedAt = dto.CreatedAt;
            house.ModifiedAt = dto.ModifiedAt;


            _context.House.Update(house);
            await _context.SaveChangesAsync();

            return house;
        }

        public async Task<HouseDomain> Delete(Guid id)
        {
            var house = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.House.Remove(house);
            await _context.SaveChangesAsync();

            return house;
        }

        public async Task<HouseDomain> GetAsync(Guid id)
        {
            var result = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
