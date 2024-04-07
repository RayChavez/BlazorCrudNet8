using NeitekDTO;

namespace NeitekApp.Services
{
    public interface IMetaServices
    {
        Task<List<MetaDTO>> Lista();
        Task<MetaDTO> Buscar(int id);
        Task<int> Guardar(MetaDTO meta);
        Task<int> Editar(MetaDTO meta);
        Task<bool> Eliminar(int id);
    }
}
