﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("ColumnMeta")]
    public class ColumnMeta
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Text { get; set; }

        [MaxLength(50)]
        public string ValueText { get; set; }

        public bool IsRequired    { get; set; }
        public byte OrderId       { get; set; }
        public Guid ColumnBlockId { get; set; }

        public ColumnBlock ColumnBlock { get; set; }
        public ColumnValue ColumnValue { get; set; }
    }
}
