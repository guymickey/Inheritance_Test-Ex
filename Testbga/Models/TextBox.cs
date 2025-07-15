﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Testbga.Models;

[Table("TextBox")]
public partial class TextBox 
{
    [Key]
    public int Id { get; set; }

    public string? Value { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("TextBox")]
    public virtual Component IdNavigation { get; set; } = null!;
}
