using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReservationSystem.Models;

public partial class RestaurantDbContext : DbContext
{
    public RestaurantDbContext()
    {
    }

    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OperatingHour> OperatingHours { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<RestaurantTable> RestaurantTables { get; set; }

    public virtual DbSet<SpecialOccasion> SpecialOccasions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Todor;Database=restaurant_db;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OperatingHour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__operatin__3213E83F37D940CD");

            entity.ToTable("operating_hours");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("day_of_week");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.TableId).HasColumnName("table_id");

            entity.HasOne(d => d.Table).WithMany(p => p.OperatingHours)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__operating__table__440B1D61");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reservat__3213E83F13B3F177");

            entity.ToTable("reservations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CanceledAt)
                .HasColumnType("datetime")
                .HasColumnName("canceled_at");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes");
            entity.Property(e => e.OperatingHoursId).HasColumnName("operating_hours_id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.ReservationDate).HasColumnName("reservation_date");
            entity.Property(e => e.TableId).HasColumnName("table_id");
            entity.Property(e => e.VerificationCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("verification_code");
            entity.Property(e => e.VerifiedByUser)
                .HasDefaultValue(false)
                .HasColumnName("verified_by_user");

            entity.HasOne(d => d.OperatingHours).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.OperatingHoursId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__reservati__opera__44FF419A");

            entity.HasOne(d => d.Table).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__reservati__table__45F365D3");
        });

        modelBuilder.Entity<RestaurantTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__restaura__3213E83FF90F882B");

            entity.ToTable("restaurant_tables");

            entity.HasIndex(e => e.Number, "UQ__restaura__FD291E416CFBB508").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<SpecialOccasion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__special___3213E83FF47B57AF");

            entity.ToTable("special_occasion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.TableId).HasColumnName("table_id");

            entity.HasOne(d => d.Table).WithMany(p => p.SpecialOccasions)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__special_o__table__46E78A0C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F0B40C695");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "UQ__users__F3DBC572174D544A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
