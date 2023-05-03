using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace bsm.dal.Models;

[Index("Name", Name = "UQ__Skills__737584F600113B4A", IsUnique = true)]
public partial class Skill
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Skill")]
    public virtual ICollection<ServicesSkill> ServicesSkills { get; set; } = new List<ServicesSkill>();

    [InverseProperty("Skill")]
    public virtual ICollection<UsersSkill> UsersSkills { get; set; } = new List<UsersSkill>();
}
