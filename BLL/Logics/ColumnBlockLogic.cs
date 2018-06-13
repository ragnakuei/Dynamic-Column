using System.Collections.Generic;
using System.Linq;
using BLL.ILogics;
using DAL.IRepository;
using SharedLibrary.DTOs;
using SharedLibrary.ViewModels;

namespace BLL.Logics
{
    public class ColumnBlockLogic : IColumnBlockLogic
    {
        private readonly IColumnBlockRepository _repository;

        public ColumnBlockLogic(IColumnBlockRepository repository)
        {
            _repository = repository;
        }

        public ColumnBlockVM Get()
        {
            var columnBlocks = _repository.Get();
            var result = ToColumnBlockViewModel(columnBlocks);
            return result;
        }

        private ColumnBlockVM ToColumnBlockViewModel(IEnumerable<ColumnBlockDTO> columnBlocks)
        {
            var result = new ColumnBlockVM();

            result.ColumnBlockItems = columnBlocks.Select(cb => new ColumnBlockVMItem
                                                                {
                                                                        Id         = cb.Id,
                                                                        Text       = cb.Text,
                                                                        ValueText  = cb.ValueText,
                                                                        IsRequired = cb.IsRequired
                                                                })
                                                  .ToList();
            return result;
        }
    }
}