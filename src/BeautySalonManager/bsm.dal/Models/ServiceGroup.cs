using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace bsm.dal.Models;

[Index("Name", Name = "UQ__ServiceG__737584F6EBEDBAAD", IsUnique = true)]
public partial class ServiceGroup
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Group")]
    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
