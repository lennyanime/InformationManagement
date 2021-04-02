using Microsoft.EntityFrameworkCore;
using System;

namespace InformationManagement.Dominio.Core.Base
{
    public interface IUnitOfWork : IDisposable
    {
        public int Commit();

        public void Rollback();

        public DbSet<T> Set<T>() where T : EntidadBase;

        public void Attach<T>(T item) where T : EntidadBase;

        public void SetModified<T>(T item) where T : EntidadBase;
        public void SetDeatached<T>(T item) where T : EntidadBase;
    }
}
