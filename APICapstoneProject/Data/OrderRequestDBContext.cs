using APICapstoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace APICapstoneProject.Data
{
    public class OrderRequestDBContext: DbContext
    {
     
      public OrderRequestDBContext(DbContextOptions<OrderRequestDBContext> options) : base(options) { }       
        
       

        //Dbset          
          public DbSet<OrderRequest> OrderRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderRequest>()
                .HasKey(o => new { o.Uid, o.FurnitureNeeded , o.EquipmentNeeded });
        }



    }
}


