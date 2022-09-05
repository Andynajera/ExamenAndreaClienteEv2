using Microsoft.EntityFrameworkCore;
using Models;

namespace Product.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
       
        public DbSet<CiudadesItem>? CiudadItem { get; set; }
        public DbSet<MenuItem>? MenuItems { get; set; }
        
    }
}
