using Microsoft.AspNetCore.Mvc;
using VacancyManagement.Models;
using VacancyManagement.Services;

namespace VacancyManagement.Controllers
{
    public class VacancyController : Controller
    {
        private readonly IVacancyService _service;

        public VacancyController(IVacancyService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var vacancies = _service.GetAllVacancies();
            return View(vacancies);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                _service.CreateVacancy(vacancy);
                return RedirectToAction(nameof(Index));
            }
            return View(vacancy);
        }

        public IActionResult Edit(int id)
        {
            var vacancy = _service.GetVacancyById(id);
            return vacancy == null ? NotFound() : View(vacancy);
        }

        [HttpPost]
        public IActionResult Edit(Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateVacancy(vacancy);
                return RedirectToAction(nameof(Index));
            }
            return View(vacancy);
        }

        public IActionResult Delete(int id)
        {
            _service.DeleteVacancy(id);
            return RedirectToAction(nameof(Index));
        }
    }
}