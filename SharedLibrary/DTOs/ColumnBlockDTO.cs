using System;
using System.Collections.Generic;

namespace SharedLibrary.DTOs
{
    public class ColumnBlockDTO
    {
        public Guid            Id         { get; set; }
        public string          Name       { get; set; }
        public List<ColumnDTO> ColumnDTOs { get; set; }
    }
}
