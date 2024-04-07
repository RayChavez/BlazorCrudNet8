using NeitekDTO;

namespace NeitekApp.Services
{
    public interface ITareaServices
    {
        Task<List<TareaDTO>> Lista();
        Task<TareaDTO> Buscar(int id);
        Task<int> Guardar(TareaDTO tarea);
        Task<int> Editar(TareaDTO tarea);
        Task<bool> Eliminar(int id);
    }
}
