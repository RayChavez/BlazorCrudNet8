using AutoMapper;
using NeitekApi.Models;
using NeitekDTO;

namespace NeitekApi.Mapper
{
    public class Profiles:Profile
    {
        public Profiles() {
            CreateMap<Metas, MetaDTO>();
            CreateMap<Tareas,TareaDTO>();
        }
    }
}
