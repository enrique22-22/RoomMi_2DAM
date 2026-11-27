using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[Table("mensaje")]
public partial class Mensaje
{
    [Key]
    [Column("id_mensaje")]
    public int IdMensaje { get; set; }

    [Column("contenido")]
    [StringLength(200)]
    public string Contenido { get; set; } = null!;

    [Column("fecha", TypeName = "date")]
    public DateTime Fecha { get; set; }

    [Column("hora", TypeName = "time")]
    public TimeSpan? Hora { get; set; }

    [ForeignKey("MensajeIdMensaje")]
    [InverseProperty("MensajeIdMensajes")]
    public virtual ICollection<UsuarioChat> UsuarioChats { get; set; } = new List<UsuarioChat>();
}
