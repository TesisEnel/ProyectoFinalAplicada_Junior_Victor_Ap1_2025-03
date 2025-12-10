using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class CondicionPago
{
    [Key]
    public int CondicionPagoId { get; set; }
    [Required]
    public string Descripcion { get; set; } = string.Empty; // Ej: Crédito 15 Días
    public int DiasCredito { get; set; } = 0;
}
