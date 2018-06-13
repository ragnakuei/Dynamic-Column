using System;

namespace SharedLibrary.ViewModels
{
    public class ColumnBlockVMItem
    {
        public Guid   Id         { get; set; }
        public string Text       { get; set; }
        public string ValueText  { get; set; }
        public bool   IsRequired { get; set; }
    }
}