using Xunit;
using Moq;
using VacancyManagement.Data;
using VacancyManagement.Models;
using VacancyManagement.Services;
using System.Collections.Generic;

namespace VacancyManagement.Tests.Services
{
    public class VacancyServiceTests
    {
        private readonly Mock<IVacancyRepository> _mockRepo;
        private readonly VacancyService _service;

        public VacancyServiceTests()
        {
            _mockRepo = new Mock<IVacancyRepository>();
            _service = new VacancyService(_mockRepo.Object);
        }

        [Fact]
        public void CreateVacancy_ShouldAddVacancy()
        {
            var vacancy = new Vacancy { Id = 1, Title = "Developer", Description = "Backend Developer", Salary = 1000 };
            _service.CreateVacancy(vacancy);
            _mockRepo.Verify(r => r.Add(vacancy), Times.Once);
        }

        [Fact]
        public void GetAllVacancies_ShouldReturnAllVacancies()
        {
            var vacancies = new List<Vacancy>
            {
                new Vacancy { Id = 1, Title = "Developer", Description = "Backend Developer", Salary = 1000 },
                new Vacancy { Id = 2, Title = "Designer", Description = "UI/UX Designer", Salary = 800 }
            };
            _mockRepo.Setup(r => r.GetAll()).Returns(vacancies);

            var result = _service.GetAllVacancies();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetVacancyById_ShouldReturnCorrectVacancy()
        {
            var vacancy = new Vacancy { Id = 1, Title = "Developer" };
            _mockRepo.Setup(r => r.GetById(1)).Returns(vacancy);

            var result = _service.GetVacancyById(1);

            Assert.NotNull(result);
            Assert.Equal("Developer", result.Title);
        }

        [Fact]
        public void UpdateVacancy_ShouldModifyVacancy()
        {
            var vacancy = new Vacancy { Id = 1, Title = "Junior Developer" };

            _service.UpdateVacancy(vacancy);

            _mockRepo.Verify(r => r.Update(vacancy), Times.Once);
        }

        [Fact]
        public void DeleteVacancy_ShouldRemoveVacancy()
        {
            var vacancyId = 1;

            _service.DeleteVacancy(vacancyId);

            _mockRepo.Verify(r => r.Delete(vacancyId), Times.Once);
        }
    }
}
