using DogsHouseService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace DogsHouseService.Data
{
    public class DogsContext : DbContext
    {
        public DogsContext(DbContextOptions<DogsContext> options) : base(options) { }
        public DbSet<Dog> Dogs { get; set; }

    }

}
