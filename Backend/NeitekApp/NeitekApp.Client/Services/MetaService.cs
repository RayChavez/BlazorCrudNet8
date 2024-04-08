using NeitekDTO;
using System.Net.Http.Json;

namespace NeitekApp.Client.Services
{
    public class MetaService:IMetaService
    {
        private readonly HttpClient _http;

        public MetaService(HttpClient http)
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

        public async Task<string> Editar(MetaDTO meta)
        {
            var result = await _http.PutAsJsonAsync($"api/Metas/Editar/{meta.Id}", meta);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto.ToString();
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Metas/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.EsCorrecto)
                return true;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<string> Guardar(MetaDTO meta)
        {
            var result = await _http.PostAsJsonAsync("api/Metas/Guardar", meta);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto.ToString();
            else
                throw new Exception(response.Mensaje);
        }
    }
}
