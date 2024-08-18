using ClientDirectory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClientDirectory.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICompanyRepository _companyRepository;

        public ClientsController(IClientRepository clientRepository, ICityRepository cityRepository, ICompanyRepository companyRepository)
        {
            _clientRepository = clientRepository;
            _cityRepository = cityRepository;
            _companyRepository = companyRepository;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _clientRepository.GetClientsWithDetailsAsync();            
            ViewBag.Cities = new SelectList(await _cityRepository.GetAllAsync(), "Id", "Name");
            ViewBag.Companies = new SelectList(await _companyRepository.GetAllAsync(), "Id", "Name");
            return View(clients);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Cities"] = new SelectList(await _cityRepository.GetAllAsync(), "Id", "Name");
            ViewData["Companies"] = new SelectList(await _companyRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientRepository.AddAsync(client);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cities"] = new SelectList(await _cityRepository.GetAllAsync(), "Id", "Name", client.CityId);
            ViewData["Companies"] = new SelectList(await _companyRepository.GetAllAsync(), "Id", "Name", client.CompanyId);
            return View(client);
        }

        // Add Edit, Delete, Details actions similarly...
    }
}
