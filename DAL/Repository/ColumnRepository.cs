using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.EF;
using DAL.IRepository;
using SharedLibrary.DTOs;

namespace DAL.Repository
{
    public class ColumnRepository : IColumnRepository, IDisposable
    {
        private readonly SqlServerDbContext _dbContext;

        public ColumnRepository(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ColumnDTO> Get()
        {
            var columns = _dbContext.ColumnBlocks.ToList();
            return null;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
