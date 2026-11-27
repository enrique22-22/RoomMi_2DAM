using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RoomMi.Modelos;

public partial class BdProyectoContext : DbContext
{
    public BdProyectoContext()
    {
    }

    public BdProyectoContext(DbContextOptions<BdProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Complemento> Complementos { get; set; }

    public virtual DbSet<Foto> Fotos { get; set; }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioChat> UsuarioChats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;database=bd_proyecto;user=root;password=mysql");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.IdChat).HasName("PRIMARY");

            entity.HasOne(d => d.HabitacionIdHabitacionNavigation).WithMany(p => p.Chats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Chat_Habitacion1");
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PRIMARY");

            entity.HasOne(d => d.HabitacionIdHabitacionNavigation).WithMany(p => p.Comentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Comentario_Habitacion1");

            entity.HasOne(d => d.UsuarioIdUsuarioNavigation).WithMany(p => p.Comentarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Comentario_Usuario1");
        });

        modelBuilder.Entity<Complemento>(entity =>
        {
            entity.HasKey(e => e.IdComplementos).HasName("PRIMARY");

            entity.HasMany(d => d.HabitacionIdHabitacions).WithMany(p => p.ComplementosIdComplementos)
                .UsingEntity<Dictionary<string, object>>(
                    "ComplementosHasHabitacion",
                    r => r.HasOne<Habitacion>().WithMany()
                        .HasForeignKey("HabitacionIdHabitacion")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Complementos_has_Habitacion_Habitacion1"),
                    l => l.HasOne<Complemento>().WithMany()
                        .HasForeignKey("ComplementosIdComplementos")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Complementos_has_Habitacion_Complementos1"),
                    j =>
                    {
                        j.HasKey("ComplementosIdComplementos", "HabitacionIdHabitacion").HasName("PRIMARY");
                        j.ToTable("complementos_has_habitacion");
                        j.HasIndex(new[] { "ComplementosIdComplementos" }, "fk_Complementos_has_Habitacion_Complementos1_idx");
                        j.HasIndex(new[] { "HabitacionIdHabitacion" }, "fk_Complementos_has_Habitacion_Habitacion1_idx");
                        j.IndexerProperty<int>("ComplementosIdComplementos").HasColumnName("Complementos_idComplementos");
                        j.IndexerProperty<int>("HabitacionIdHabitacion").HasColumnName("Habitacion_id_habitacion");
                    });
        });

        modelBuilder.Entity<Foto>(entity =>
        {
            entity.HasKey(e => e.IdFotos).HasName("PRIMARY");

            entity.HasOne(d => d.HabitacionIdHabitacionNavigation).WithMany(p => p.FotosNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Fotos_Habitacion1");
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PRIMARY");

            entity.HasOne(d => d.TipoHabitacionIdTipoHabitacionNavigation).WithMany(p => p.Habitacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Habitacion_Tipo_Habitacion1");
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.IdMensaje).HasName("PRIMARY");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermisos).HasName("PRIMARY");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PRIMARY");

            entity.HasOne(d => d.UsuarioIdUsuarioNavigation).WithMany(p => p.Reservas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reserva_Usuario1");

            entity.HasMany(d => d.HabitacionIdHabitacions).WithMany(p => p.ReservaIdReservas)
                .UsingEntity<Dictionary<string, object>>(
                    "ReservaHasHabitacion",
                    r => r.HasOne<Habitacion>().WithMany()
                        .HasForeignKey("HabitacionIdHabitacion")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Reserva_has_Habitacion_Habitacion1"),
                    l => l.HasOne<Reserva>().WithMany()
                        .HasForeignKey("ReservaIdReserva")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Reserva_has_Habitacion_Reserva1"),
                    j =>
                    {
                        j.HasKey("ReservaIdReserva", "HabitacionIdHabitacion").HasName("PRIMARY");
                        j.ToTable("reserva_has_habitacion");
                        j.HasIndex(new[] { "HabitacionIdHabitacion" }, "fk_Reserva_has_Habitacion_Habitacion1_idx");
                        j.HasIndex(new[] { "ReservaIdReserva" }, "fk_Reserva_has_Habitacion_Reserva1_idx");
                        j.IndexerProperty<int>("ReservaIdReserva")
                            .ValueGeneratedOnAdd()
                            .HasColumnName("Reserva_id_reserva");
                        j.IndexerProperty<int>("HabitacionIdHabitacion").HasColumnName("Habitacion_id_habitacion");
                    });
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.HasMany(d => d.PermisosIdPermisos).WithMany(p => p.RolIdRols)
                .UsingEntity<Dictionary<string, object>>(
                    "Tiene",
                    r => r.HasOne<Permiso>().WithMany()
                        .HasForeignKey("PermisosIdPermisos")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Tiene_Permisos1"),
                    l => l.HasOne<Rol>().WithMany()
                        .HasForeignKey("RolIdRol")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Tiene_Rol1"),
                    j =>
                    {
                        j.HasKey("RolIdRol", "PermisosIdPermisos").HasName("PRIMARY");
                        j.ToTable("tiene");
                        j.HasIndex(new[] { "PermisosIdPermisos" }, "fk_Tiene_Permisos1_idx");
                        j.HasIndex(new[] { "RolIdRol" }, "fk_Tiene_Rol1_idx");
                        j.IndexerProperty<string>("RolIdRol")
                            .HasMaxLength(50)
                            .HasColumnName("Rol_id_rol");
                        j.IndexerProperty<string>("PermisosIdPermisos")
                            .HasMaxLength(45)
                            .HasColumnName("Permisos_id_permisos");
                    });
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoHabitacion).HasName("PRIMARY");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.HasOne(d => d.RolIdRolNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuario_Rol");
        });

        modelBuilder.Entity<UsuarioChat>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioIdUsuario, e.ChatIdChat }).HasName("PRIMARY");

            entity.HasOne(d => d.ChatIdChatNavigation).WithMany(p => p.UsuarioChats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuario_has_Chat_Chat1");

            entity.HasOne(d => d.UsuarioIdUsuarioNavigation).WithMany(p => p.UsuarioChats)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Usuario_has_Chat_Usuario1");

            entity.HasMany(d => d.MensajeIdMensajes).WithMany(p => p.UsuarioChats)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioChatMensaje",
                    r => r.HasOne<Mensaje>().WithMany()
                        .HasForeignKey("MensajeIdMensaje")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Usuario_has_Chat_has_Mensaje_Mensaje1"),
                    l => l.HasOne<UsuarioChat>().WithMany()
                        .HasForeignKey("UsuarioHasChatUsuarioIdUsuario", "UsuarioHasChatChatIdChat")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Usuario_has_Chat_has_Mensaje_Usuario_has_Chat1"),
                    j =>
                    {
                        j.HasKey("UsuarioHasChatUsuarioIdUsuario", "UsuarioHasChatChatIdChat", "MensajeIdMensaje").HasName("PRIMARY");
                        j.ToTable("usuario_chat_mensaje");
                        j.HasIndex(new[] { "MensajeIdMensaje" }, "fk_Usuario_has_Chat_has_Mensaje_Mensaje1_idx");
                        j.HasIndex(new[] { "UsuarioHasChatUsuarioIdUsuario", "UsuarioHasChatChatIdChat" }, "fk_Usuario_has_Chat_has_Mensaje_Usuario_has_Chat1_idx");
                        j.IndexerProperty<int>("UsuarioHasChatUsuarioIdUsuario").HasColumnName("Usuario_has_Chat_Usuario_id_usuario");
                        j.IndexerProperty<int>("UsuarioHasChatChatIdChat").HasColumnName("Usuario_has_Chat_Chat_id_chat");
                        j.IndexerProperty<int>("MensajeIdMensaje").HasColumnName("Mensaje_id_mensaje");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
