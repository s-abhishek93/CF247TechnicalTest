using System;
using Microsoft.EntityFrameworkCore;

namespace CF247TechinalTest.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerItem> CustomerItems { get; set; }
    }
}
