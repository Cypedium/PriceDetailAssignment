using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceDetailAssignment.Models
{
    public class HandlePriceDetailsDbContext : DbContext
    {
        public HandlePriceDetailsDbContext(DbContextOptions<HandlePriceDetailsDbContext> options): base(options)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
