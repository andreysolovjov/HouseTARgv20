using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HouseTARgv20.Core.Domain
{
     public class HouseDomain
    {
        [Key]
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
