using System;
using System.Collections.Generic;
using SharedLibrary;
using SharedLibrary.DTOs;

namespace BLL.ILogics
{
    public interface IColumnBlockLogic
    {
        List<ColumnBlockDTO> Get();
        ColumnBlockDTO Get(Guid id);
        int Add(ColumnBlockDTO dto);
        void Remove(Guid id);
        void UpdateValue(List<ColumnBlockDTO> vModel);
    }
}