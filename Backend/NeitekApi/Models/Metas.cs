using NeitekDTO;

namespace NeitekApi.Models
{
    public class Metas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Avance { get; set; }

        public virtual ICollection<Tareas> Tareas { get; } = new List<Tareas>();
    }
}
