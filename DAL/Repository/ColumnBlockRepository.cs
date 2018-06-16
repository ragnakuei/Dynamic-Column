using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.IRepository;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
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
                                         .Include(c => c.ColumnMetas)
                                         .ThenInclude(cm => cm.ColumnValue)
                                         .AsEnumerable()
                                         .Select(c => ToColumnBlockDTO(c));
            return columnBlocks;
        }

        public ColumnBlockDTO Get(Guid id)
        {
            var columnBlock = _dbContext.ColumnBlock
                                        .Include(cb => cb.ColumnMetas)
                                        .FirstOrDefault(cb => cb.Id == id);
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

        public void UpdateValue(List<ColumnBlockDTO> vModel)
        {
            var columnValues = vModel.SelectMany(cb => cb.ColumnDTOs)
                                     .Select(metaValue => ToColumnValue(metaValue));
            try
            {
                _dbContext.ColumnValue.AddRange(columnValues);
                _dbContext.SaveChanges();
            }
            catch ( Exception e )
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        private ColumnBlockDTO ToColumnBlockDTO(ColumnBlock columnBlock)
        {
            var result = new ColumnBlockDTO();
            result.Id   = columnBlock.Id;
            result.Name = columnBlock.Name;

            result.ColumnDTOs = columnBlock.ColumnMetas
                                           .Select(cm => ToColumnMetaDTO(cm))
                                           .ToList();
            return result;
        }

        private ColumnDTO ToColumnMetaDTO(ColumnMeta cm)
        {
            var result = new ColumnDTO();
            result.Value = cm.ColumnValue?.Value ?? string.Empty;
            result.ColumnMetaDTO = new ColumnMetaDTO
                                   {
                                           Id         = cm.Id,
                                           Text       = cm.Text,
                                           ValueText  = cm.ValueText,
                                           IsRequired = cm.IsRequired,
                                           OrderId    = cm.OrderId
                                   };
            return result;
        }

        private ColumnBlock ToColumnBlock(ColumnBlockDTO dto)
        {
            var result = new ColumnBlock();
            result.Id   = Guid.NewGuid();
            result.Name = dto.Name;

            result.ColumnMetas = dto.ColumnDTOs
                                    .Select(cm => ToColumnMeta(result.Id, cm))
                                    .ToList();
            return result;
        }

        private ColumnMeta ToColumnMeta(Guid id, ColumnDTO cm)
        {
            var result = new ColumnMeta
                         {
                                 Id            = Guid.NewGuid(),
                                 Text          = cm.ColumnMetaDTO.Text,
                                 ValueText     = cm.ColumnMetaDTO.ValueText,
                                 IsRequired    = cm.ColumnMetaDTO.IsRequired,
                                 OrderId       = cm.ColumnMetaDTO.OrderId,
                                 ColumnBlockId = id
                         };
            return result;
        }

        private ColumnValue ToColumnValue(ColumnDTO dto)
        {
            var result = new ColumnValue();
            result.Id           = dto.Id;
            result.Value        = dto.Value;
            result.ColumnMetaId = dto.ColumnMetaDTO.Id;
            return result;
        }
    }
}
