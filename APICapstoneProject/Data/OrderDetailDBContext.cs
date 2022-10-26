using APICapstoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace APICapstoneProject.Data
{
    public class OrderDetailDBContext:DbContext
    {


        public OrderDetailDBContext(DbContextOptions<OrderDetailDBContext> options) : base(options) { }



        //Dbset          
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(o => new { o.Uid, o.FurnitureNeeded, o.EquipmentNeeded });
        }


    }
}
