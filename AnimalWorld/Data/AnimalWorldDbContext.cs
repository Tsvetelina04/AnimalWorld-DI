using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalWorld.Data
{
    public class AnimalWorldDbContext : IdentityDbContext<Client>
    {
        public AnimalWorldDbContext(DbContextOptions<AnimalWorldDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}
