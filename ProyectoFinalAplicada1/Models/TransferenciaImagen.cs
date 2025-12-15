using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada.Models;

public class TransferenciaImagen
{
    [Key]
    public int TransferenciaImagenId { get; set; }

    [Required]
    public int TransferenciaId { get; set; }

    [Required]
    public string RutaImagen { get; set; }
}
