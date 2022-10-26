using APICapstoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace APICapstoneProject.Data
{
    public class RegistrationsDbContext : DbContext
    {
        public RegistrationsDbContext(DbContextOptions<RegistrationsDbContext> options) : base(options)
        {
           
        }

        //DbSet
        public DbSet<Registration> Registrations { get; set; }
    }
}
