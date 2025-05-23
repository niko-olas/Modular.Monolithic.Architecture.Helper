// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Orders;

namespace MinimalApi.Infrastructure
{
    public class MinimalApiDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }


        public MinimalApiDbContext(DbContextOptions<MinimalApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
