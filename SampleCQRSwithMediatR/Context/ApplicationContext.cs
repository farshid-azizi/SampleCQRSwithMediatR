using Microsoft.EntityFrameworkCore;
using SampleCQRSwithMediatR.Models;

namespace SampleCQRSwithMediatR.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Person> Persons { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
       
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
