using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class ZonaComercial
{
    [Key]
    public int ZonaId { get; set; }
    [Required]
    public string NombreZona { get; set; } = string.Empty;
}
