using System.ComponentModel.DataAnnotations;

namespace registrotecnico.Models
{
    public class tecnicos
    {
        [Key]
        public int TecnicosId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string? nombres { get; set; }

        
        public float sueldohoras { get; set; }

       


    }
}
