using ClientDirectory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClientDirectory.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public HomeController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IActionResult> Index()
        {
            // Загружаем список клиентов
            var clients = await _clientRepository.GetAllAsync();

            // Передаем список клиентов в представление
            return View(clients);
        }
    }
}
