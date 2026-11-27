using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[Table("rol")]
public partial class Rol
{
    [Key]
    [Column("id_rol")]
    [StringLength(50)]
    public string IdRol { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(45)]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("RolIdRolNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    [ForeignKey("RolIdRol")]
    [InverseProperty("RolIdRols")]
    public virtual ICollection<Permiso> PermisosIdPermisos { get; set; } = new List<Permiso>();
}
