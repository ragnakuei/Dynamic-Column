using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("ColumnValue")]
    public class ColumnValue
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Value { get; set; }

        public Guid ColumnMetaId { get; set; }

        public ColumnMeta ColumnMeta { get; set; }
    }
}
