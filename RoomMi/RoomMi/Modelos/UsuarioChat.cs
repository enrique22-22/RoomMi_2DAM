using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[PrimaryKey("UsuarioIdUsuario", "ChatIdChat")]
[Table("usuario_chat")]
[Index("ChatIdChat", Name = "fk_Usuario_has_Chat_Chat1_idx")]
[Index("UsuarioIdUsuario", Name = "fk_Usuario_has_Chat_Usuario1_idx")]
public partial class UsuarioChat
{
    [Key]
    [Column("Usuario_id_usuario")]
    public int UsuarioIdUsuario { get; set; }

    [Key]
    [Column("Chat_id_chat")]
    public int ChatIdChat { get; set; }

    [ForeignKey("ChatIdChat")]
    [InverseProperty("UsuarioChats")]
    public virtual Chat ChatIdChatNavigation { get; set; } = null!;

    [ForeignKey("UsuarioIdUsuario")]
    [InverseProperty("UsuarioChats")]
    public virtual Usuario UsuarioIdUsuarioNavigation { get; set; } = null!;

    [ForeignKey("UsuarioHasChatUsuarioIdUsuario, UsuarioHasChatChatIdChat")]
    [InverseProperty("UsuarioChats")]
    public virtual ICollection<Mensaje> MensajeIdMensajes { get; set; } = new List<Mensaje>();
}
