using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLibrary.DTOs;

namespace DAL.Models
{
[Table("ColumnBlock")]
public class ColumnBlock
{
    public ColumnBlock()
    {
        this.ColumnMetas = new List<ColumnMeta>();
    }

    public Guid Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }

    public List<ColumnMeta> ColumnMetas { get; set; }
}
}