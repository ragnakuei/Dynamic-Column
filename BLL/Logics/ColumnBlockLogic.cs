using System.Collections.Generic;
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

        public ColumnBlockViewModel Get()
        {
            var columnBlocks = _repository.Get();
            var result = ToColumnBlockViewModel(columnBlocks);
            return result;
        }

        private ColumnBlockViewModel ToColumnBlockViewModel(IEnumerable<ColumnBlockDTO> columnBlocks)
        {
            throw new System.NotImplementedException();
        }
    }
}