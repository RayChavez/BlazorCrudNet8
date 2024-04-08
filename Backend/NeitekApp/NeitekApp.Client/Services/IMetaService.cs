using NeitekDTO;

namespace NeitekApp.Client.Services
{
    public interface IMetaService
    {
        Task<List<MetaDTO>> Lista();
        Task<MetaDTO> Buscar(int id);
        Task<string> Guardar(MetaDTO meta);
        Task<string> Editar(MetaDTO meta);
        Task<bool> Eliminar(int id);
    }
}
