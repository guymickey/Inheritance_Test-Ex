﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Testbga.Models;

[Table("Banner")]
public partial class Banner
{
    [Key]
    public int Id { get; set; }

    public string? Value { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Banner")]
    public virtual Component IdNavigation { get; set; } = null!;
}
