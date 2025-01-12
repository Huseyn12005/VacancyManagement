using VacancyManagement.Models;

namespace VacancyManagement.Data
{
    public interface IVacancyRepository
    {
        IEnumerable<Vacancy> GetAll();
        Vacancy GetById(int id);
        void Add(Vacancy vacancy);
        void Update(Vacancy vacancy);
        void Delete(int id);
    }
}