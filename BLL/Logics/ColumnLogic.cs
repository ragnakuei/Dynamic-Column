using System.Collections.Generic;
using DAL.IRepository;
using SharedLibrary.DTOs;
using SharedLibrary.ViewModels;

namespace BLL.Logics
{
    public class ColumnLogic : IColumnLogic
    {
        private readonly IColumnRepository _repository;

        public ColumnLogic(IColumnRepository repository)
        {
            _repository = repository;
        }

        public ColumnViewModel Get()
        {
            var columns = _repository.Get();
            var result = ToColumnViewModel(columns);
            return result;
        }

        private ColumnViewModel ToColumnViewModel(List<ColumnDTO> columns)
        {
            throw new System.NotImplementedException();
        }
    }
}
