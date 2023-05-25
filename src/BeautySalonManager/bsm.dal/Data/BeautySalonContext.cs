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

    public virtual DbSet<ServiceGroup> ServiceGroups { get; set; }

    public virtual DbSet<ServiceSkill> ServiceSkills { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSkill> UserSkills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog=BeautySalon; Encrypt=false; Trusted_Connection=true;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC077DFC0E7E");

            entity.HasOne(d => d.Customer).WithMany(p => p.AppointmentCustomers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Custo__6383C8BA");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentEmployees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Emplo__6477ECF3");

            entity.HasOne(d => d.Service).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Servi__628FA481");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Services__3214EC071F8B52C8");

            entity.HasOne(d => d.Group).WithMany(p => p.Services)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Services__GroupI__534D60F1");
        });

        modelBuilder.Entity<ServiceGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceG__3214EC071ECCF3A3");
        });

        modelBuilder.Entity<ServiceSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceS__3214EC07799A1232");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceSkills).HasConstraintName("FK__ServiceSk__Servi__5EBF139D");

            entity.HasOne(d => d.Skill).WithMany(p => p.ServiceSkills).HasConstraintName("FK__ServiceSk__Skill__5FB337D6");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC0700C4CC98");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC078CE53AC7");
        });

        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserSkil__3214EC07E3BFED68");

            entity.HasOne(d => d.Skill).WithMany(p => p.UserSkills).HasConstraintName("FK__UserSkill__Skill__5BE2A6F2");

            entity.HasOne(d => d.User).WithMany(p => p.UserSkills).HasConstraintName("FK__UserSkill__UserI__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
