using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeitekApi.Models;
using NeitekDTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace NeitekApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly NeitekDBContext _dbContext;
        public readonly IMapper _mapper = null!;

        public TareasController(NeitekDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respApi = new ResponseAPI<List<TareaDTO>>();

            try
            {
                respApi.EsCorrecto = true;
                respApi.Valor = await _dbContext.Tareas.ProjectTo<TareaDTO>(_mapper.ConfigurationProvider).ToListAsync();
            }
            catch (Exception ex)
            {
                respApi.EsCorrecto = false;
                respApi.Mensaje = ex.Message;
            }
            return Ok(respApi);
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var respApi = new ResponseAPI<TareaDTO>();
            try
            {
                respApi.EsCorrecto = true;
                respApi.Valor = await _dbContext.Tareas.ProjectTo<TareaDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(n => n.Id == id);
            }
            catch (Exception ex)
            {
                respApi.EsCorrecto = false;
                respApi.Mensaje = ex.Message;
            }
            return Ok(respApi);


        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(TareaDTO tarea)
        {
            var respApi = new ResponseAPI<TareaDTO>();
            respApi.EsCorrecto = false;
            respApi.Mensaje = "No Guardado.";

            try
            {
                var nuevaTarea = new Tareas
                {
                    Id = tarea.Id,
                    Nombre = tarea.Nombre,
                    Estado = tarea.Estado,
                    FechaCreacion = tarea.FechaCreacion
                };
                _dbContext.Tareas.Add(nuevaTarea);
                await _dbContext.SaveChangesAsync();

                if (nuevaTarea.Id != 0)
                {
                    respApi.EsCorrecto = true;
                    respApi.Mensaje = string.Empty;
                }
            }
            catch (Exception ex)
            {
                respApi.Mensaje = ex.Message;
            }

            return Ok(respApi);
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(TareaDTO tarea, int id)
        {
            var respApi = new ResponseAPI<TareaDTO>();
            respApi.EsCorrecto = false;
            respApi.Mensaje = "No Guardado.";

            try
            {
                var _tarea = await _dbContext.Tareas.FirstOrDefaultAsync(n => n.Id == id);

                if (_tarea != null)
                {
                    _tarea.Nombre = tarea.Nombre;
                    _tarea.FechaCreacion = tarea.FechaCreacion;


                    _dbContext.Tareas.Update(_tarea);
                    await _dbContext.SaveChangesAsync();

                    respApi.EsCorrecto = true;
                    respApi.Mensaje = string.Empty;
                }
            }
            catch (Exception ex)
            {
                respApi.Mensaje = ex.Message;
            }
            return Ok(respApi);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respApi = new ResponseAPI<TareaDTO>();
            respApi.EsCorrecto = true;
            respApi.Mensaje = "Se elimino correctamente la información.";

            try
            {
                var _tarea = await _dbContext.Tareas.FirstOrDefaultAsync(n => n.Id == id);

                if (_tarea != null)
                {
                    _dbContext.Tareas.Remove(_tarea);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                respApi.EsCorrecto = false;
                respApi.Mensaje = ex.Message;
            }
            return Ok(respApi);
        }
    }
}
