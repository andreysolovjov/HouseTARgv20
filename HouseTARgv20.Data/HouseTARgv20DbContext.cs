﻿using Microsoft.EntityFrameworkCore;
using HouseTARgv20.Core.Domain;

namespace HouseTARgv20.Data
{
    public class HouseTARgv20DbContext : DbContext
    {
        public HouseTARgv20DbContext(DbContextOptions<HouseTARgv20DbContext> options)
            : base(options) { }

        public DbSet<HouseDomain> House { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HouseDomain>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
