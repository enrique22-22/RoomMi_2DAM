using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[Table("usuario")]
[Index("Email", Name = "email_UNIQUE", IsUnique = true)]
[Index("RolIdRol", Name = "fk_Usuario_Rol_idx")]
public partial class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("contraseña")]
    [StringLength(255)]
    public string Contraseña { get; set; } = null!;

    [Column("puntuacion")]
    public int? Puntuacion { get; set; }

    [Column("Rol_id_rol")]
    [StringLength(50)]
    public string RolIdRol { get; set; } = null!;

    [InverseProperty("UsuarioIdUsuarioNavigation")]
    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    [InverseProperty("UsuarioIdUsuarioNavigation")]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    [ForeignKey("RolIdRol")]
    [InverseProperty("Usuarios")]
    public virtual Rol RolIdRolNavigation { get; set; } = null!;

    [InverseProperty("UsuarioIdUsuarioNavigation")]
    public virtual ICollection<UsuarioChat> UsuarioChats { get; set; } = new List<UsuarioChat>();
}
