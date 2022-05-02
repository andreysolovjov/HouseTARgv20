using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using HouseTARgv20.Core.Dtos;
using HouseTARgv20.Core.ServiceInterface;
using HouseTARgv20.Data;
using HouseTARgv20.Models.House;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HouseTARgv20.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseTARgv20DbContext _context;
        private readonly IHouseService _houseService;

        public HouseController
            (
                HouseTARgv20DbContext context,
                IHouseService houseService
            )
        {
            _context = context;
            _houseService = houseService;
        }


        public IActionResult Index()
        {
            var result = _context.House
                .Select(x => new HouseListViewModel 
                {
                    Id = x.Id,
                    Address = x.Address,
                    Rooms = x.Rooms,
                    Price = x.Price,
                    Description = x.Description,
                    Material = x.Material,
                    ConstructedAt = x.ConstructedAt,
                    CreatedAt = x.CreatedAt,
                    ModifiedAt = x.ModifiedAt
                }).ToList();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var house = await _houseService.Delete(id);

            if (house == null)
            {
                RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            HouseViewModel model = new HouseViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Address = model.Address,
                Rooms = model.Rooms,
                Price = model.Price,
                Description = model.Description,
                Material = model.Material,
                ConstructedAt = model.ConstructedAt,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt
            };

            var result = await _houseService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var house = await _houseService.Edit(id);
            if (house == null)
            {
                return NotFound();
            }

            var model = new HouseViewModel();

            model.Id = house.Id;
            model.Address = house.Address;
            model.Rooms = house.Rooms;
            model.Price = house.Price;
            model.Description = house.Description;
            model.Material = house.Material;
            model.ConstructedAt = house.ConstructedAt;
            model.CreatedAt = house.CreatedAt;
            model.ModifiedAt = house.ModifiedAt;

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Update(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Address = model.Address,
                Rooms = model.Rooms,
                Price = model.Price,
                Description = model.Description,
                Material = model.Material,
                ConstructedAt = model.ConstructedAt,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt
            };

            var result = await _houseService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);

        }

    }
}

