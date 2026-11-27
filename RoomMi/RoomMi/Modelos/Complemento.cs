using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

[Table("complementos")]
public partial class Complemento
{
    [Key]
    [Column("id_Complementos")]
    public int IdComplementos { get; set; }

    [Column("nombre")]
    [StringLength(45)]
    public string Nombre { get; set; } = null!;

    [Column("descripcion")]
    [StringLength(200)]
    public string Descripcion { get; set; } = null!;

    [Column("precio")]
    public double Precio { get; set; }

    [ForeignKey("ComplementosIdComplementos")]
    [InverseProperty("ComplementosIdComplementos")]
    public virtual ICollection<Habitacion> HabitacionIdHabitacions { get; set; } = new List<Habitacion>();
}
