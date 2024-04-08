using NeitekDTO;

namespace NeitekApp.Client.Services
{
    public interface ITareaServices
    {
        Task<List<TareaDTO>> Lista();
        Task<TareaDTO> Buscar(int id);
        Task<string> Guardar(TareaDTO tarea);
        Task<string> Editar(TareaDTO tarea);
        Task<bool> Eliminar(int id);
    }
}
