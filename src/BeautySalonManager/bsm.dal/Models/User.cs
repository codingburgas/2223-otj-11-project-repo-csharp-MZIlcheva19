using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace bsm.dal.Models;

[Index("Username", Name = "UQ__Users__536C85E4F5D02769", IsUnique = true)]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(64)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Salt { get; set; } = null!;

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(25)]
    [Unicode(false)]
    public string Phone { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public int? TypeId { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Appointment> AppointmentCustomers { get; set; } = new List<Appointment>();

    [InverseProperty("Employee")]
    public virtual ICollection<Appointment> AppointmentEmployees { get; set; } = new List<Appointment>();

    [InverseProperty("User")]
    public virtual ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
}
