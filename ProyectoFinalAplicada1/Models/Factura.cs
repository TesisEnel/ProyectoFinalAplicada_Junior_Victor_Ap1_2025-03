using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ProyectoFinalAplicada.Models;

public class Factura
{
    [Key]
    public int FacturaId { get; set; }

    [Required(ErrorMessage = "La fecha de emisión es obligatoria.")]
    [DataType(DataType.DateTime)]
    public DateTime FechaEmision { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El ID del pedido es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe asociar la factura a un Pedido válido.")]
    public int PedidoId { get; set; }

    [ForeignKey("PedidoId")]
    public Pedido? Pedido { get; set; }

    [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe asociar la factura a un Cliente válido.")]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Cliente? Cliente { get; set; }

    [Required(ErrorMessage = "El monto total es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El Monto Total debe ser mayor que cero.")]
    [DataType(DataType.Currency)]
    public double MontoTotal { get; set; }

    [StringLength(50, ErrorMessage = "El código de factura no puede exceder los 50 caracteres.")]
    public string? CodigoFactura { get; set; }
}