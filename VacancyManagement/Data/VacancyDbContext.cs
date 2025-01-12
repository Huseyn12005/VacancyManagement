using Microsoft.EntityFrameworkCore;
using VacancyManagement.Models;

namespace VacancyManagement.Data
{
    public class VacancyDbContext : DbContext
    {
        public VacancyDbContext(DbContextOptions<VacancyDbContext> options)
            : base(options) { }

        public DbSet<Vacancy> Vacancies { get; set; }
    }
}