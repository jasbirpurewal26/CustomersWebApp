using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomersWebApp.Models;

namespace CustomersWebApp.Data
{
    public class CustomersWebAppContext : DbContext
    {
        public CustomersWebAppContext (DbContextOptions<CustomersWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<CustomersWebApp.Models.Customer> Customer { get; set; } = default!;
    }
}
