using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using bsm.dal.Models;

namespace bsm.dal.Data;

public partial class BeautySalonContext : DbContext
{
    public BeautySalonContext()
    {
    }

    public BeautySalonContext(DbContextOptions<BeautySalonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServicesSkill> ServicesSkills { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<UsersSkill> UsersSkills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog = BeautySalon; Encrypt = false; Trusted_Connection = true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC07EACB56B8");

            entity.HasOne(d => d.Customer).WithMany(p => p.AppointmentCustomers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Custo__44FF419A");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Emplo__45F365D3");

            entity.HasOne(d => d.Service).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Servi__440B1D61");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Services__3214EC079D15B9FA");
        });

        modelBuilder.Entity<ServicesSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Services__3214EC07C519B081");

            entity.HasOne(d => d.Service).WithMany(p => p.ServicesSkills).HasConstraintName("FK__ServicesS__Servi__4CA06362");

            entity.HasOne(d => d.Skill).WithMany(p => p.ServicesSkills).HasConstraintName("FK__ServicesS__Skill__4D94879B");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC07F6AF1E98");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07AEF7072F");

            entity.HasOne(d => d.Type).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__TypeId__3E52440B");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserType__3214EC07955B9B6B");
        });

        modelBuilder.Entity<UsersSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UsersSki__3214EC077D713C33");

            entity.HasOne(d => d.Skill).WithMany(p => p.UsersSkills).HasConstraintName("FK__UsersSkil__Skill__49C3F6B7");

            entity.HasOne(d => d.User).WithMany(p => p.UsersSkills).HasConstraintName("FK__UsersSkil__UserI__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
