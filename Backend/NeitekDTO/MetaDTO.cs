using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeitekDTO
{
    public class MetaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Range(0, int.MaxValue,ErrorMessage = "El campo {0} es requerido.")]
        public int Avance { get; set; }

        ////public int MetasId { get; set; }
        public List<TareaDTO>? Tareas{ get; set; }
    }
}
