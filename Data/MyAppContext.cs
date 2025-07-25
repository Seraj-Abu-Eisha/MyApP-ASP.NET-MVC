using Microsoft.EntityFrameworkCore;
using MyApP.Models;
namespace MyApP.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) { }
       
         public DbSet<Item> Items { get; set; }
    }
}
