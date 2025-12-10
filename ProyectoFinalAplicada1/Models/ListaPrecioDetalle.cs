using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class ListaPrecioDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int ListaPrecioId { get; set; } // FK

    [Required]
    public int ProductoId { get; set; }
    [ForeignKey("ProductoId")]
    public Producto? Producto { get; set; }

    [Required]
    public double PrecioMayorista { get; set; }
}
