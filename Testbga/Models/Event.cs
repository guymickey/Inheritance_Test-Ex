using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Testbga.Models;

[Table("Event")]
public partial class Event
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? IsFav { get; set; }

    [InverseProperty("Event")]
    public virtual ICollection<DependentPage> DependentPages { get; set; } = new List<DependentPage>();
}
