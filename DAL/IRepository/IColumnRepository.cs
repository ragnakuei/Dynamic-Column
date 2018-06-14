using System;
using System.Collections.Generic;
using SharedLibrary.DTOs;

namespace DAL.IRepository
{
    public interface IColumnRepository
    {
        IEnumerable<ColumnDTO> Get(Guid id);
    }
}