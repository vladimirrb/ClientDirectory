using ClientDirectory.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientDirectory.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CitiesController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _cityRepository.GetAllAsync();
            return View(cities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
                await _cityRepository.AddAsync(city);
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _cityRepository.UpdateAsync(city);
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if (city != null)
            {
                await _cityRepository.DeleteAsync(city);
            }
            return RedirectToAction(nameof(Index));
        }
    }

}
