using Microsoft.AspNetCore.Mvc;
using AplicacionWeb.Models;
using AplicacionWeb.Services;

namespace AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClienteService _clienteService;

        public HomeController()
        {
            _clienteService = new ClienteService();
        }

        public IActionResult Index()
        {
            var clientes = _clienteService.ObtenerTodos();
            return View(clientes);
        }

        // Redirige a Privacy.cshtml con datos para agregar o editar un cliente
        public IActionResult Privacy(int? id)
        {
            ClienteModel cliente = id.HasValue
                ? _clienteService.ObtenerPorId(id.Value)
                : new ClienteModel(); // Si no hay ID, se crea un cliente vacío

            return View(cliente);
        }

        // Guardar cliente (nuevo o editado)
        [HttpPost]
        public IActionResult Guardar(ClienteModel cliente)
        {
            if (cliente.Id == 0)
            {
                _clienteService.AgregarCliente(cliente);
            }
            else
            {
                _clienteService.ActualizarCliente(cliente);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            _clienteService.EliminarCliente(id);
            return RedirectToAction("Index");
        }
    }
}
