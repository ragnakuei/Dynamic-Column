using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.IRepository;
using DAL.Models;
using SharedLibrary.DTOs;

namespace DAL.Repository
{
    //public class ColumnRepository : IColumnRepository
    //{
    //    private readonly SqlServerDbContext _dbContext;

    //    public ColumnRepository(SqlServerDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    public IEnumerable<ColumnDTO> Get(Guid id)
    //    {
    //        var result = _dbContext.ColumnBlocks
    //                                    .Where(cb => cb.Id == id)
    //                                    .AsEnumerable()
    //                                    .Select(cb => ToColumnDTO(cb));
    //        return result;
    //    }

    //    private ColumnDTO ToColumnDTO(ColumnBlock cb)
    //    {
    //        var result = new ColumnDTO();
    //        result.Meta = ToColumnBlockDTO(cb);
    //        result.Value = cb.Column.Value;
    //        return result;
    //    }

    //    private ColumnBlockDTO ToColumnBlockDTO(ColumnBlock cb)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
