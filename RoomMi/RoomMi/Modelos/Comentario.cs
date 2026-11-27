using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[Table("comentario")]
[Index("HabitacionIdHabitacion", Name = "fk_Comentario_Habitacion1_idx")]
[Index("UsuarioIdUsuario", Name = "fk_Comentario_Usuario1_idx")]
public partial class Comentario
{
    [Key]
    [Column("id_comentario")]
    [StringLength(45)]
    public string IdComentario { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(200)]
    public string Descripcion { get; set; } = null!;

    [Column("valoracion")]
    public int Valoracion { get; set; }

    [Column("Habitacion_id_habitacion")]
    public int HabitacionIdHabitacion { get; set; }

    [Column("Usuario_id_usuario")]
    public int UsuarioIdUsuario { get; set; }

    [ForeignKey("HabitacionIdHabitacion")]
    [InverseProperty("Comentarios")]
    public virtual Habitacion HabitacionIdHabitacionNavigation { get; set; } = null!;

    [ForeignKey("UsuarioIdUsuario")]
    [InverseProperty("Comentarios")]
    public virtual Usuario UsuarioIdUsuarioNavigation { get; set; } = null!;
}
