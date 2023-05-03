using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace bsm.dal.Models;

[Index("Name", Name = "UQ__UserType__737584F6B1080A5B", IsUnique = true)]
public partial class UserType
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Type")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
