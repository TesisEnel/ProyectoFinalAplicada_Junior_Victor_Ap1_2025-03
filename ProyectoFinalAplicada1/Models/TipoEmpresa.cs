using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class TipoEmpresa {
    [Key]
    public int TipoEmpresaId { get; set; }
    [Required(ErrorMessage = "La descripción es obligatoria")]
    public string Descripcion { get; set; } = string.Empty;
}


 


