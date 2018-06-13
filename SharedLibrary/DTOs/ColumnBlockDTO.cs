using System;

namespace SharedLibrary.DTOs
{
    public class ColumnBlockDTO
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string ValueText { get; set; }
        public bool IsRequired { get; set; }
    }
}