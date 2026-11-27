using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[Table("reserva")]
[Index("UsuarioIdUsuario", Name = "fk_Reserva_Usuario1_idx")]
public partial class Reserva
{
    [Key]
    [Column("id_reserva")]
    public int IdReserva { get; set; }

    [Column("fecha_Inicio", TypeName = "date")]
    public DateTime FechaInicio { get; set; }

    [Column("fecha_Fin", TypeName = "date")]
    public DateTime FechaFin { get; set; }

    [Column("precio_Final")]
    [Precision(10)]
    public decimal PrecioFinal { get; set; }

    [Column("Usuario_id_usuario")]
    public int UsuarioIdUsuario { get; set; }

    [Column("estado")]
    [StringLength(45)]
    public string Estado { get; set; } = null!;

    [Column("fecha_reserva", TypeName = "date")]
    public DateTime FechaReserva { get; set; }

    [Column("fecha_limite", TypeName = "date")]
    public DateTime FechaLimite { get; set; }

    [ForeignKey("UsuarioIdUsuario")]
    [InverseProperty("Reservas")]
    public virtual Usuario UsuarioIdUsuarioNavigation { get; set; } = null!;

    [ForeignKey("ReservaIdReserva")]
    [InverseProperty("ReservaIdReservas")]
    public virtual ICollection<Habitacion> HabitacionIdHabitacions { get; set; } = new List<Habitacion>();
}
