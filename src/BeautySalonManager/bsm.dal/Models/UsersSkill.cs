using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace bsm.dal.Models;

public partial class UsersSkill
{
    [Key]
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? SkillId { get; set; }

    [ForeignKey("SkillId")]
    [InverseProperty("UsersSkills")]
    public virtual Skill? Skill { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UsersSkills")]
    public virtual User? User { get; set; }
}
