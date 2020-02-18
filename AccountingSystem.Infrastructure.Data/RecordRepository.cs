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
           await Task.Run(()=> _context.Records.Add(item));
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
            try
            {
               _context.Records.Attach(item);
            }
            catch { }
            finally
            {
                var customer = _context.Records
               .Where(r => r.Id == item.Id)
               .FirstOrDefault();

                customer = item;
            }
        }

        #region Dispose
        private bool isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                _context.Dispose();
            }
            isDisposed = true;
        }
        #endregion
    }
}
