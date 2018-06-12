using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Column")]
    public class Column
    {
        [Key]
        public Guid Id { get;            set; }
        public Guid ColumnBlockId { get; set; }
        [MaxLength(50)]
        public string Value { get; set; }
    }
}