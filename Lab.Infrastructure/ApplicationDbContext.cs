using Lab.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab.Infrastructure
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
    }
}
