using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace bsm.dal.Models;

[Index("Name", Name = "UQ__Skills__737584F62818E8A5", IsUnique = true)]
public partial class Skill
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Skill")]
    public virtual ICollection<ServiceSkill> ServiceSkills { get; set; } = new List<ServiceSkill>();

    [InverseProperty("Skill")]
    public virtual ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
}
