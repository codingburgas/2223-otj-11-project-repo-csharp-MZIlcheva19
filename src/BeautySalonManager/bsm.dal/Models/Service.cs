using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace bsm.dal.Models;

[Index("Name", Name = "UQ__Services__737584F67486421B", IsUnique = true)]
public partial class Service
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(15, 4)")]
    public decimal Price { get; set; }

    public TimeSpan Time { get; set; }

    public int GroupId { get; set; }

    [InverseProperty("Service")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [ForeignKey("GroupId")]
    [InverseProperty("Services")]
    public virtual ServiceGroup Group { get; set; } = null!;

    [InverseProperty("Service")]
    public virtual ICollection<ServiceSkill> ServiceSkills { get; set; } = new List<ServiceSkill>();
}
