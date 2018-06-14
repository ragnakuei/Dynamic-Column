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
            var columnBlocks = _dbContext.ColumnBlock
                                         .AsEnumerable()
                                         .Select(c => ToColumnBlockDTO(c));
            return columnBlocks;
        }

        public ColumnBlockDTO Get(Guid id)
        {
            var columnBlock = _dbContext.ColumnBlock
                                        .Find(id);
            var dto = ToColumnBlockDTO(columnBlock);
            return dto;
        }

        public int Add(ColumnBlockDTO dto)
        {
            var entityModel = ToColumnBlock(dto);
            _dbContext.ColumnBlock.Add(entityModel);
            var result = _dbContext.SaveChanges();
            return result;
        }

        public void Remove(Guid id)
        {
            try
            {
                var entity = _dbContext.ColumnBlock.Find(id);
                _dbContext.ColumnBlock.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch ( Exception e )
            {
            }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        private ColumnBlockDTO ToColumnBlockDTO(ColumnBlock columnBlock)
        {
            var result = new ColumnBlockDTO();
            result.Name = columnBlock.Name;

            result.ColumnDTOs = columnBlock.ColumnMetas
                                           .Select(cm => ToColumnMetaDTO(cm))
                                           .ToList();
            return result;
        }

        private ColumnDTO ToColumnMetaDTO(ColumnMeta cm)
        {
            var result = new ColumnDTO();
            result.Value = cm.ColumnValue.Value;
            result.ColumnMetaDTO = new ColumnMetaDTO
                                   {
                                           Id         = cm.Id,
                                           Text       = cm.Text,
                                           ValueText  = cm.ValueText,
                                           IsRequired = cm.IsRequired
                                   };
            return result;
        }

        private ColumnBlock ToColumnBlock(ColumnBlockDTO dto)
        {
            var result = new ColumnBlock();
            result.Name = dto.Name;

            result.ColumnMetas = dto.ColumnDTOs
                                    .Select(cm => ToColumnMeta(cm))
                                    .ToList();
            return result;
        }


        private ColumnMeta ToColumnMeta(ColumnDTO cm)
        {
            var result = new ColumnMeta
                         {
                                 Id         = cm.ColumnMetaDTO.Id,
                                 Text       = cm.ColumnMetaDTO.Text,
                                 ValueText  = cm.ColumnMetaDTO.ValueText,
                                 IsRequired = cm.ColumnMetaDTO.IsRequired
                         };
            result.ColumnValue.Value = cm.Value;
            return result;
        }
    }
}
