using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("ColumnValue")]
    public class ColumnValue
    {
        [Key]
        public Guid ColumnMetaId { get; set; }
        [MaxLength(50)]
        public string Value { get; set; }

        [ForeignKey("Id")]
        public ColumnMeta ColumnMeta { get; set; }
    }
}