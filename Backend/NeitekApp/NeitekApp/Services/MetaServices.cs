using NeitekDTO;

namespace NeitekApp.Services
{
    public class MetaServices :IMetaServices
    {
        private readonly HttpClient _http;

        public MetaServices(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MetaDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<MetaDTO>>>("api/Metas/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<MetaDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<MetaDTO>>($"api/Metas/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Editar(MetaDTO meta)
        {
            var result = await _http.PutAsJsonAsync($"api/Metas/Editar/{meta.Id}", meta);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Metas/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Guardar(MetaDTO meta)
        {
            var result = await _http.PostAsJsonAsync("api/Metas/Guardar", meta);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

      
    }
}
