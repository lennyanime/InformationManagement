using InformationManagement.Dominio.Core.Administracion.Documento;
using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Administration.Person;
using InformationManagement.Dominio.Core.Areas;
using InformationManagement.Dominio.Core.Base;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base
{
    internal  class ContextDB : DbContext, IContextDB
    {
        private readonly DbSettings _settings;

        // Aqui se definen todas las tablas de la base de datos

        #region Tablas db

        public virtual DbSet<AreaEntity> Area { get; set; }
        public virtual DbSet<DocumentTypeEntity> Document { get; set; }
        public virtual DbSet<ClientEntity> Client { get; set; }
        public virtual DbSet<EmployeeEntity> Employee { get; set; }
        public virtual DbSet<ProviderEntity> Provider { get; set; }

        //public virtual DbSet<HistoricoContrasenaEntity> HistoricoCOntrasena { get; set; }

        #endregion Tablas db

        public ContextDB(IOptions<DbSettings> settings) =>
            _settings = settings.Value;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(_settings.ConnectionString);

        public int Commit() => base.SaveChanges();

        public void Rollback() =>
            base.ChangeTracker
            .Entries()
            .Where(e => e.Entity != null)
            .ToList()
            .ForEach(e => e.State = EntityState.Detached);

        public new DbSet<T> Set<T>() where T : EntidadBase => base.Set<T>();

        public void SetDeatached<T>(T item) where T : EntidadBase => Entry(item).State = EntityState.Detached;
        public void SetModified<T>(T item) where T : EntidadBase => Entry(item).State = EntityState.Modified;

        public void Attach<T>(T item) where T : EntidadBase
        {
            if (Entry(item).State == EntityState.Detached)
                base.Set<T>().Attach(item);
        }
    }
}

