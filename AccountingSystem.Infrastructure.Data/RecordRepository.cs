using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.Domain.Core;
using AccountingSystem.Domain.Interfaces;

namespace AccountingSystem.Infrastructure.Data
{
    public class RecordRepository : IRecordRepository
    {
        private readonly AccountingSystemDbEntities _context;
        
        public RecordRepository(AccountingSystemDbEntities context)
        {
            _context = context;
        }

        public async Task Create(Record item)
        {
            await Task.Run(()=>_context.Records.Add(item));
        }

        public void Delete(Record item)
        {
            _context.Records.Remove(item);
        }

        public async Task<Record> GetRecord(int id)
        {
            return await _context.Records.FindAsync(id);
        }

        public async Task<IEnumerable<Record>> GetRecordList()
        {
            return await _context.Records.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Record item)
        {
            var record = _context.Records.Where(x => x.Id == item.Id).FirstOrDefault();
            record.Title = item.Title;
            record.UserId = item.UserId;
            record.DateOfCreating = item.DateOfCreating;
            _context.SaveChanges();
        }

    }
}
