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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog=BeautySalon; Encrypt=false; Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC07C50B834B");

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
            entity.HasKey(e => e.Id).HasName("PK__Services__3214EC07C7B744BB");

            entity.HasOne(d => d.Group).WithMany(p => p.Services)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Services__GroupI__412EB0B6");
        });

        modelBuilder.Entity<ServiceGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceG__3214EC073F7232D0");
        });

        modelBuilder.Entity<ServiceSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceS__3214EC0737E0984B");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceSkills).HasConstraintName("FK__ServiceSk__Servi__4CA06362");

            entity.HasOne(d => d.Skill).WithMany(p => p.ServiceSkills).HasConstraintName("FK__ServiceSk__Skill__4D94879B");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC07160C6266");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07227A901E");
        });

        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserSkil__3214EC0701FE3388");

            entity.HasOne(d => d.Skill).WithMany(p => p.UserSkills).HasConstraintName("FK__UserSkill__Skill__49C3F6B7");

            entity.HasOne(d => d.User).WithMany(p => p.UserSkills).HasConstraintName("FK__UserSkill__UserI__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
