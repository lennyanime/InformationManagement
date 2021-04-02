using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InformationManagement.Dominio.Core.Base
{
    public interface IRepositorioBase<T> where T : EntidadBase
    {
        IUnitOfWork UnitOfWork { get; }

        public Task<T> Insert<T>(T entidad) where T : EntidadBase;

        public bool Update<T>(T entidad) where T : EntidadBase;

        public bool Delete<T>(T id) where T : EntidadBase;

        public IEnumerable<T> SearchMatching<T>(Expression<Func<T, bool>> predicate) where T : EntidadBase;

        public T SearchMatchingOneResult<T>(Expression<Func<T, bool>> predicate) where T : EntidadBase;

        public IEnumerable<T> GetAll<T>() where T : EntidadBase;
    }
}
