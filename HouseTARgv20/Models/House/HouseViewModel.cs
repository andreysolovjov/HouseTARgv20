using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace HouseTARgv20.Models.House
{
    public class HouseViewModel
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public string ConstructedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
