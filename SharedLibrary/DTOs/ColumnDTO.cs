using System;

namespace SharedLibrary.DTOs
{
    public class ColumnDTO
    {
        public Guid          Id            { get; set; }
        public string        Value         { get; set; }
        public ColumnMetaDTO ColumnMetaDTO { get; set; }
    }
}
