using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace bsm.dal.Models;

public partial class Appointment
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "date")]
    public DateTime Date { get; set; }

    public int ServiceId { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("AppointmentCustomers")]
    public virtual User Customer { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("AppointmentEmployees")]
    public virtual User Employee { get; set; } = null!;

    [ForeignKey("ServiceId")]
    [InverseProperty("Appointments")]
    public virtual Service Service { get; set; } = null!;
}
