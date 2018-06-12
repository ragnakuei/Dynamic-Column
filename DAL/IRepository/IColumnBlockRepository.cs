using System.Collections;
using System.Collections.Generic;
using SharedLibrary.DTOs;

namespace DAL.IRepository
{
    public interface IColumnBlockRepository
    {
        IEnumerable<ColumnBlockDTO> Get();
    }
}