using VacancyManagement.Models;



namespace VacancyManagement.Services
{
    public interface IVacancyService
    {
        IEnumerable<Vacancy> GetAllVacancies();
        Vacancy GetVacancyById(int id);
        void CreateVacancy(Vacancy vacancy);
        void UpdateVacancy(Vacancy vacancy);
        void DeleteVacancy(int id);
    }
}