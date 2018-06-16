using System;
using System.Collections.Generic;
using System.Linq;
using BLL.ILogics;
using DAL.IRepository;
using SharedLibrary;
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
            var result = _repository.Get().ToList();
            return result;
        }

        public int Add(ColumnBlockDTO dto)
        {
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