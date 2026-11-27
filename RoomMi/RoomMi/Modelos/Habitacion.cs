using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[Table("habitacion")]
[Index("TipoHabitacionIdTipoHabitacion", Name = "fk_Habitacion_Tipo_Habitacion1_idx")]
public partial class Habitacion
{
    [Key]
    [Column("id_habitacion")]
    public int IdHabitacion { get; set; }

    [Column("precio")]
    public double Precio { get; set; }

    [Column("descripcion")]
    [StringLength(200)]
    public string Descripcion { get; set; } = null!;

    [Column("fotos")]
    [StringLength(200)]
    public string? Fotos { get; set; }

    [Column("disponibilidad")]
    [StringLength(10)]
    public string Disponibilidad { get; set; } = null!;

    [Column("calle")]
    [StringLength(45)]
    public string Calle { get; set; } = null!;

    [Column("numero")]
    public int Numero { get; set; }

    [Column("poblacion")]
    [StringLength(45)]
    public string Poblacion { get; set; } = null!;

    [Column("Tipo_Habitacion_id_tipoHabitacion")]
    [StringLength(45)]
    public string TipoHabitacionIdTipoHabitacion { get; set; } = null!;

    [Column("longitud")]
    public double? Longitud { get; set; }

    [Column("latitud")]
    public double? Latitud { get; set; }

    [Column("cp")]
    public int Cp { get; set; }

    [Column("provincia")]
    [StringLength(45)]
    public string Provincia { get; set; } = null!;

    [Column("pais")]
    [StringLength(45)]
    public string Pais { get; set; } = null!;

    [InverseProperty("HabitacionIdHabitacionNavigation")]
    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    [InverseProperty("HabitacionIdHabitacionNavigation")]
    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    [InverseProperty("HabitacionIdHabitacionNavigation")]
    public virtual ICollection<Foto> FotosNavigation { get; set; } = new List<Foto>();

    [ForeignKey("TipoHabitacionIdTipoHabitacion")]
    [InverseProperty("Habitacions")]
    public virtual TipoHabitacion TipoHabitacionIdTipoHabitacionNavigation { get; set; } = null!;

    [ForeignKey("HabitacionIdHabitacion")]
    [InverseProperty("HabitacionIdHabitacions")]
    public virtual ICollection<Complemento> ComplementosIdComplementos { get; set; } = new List<Complemento>();

    [ForeignKey("HabitacionIdHabitacion")]
    [InverseProperty("HabitacionIdHabitacions")]
    public virtual ICollection<Reserva> ReservaIdReservas { get; set; } = new List<Reserva>();
}
