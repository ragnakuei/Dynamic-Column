using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("ColumnBlock")]
    public class ColumnBlock
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Text { get; set; }
        [MaxLength(50)]
        public string ValueText { get; set; }
        public bool IsRequired { get;    set; }
    }
}