using System;
using SharedLibrary.ViewModels;

namespace BLL.ILogics
{
    public interface IColumnBlockLogic
    {
        ColumnBlockVM Get();
        int Add(ColumnBlockVMItem vModel);
        void Remove(Guid id);
        ColumnBlockVMItem Get(Guid id);
    }
}