using System.Collections.Generic;
using SharedLibrary.DTOs;

namespace DAL.IRepository
{
    public interface IColumnRepository
    {
        List<ColumnDTO> Get();
    }
}