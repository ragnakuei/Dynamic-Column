using System;
using System.Collections;
using System.Collections.Generic;
using SharedLibrary.DTOs;

namespace DAL.IRepository
{
    public interface IColumnBlockRepository
    {
        IEnumerable<ColumnBlockDTO> Get();
        int Add(ColumnBlockDTO entityModel);
        ColumnBlockDTO Get(Guid id);
        void Remove(Guid id);
    }
}