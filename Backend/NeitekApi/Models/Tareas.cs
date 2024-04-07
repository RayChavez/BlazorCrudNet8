namespace NeitekApi.Models
{
    public class Tareas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdMeta { get; set; }
        public bool Estado { get; set; }
        public virtual Metas IdMetaNavigation { get; set; } = null!;
    }
}
