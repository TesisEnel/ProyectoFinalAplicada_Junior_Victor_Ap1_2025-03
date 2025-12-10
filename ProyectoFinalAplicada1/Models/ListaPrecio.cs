using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class ListaPrecio
{
    [Key]
    public int ListaPrecioId { get; set; }

    [Required(ErrorMessage = "El nombre de la lista es obligatorio")]
    public string Nombre { get; set; } = string.Empty; // Ej: "Precios Mayoristas A"

    public bool Activa { get; set; } = true;

    // Relación con el detalle
    public ICollection<ListaPrecioDetalle> Detalles { get; set; } = new List<ListaPrecioDetalle>();
}
