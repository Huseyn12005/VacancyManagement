using VacancyManagement.Models;
using VacancyManagement.Data;

namespace VacancyManagement.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IVacancyRepository _repository;

        public VacancyService(IVacancyRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Vacancy> GetAllVacancies() => _repository.GetAll();

        public Vacancy GetVacancyById(int id) => _repository.GetById(id);

        public void CreateVacancy(Vacancy vacancy) => _repository.Add(vacancy);

        public void UpdateVacancy(Vacancy vacancy) => _repository.Update(vacancy);

        public void DeleteVacancy(int id) => _repository.Delete(id);
    }
}