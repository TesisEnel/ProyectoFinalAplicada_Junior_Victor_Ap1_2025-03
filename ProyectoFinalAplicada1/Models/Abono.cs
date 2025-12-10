using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoFinalAplicada.Models;

namespace ProyectoFinalAplicada.Models;


public class Abono
{
    [Key]
    public int AbonoId { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un cliente")]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Cliente? Cliente { get; set; }

    [Required(ErrorMessage = "El monto es obligatorio")]
    [Range(0.01, 1000000, ErrorMessage = "El monto debe ser mayor a 0")]
    public double Monto { get; set; }

    public string Observacion { get; set; } = string.Empty;

    public DateTime Fecha { get; set; } = DateTime.Now;
}