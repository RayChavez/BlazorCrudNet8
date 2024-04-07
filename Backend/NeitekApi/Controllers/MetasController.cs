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
    public class MetasController : ControllerBase
    {


        private readonly NeitekDBContext _dbContext;
        public readonly IMapper _mapper = null!;

        public MetasController(NeitekDBContext dbContext ,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var respApi = new ResponseAPI<List<MetaDTO>>();

            try
            {
                respApi.EsCorrecto = true;
                respApi.Valor = await _dbContext.Metas.Include(x=>x.Tareas).ProjectTo<MetaDTO>(_mapper.ConfigurationProvider).ToListAsync();
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
            var respApi = new ResponseAPI<MetaDTO>();
            try
            {
                respApi.EsCorrecto = true;
                respApi.Valor = await _dbContext.Metas.Include(x => x.Tareas).ProjectTo<MetaDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(n => n.Id == id);
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
        public async Task<IActionResult> Guardar(MetaDTO meta)
        {
            var respApi = new ResponseAPI<MetaDTO>();
            respApi.EsCorrecto = false;
            respApi.Mensaje = "No Guardado.";

            try
            {
                var nuevaMeta = new Metas
                {
                    Id = meta.Id,
                    Nombre = meta.Nombre,
                    Avance = meta.Avance,
                    FechaCreacion = meta.FechaCreacion
                };
                _dbContext.Metas.Add(nuevaMeta);
                await _dbContext.SaveChangesAsync();

                if (nuevaMeta.Id != 0)
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
        public async Task<IActionResult> Editar(MetaDTO meta, int id)
        {
            var respApi = new ResponseAPI<MetaDTO>();
            respApi.EsCorrecto = false;
            respApi.Mensaje = "No Guardado.";

            try
            {
                var _meta = await _dbContext.Metas.FirstOrDefaultAsync(n => n.Id == id);

                if(_meta != null ) { 
                    _meta.Nombre = meta.Nombre;
                    _meta.FechaCreacion = meta.FechaCreacion;
                

                    _dbContext.Metas.Update(_meta);
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
            var respApi = new ResponseAPI<MetaDTO>();
            respApi.EsCorrecto = true;
            respApi.Mensaje = "Se elimino correctamente la información.";

            try
            {
                var _meta = await _dbContext.Metas.FirstOrDefaultAsync(n => n.Id == id);

                if (_meta != null)
                {
                    _dbContext.Metas.Remove(_meta);
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
