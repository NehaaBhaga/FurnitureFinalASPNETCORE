using APICapstoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace APICapstoneProject.Data
{
    public class VendorTableDBContext: DbContext
    {

        public VendorTableDBContext(DbContextOptions<VendorTableDBContext> options) : base(options) { }



        //Dbset          
        public DbSet<VendorTable> VendorTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VendorTable>()
                .HasKey(o => new { o.Uid, o.FurnitureNeeded, o.EquipmentNeeded });
        }

    }
}
