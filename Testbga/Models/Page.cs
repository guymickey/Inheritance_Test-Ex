﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Testbga.Models;

[Table("Page")]
public partial class Page
{
    [Key]
    public int Id { get; set; }

    [InverseProperty("Page")]
    public virtual ICollection<DependentPage> DependentPages { get; set; } = new List<DependentPage>();

    [ForeignKey("Id")]
    [InverseProperty("Page")]
    public virtual Container IdNavigation { get; set; } = null!;
}
