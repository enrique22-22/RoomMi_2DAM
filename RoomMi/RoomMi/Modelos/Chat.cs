using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[Table("chat")]
[Index("HabitacionIdHabitacion", Name = "fk_Chat_Habitacion1_idx")]
public partial class Chat
{
    [Key]
    [Column("id_chat")]
    public int IdChat { get; set; }

    [Column("Habitacion_id_habitacion")]
    public int HabitacionIdHabitacion { get; set; }

    [ForeignKey("HabitacionIdHabitacion")]
    [InverseProperty("Chats")]
    public virtual Habitacion HabitacionIdHabitacionNavigation { get; set; } = null!;

    [InverseProperty("ChatIdChatNavigation")]
    public virtual ICollection<UsuarioChat> UsuarioChats { get; set; } = new List<UsuarioChat>();
}
