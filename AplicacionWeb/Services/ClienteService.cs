using AplicacionWeb.Models;

namespace AplicacionWeb.Services
{
    public class ClienteService
    {
        private static List<ClienteModel> _clientes = new List<ClienteModel>();

        // Método para agregar un nuevo cliente
        public void AgregarCliente(ClienteModel cliente)
        {
            cliente.Id = _clientes.Count + 1;
            _clientes.Add(cliente);
        }

        // Método para obtener todos los clientes
        public List<ClienteModel> ObtenerTodos()
        {
            return _clientes;
        }

        // Método para obtener un cliente por ID
        public ClienteModel ObtenerPorId(int id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        // Método para actualizar un cliente
        public void ActualizarCliente(ClienteModel clienteActualizado)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == clienteActualizado.Id);
            if (cliente != null)
            {
                cliente.Nombre = clienteActualizado.Nombre;
                cliente.Apellido = clienteActualizado.Apellido;
                cliente.Edad = clienteActualizado.Edad;
                cliente.Direccion = clienteActualizado.Direccion;
                cliente.Telefono = clienteActualizado.Telefono;
                cliente.Genero = clienteActualizado.Genero;
            }
        }

        // Método para eliminar un cliente por ID
        public void EliminarCliente(int id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }
    }
}
