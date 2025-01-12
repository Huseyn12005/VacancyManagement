using VacancyManagement.Models;


namespace VacancyManagement.Data
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly VacancyDbContext _context;

        public VacancyRepository(VacancyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vacancy> GetAll() => _context.Vacancies.ToList();

        public Vacancy GetById(int id) => _context.Vacancies.Find(id);

        public void Add(Vacancy vacancy)
        {
            _context.Vacancies.Add(vacancy);
            _context.SaveChanges();
        }

        public void Update(Vacancy vacancy)
        {
            _context.Vacancies.Update(vacancy);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var vacancy = _context.Vacancies.Find(id);
            if (vacancy != null)
            {
                _context.Vacancies.Remove(vacancy);
                _context.SaveChanges();
            }
        }
    }
}