using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[Table("permisos")]
public partial class Permiso
{
    [Key]
    [Column("id_permisos")]
    [StringLength(45)]
    public string IdPermisos { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(45)]
    public string Descripcion { get; set; } = null!;

    [ForeignKey("PermisosIdPermisos")]
    [InverseProperty("PermisosIdPermisos")]
    public virtual ICollection<Rol> RolIdRols { get; set; } = new List<Rol>();
}
