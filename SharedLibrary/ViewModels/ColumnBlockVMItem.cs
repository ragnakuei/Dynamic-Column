using System;
using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.ViewModels
{
    public class ColumnBlockVMItem
    {
        public Guid   Id         { get; set; }

        [Required]
        public string Text       { get; set; }

        public string ValueText  { get; set; }
        public bool   IsRequired { get; set; }
    }
}