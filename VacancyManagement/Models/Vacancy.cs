namespace VacancyManagement.Models
{
    public class Vacancy
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public double Salary { get; set; }
    }
}