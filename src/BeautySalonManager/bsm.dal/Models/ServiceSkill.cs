using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace bsm.dal.Models;

public partial class ServiceSkill
{
    [Key]
    public int Id { get; set; }

    public int? ServiceId { get; set; }

    public int? SkillId { get; set; }

    [ForeignKey("ServiceId")]
    [InverseProperty("ServiceSkills")]
    public virtual Service? Service { get; set; }

    [ForeignKey("SkillId")]
    [InverseProperty("ServiceSkills")]
    public virtual Skill? Skill { get; set; }
}
