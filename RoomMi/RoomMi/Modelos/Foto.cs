using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[Table("fotos")]
[Index("HabitacionIdHabitacion", Name = "fk_Fotos_Habitacion1_idx")]
public partial class Foto
{
    [Key]
    [Column("id_Fotos")]
    public int IdFotos { get; set; }

    [Column("fotos")]
    [StringLength(200)]
    public string? Fotos { get; set; }

    [Column("Habitacion_id_habitacion")]
    public int HabitacionIdHabitacion { get; set; }

    [ForeignKey("HabitacionIdHabitacion")]
    [InverseProperty("FotosNavigation")]
    public virtual Habitacion HabitacionIdHabitacionNavigation { get; set; } = null!;
}
