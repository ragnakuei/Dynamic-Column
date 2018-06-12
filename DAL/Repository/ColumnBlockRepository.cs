using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.IRepository;
using DAL.Models;
using SharedLibrary.DTOs;

namespace DAL.Repository
{
    public class ColumnBlockRepository : IColumnBlockRepository, IDisposable
    {
        private readonly SqlServerDbContext _dbContext;

        public ColumnBlockRepository(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ColumnBlockDTO> Get()
        {
            var columnBlocks = _dbContext.ColumnBlocks
                                         .AsEnumerable()
                                         .Select(c => ToColumnBlockDTO(c));
            return columnBlocks;
        }

        private ColumnBlockDTO ToColumnBlockDTO(ColumnBlock columnBlock)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}