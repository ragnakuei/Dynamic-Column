using System;
using System.Collections.Generic;
using SharedLibrary.DTOs;

namespace DAL.IRepository
{
    public interface IColumnBlockRepository
    {
        IEnumerable<ColumnBlockDTO> Get();
        ColumnBlockDTO              Get(Guid            id);
        int                         Add(ColumnBlockDTO  entityModel);
        void                        Remove(Guid         id);
        void UpdateValue(List<ColumnBlockDTO> vModel);
    }
}
