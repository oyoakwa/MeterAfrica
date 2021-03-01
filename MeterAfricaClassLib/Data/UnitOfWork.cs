using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeterAfricaClassLib.Data
{
    public interface IUnitOfWork : IDisposable
    {
        MeterAfricaDbCotext Context { get; }
        Task CommitAsync();
        void Commit();
    }

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public MeterAfricaDbCotext Context { get; }
        private bool _disposed;

        public UnitOfWork(MeterAfricaDbCotext context)
        {
            Context = context;
            _disposed = false;
        }
        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                Context.Dispose();
            }
            _disposed = true;
        }

        #endregion
    }
}
