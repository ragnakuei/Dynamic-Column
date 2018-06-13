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

        public ColumnBlockDTO Get(Guid id)
        {
            var columnBlock = _dbContext.ColumnBlocks
                                        .Find(id);
            var dto = ToColumnBlockDTO(columnBlock);
            return dto;
        }

        public void Remove(Guid id)
        {
            try
            {
                var entity = _dbContext.ColumnBlocks.Find(id);
                _dbContext.ColumnBlocks.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch ( Exception e )
            {
            }
        }

        public int Add(ColumnBlockDTO dto)
        {
            var entityModel = ToColumnBlock(dto);
            _dbContext.ColumnBlocks.Add(entityModel);
            var result = _dbContext.SaveChanges();
            return result;
        }

        private ColumnBlock ToColumnBlock(ColumnBlockDTO dto)
        {
            var result = new ColumnBlock
                         {
                                 Id         = dto.Id,
                                 Text       = dto.Text,
                                 ValueText  = dto.ValueText,
                                 IsRequired = dto.IsRequired
                         };
            return result;
        }

        private ColumnBlockDTO ToColumnBlockDTO(ColumnBlock columnBlock)
        {
            var result = new ColumnBlockDTO
                         {
                                 Id         = columnBlock.Id,
                                 Text       = columnBlock.Text,
                                 ValueText  = columnBlock.ValueText,
                                 IsRequired = columnBlock.IsRequired
                         };
            return result;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
