using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalAplicada.Models;

public class Factura
{
    [Key]
    public int FacturaId { get; set; }

    [Required]
    public DateTime FechaEmision { get; set; } = DateTime.Now;

    
    [Required]
    public int PedidoId { get; set; }

    [ForeignKey("PedidoId")]
    public Pedido? Pedido { get; set; }

    
    [Required]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Cliente? Cliente { get; set; }

    [Required]
    public double MontoTotal { get; set; }

    
    public string? CodigoFactura { get; set; }
}
