﻿using NeitekDTO;
using System.Net.Http.Json;

namespace NeitekApp.Client.Services
{
    public class TareaServices :ITareaServices
    {
        private readonly HttpClient _http;

        public TareaServices(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TareaDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TareaDTO>>>("api/Tareas/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<TareaDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<TareaDTO>>($"api/Tareas/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<string> Editar(TareaDTO tarea)
        {
            var result = await _http.PutAsJsonAsync($"api/Tareas/Editar/{tarea.Id}", tarea);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.EsCorrecto)
                return response.Valor.ToString();
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Tareas/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.EsCorrecto)
                return true;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<string> Guardar(TareaDTO meta)
        {
            var result = await _http.PostAsJsonAsync("api/Tareas/Guardar", meta);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<string>>();

            if (response!.EsCorrecto)
                return response.Valor.ToString();
            else
                throw new Exception(response.Mensaje);
        }
    }
}
