using ClientDirectory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace ClientDirectory.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICityRepository _cityRepository;

        public CompaniesController(ICompanyRepository companyRepository, ICityRepository cityRepository)
        {
            _companyRepository = companyRepository;
            _cityRepository = cityRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Cities = new SelectList(await _cityRepository.GetAllAsync(), "Id", "Name");
            var companies = await _companyRepository.GetCompaniesWithCityAsync();
            return View(companies);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Cities"] = new SelectList(await _cityRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                await _companyRepository.AddAsync(company);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cities"] = new SelectList(await _cityRepository.GetAllAsync(), "Id", "Name", company.CityId);
            return View(company);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewData["Cities"] = new SelectList(await _cityRepository.GetAllAsync(), "Id", "Name", company.CityId);
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _companyRepository.UpdateAsync(company);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cities"] = new SelectList(await _cityRepository.GetAllAsync(), "Id", "Name", company.CityId);
            return View(company);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company != null)
            {
                await _companyRepository.DeleteAsync(company);
            }
            return RedirectToAction(nameof(Index));
        }
    }

}
