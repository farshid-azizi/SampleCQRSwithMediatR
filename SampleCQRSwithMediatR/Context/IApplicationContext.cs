using Microsoft.EntityFrameworkCore;
using SampleCQRSwithMediatR.Models;

namespace SampleCQRSwithMediatR.Context
{
    public interface IApplicationContext
    {
        public DbSet<Person> Persons { get; set; }

        Task<int> SaveChangesAsync();
    }
}