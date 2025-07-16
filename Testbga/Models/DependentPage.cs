using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Testbga.Models;

[Table("DependentPage")]
public partial class DependentPage
{
    [Key]
    public int Id { get; set; }

    public int? EventId { get; set; }

    public int? PageId { get; set; }

    [ForeignKey("EventId")]
    [InverseProperty("DependentPages")]
    public virtual Event? Event { get; set; }

    [ForeignKey("PageId")]
    [InverseProperty("DependentPages")]
    public virtual Page? Page { get; set; }
}
