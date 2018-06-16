using System;
using System.Collections.Generic;
using System.Linq;
using BLL.ILogics;
using DAL.IRepository;
using SharedLibrary.DTOs;

namespace BLL.Logics
{
    public class ColumnBlockLogic : IColumnBlockLogic
    {
        private readonly IColumnBlockRepository _repository;

        public ColumnBlockLogic(IColumnBlockRepository repository)
        {
            _repository = repository;
        }

        public List<ColumnBlockDTO> Get()
        {
            var result = _repository.Get()
                                    .ToList();

            //TODO: 應該有更好的做法
            foreach ( var columnBlockDto in result )
                columnBlockDto.ColumnDTOs = columnBlockDto.ColumnDTOs
                                                          .OrderBy(c => c.ColumnMetaDTO.OrderId)
                                                          .ToList();
            return result;
        }

        public int Add(ColumnBlockDTO dto)
        {
            for ( byte i = 0; i < dto.ColumnDTOs.Count; i++ )
                dto.ColumnDTOs[i]
                   .ColumnMetaDTO.OrderId = i;
            var result = _repository.Add(dto);
            return result;
        }

        public ColumnBlockDTO Get(Guid id)
        {
            var result = _repository.Get(id);
            return result;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public void UpdateValue(List<ColumnBlockDTO> vModel)
        {
            throw new NotImplementedException();
        }
    }
}
