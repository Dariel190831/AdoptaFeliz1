using AdoptaFeliz.Data;
using AdoptaFeliz.Models;
using Microsoft.EntityFrameworkCore;


namespace AdoptaFeliz.Services
{
    public class RegistroService
    {
        private readonly DataContext _context;

        public RegistroService(DataContext context)
        {
            _context = context;
        }

        // Obtener todos los registros
        public async Task<List<Registro>> Obtenerregistro()
        {
            return await _context.registro.ToListAsync();
        }

        // Obtener un registro por ID
        public async Task<Registro?> ObtenerregistroPorId(Guid id)
        {
            return await _context.registro.FirstOrDefaultAsync(t => t.Id == id);
        }

        // Crear un nuevo registro
        public async Task<Registro> CrearRegistro(Registro registro)
        {
            registro.Id = Guid.NewGuid();
            registro.CreatedAt = DateTime.UtcNow;

            _context.registro.Add(registro);
            await _context.SaveChangesAsync();

            return registro;
        }

        // Actualizar un registro existente
        public async Task<bool> Actualizarregistro(Guid id, Registro registroActualizado)
        {
            var registro = await _context.registro.FindAsync(id);
            if (registro == null) return false;

            registro.Nombre = registroActualizado.Nombre;
            registro.Raza = registroActualizado.Raza;
            registro.Edad = registroActualizado.Edad;
            registro.Categoria = registroActualizado.Categoria;
        //  registro.CreatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar un registro
        public async Task<bool> EliminarRegistro(Guid id)
        {
            var registro = await _context.registro.FindAsync(id);
            if (registro == null) return false;

            _context.registro.Remove(registro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

