using System;
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

        public int Add(ColumnBlockVMItem vModel)
        {
            var dto = ToColumnBlockDTO(vModel);
            var result = _repository.Add(dto);
            return result;
        }

        public ColumnBlockVMItem Get(Guid id)
        {
            var dto = _repository.Get(id);
            var result = ToColumnBlockVMItem(dto);
            return result;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        private ColumnBlockVM ToColumnBlockViewModel(IEnumerable<ColumnBlockDTO> columnBlocks)
        {
            var result = new ColumnBlockVM();

            result.ColumnBlockItems = columnBlocks.Select(cb => ToColumnBlockVMItem(cb))
                                                  .ToList();
            return result;
        }

        private ColumnBlockDTO ToColumnBlockDTO(ColumnBlockVMItem vModel)
        {
            var result = new ColumnBlockDTO 
                         {
                                 Id         = Guid.NewGuid(),
                                 Text       = vModel.Text,
                                 ValueText  = vModel.ValueText,
                                 IsRequired = vModel.IsRequired,
                         };
            return result;
        }

        private ColumnBlockVMItem ToColumnBlockVMItem(ColumnBlockDTO dto)
        {
            return new ColumnBlockVMItem
                   {
                           Id         = dto.Id,
                           Text       = dto.Text,
                           ValueText  = dto.ValueText,
                           IsRequired = dto.IsRequired
                   };
        }
    }
}