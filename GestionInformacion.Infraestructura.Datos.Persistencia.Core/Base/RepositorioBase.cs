using InformationManagement.Dominio.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base
{
    internal abstract class RepositorioBase<TGeneric> : IRepositorioBase<TGeneric> where TGeneric : EntidadBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork => _unitOfWork;

        public RepositorioBase(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<T> Insert<T>(T entidad) where T : EntidadBase
        {
            var response = await _unitOfWork.Set<T>().AddAsync(entidad);
            _unitOfWork.Commit();
            return response.Entity;
        }

        public bool Update<T>(T entidad) where T : EntidadBase
        {
            try
            {
                //_unitOfWork.SetDeatached(entidad);
                var response = _unitOfWork.Set<T>().Update(entidad);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception exce)
            {
                return false;
            }
        }

        public bool Delete<T>(T entity) where T : EntidadBase
        {
            try
            {
                var entityToDelete = _unitOfWork.Set<T>().First(x => x == entity);
                _unitOfWork.Set<T>().Remove(entityToDelete);
                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T> SearchMatching<T>(Expression<Func<T, bool>> predicate) where T : EntidadBase =>
            _unitOfWork.Set<T>().Where(predicate);

        public IEnumerable<T> GetAll<T>() where T : EntidadBase => _unitOfWork.Set<T>().ToArray();

        public T SearchMatchingOneResult<T>(Expression<Func<T, bool>> predicate) where T : EntidadBase =>
            _unitOfWork.Set<T>().First(predicate);
    }
}
