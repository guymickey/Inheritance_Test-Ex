﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Testbga.Models;

[Table("Container")]
public partial class Container
{
    [Key]
    public int Id { get; set; }

    [InverseProperty("Container")]
    public virtual ICollection<Containing> Containings { get; set; } = new List<Containing>();

    [ForeignKey("Id")]
    [InverseProperty("Container")]
    public virtual Component IdNavigation { get; set; } = null!;

    [InverseProperty("IdNavigation")]
    public virtual Page? Page { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Section? Section { get; set; }
}
