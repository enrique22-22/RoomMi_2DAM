using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[Table("tipo_habitacion")]
public partial class TipoHabitacion
{
    [Key]
    [Column("id_tipoHabitacion")]
    [StringLength(45)]
    public string IdTipoHabitacion { get; set; } = null!;

    [Column("tipo_habitacion")]
    [StringLength(45)]
    public string TipoHabitacion1 { get; set; } = null!;

    [InverseProperty("TipoHabitacionIdTipoHabitacionNavigation")]
    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();
}
