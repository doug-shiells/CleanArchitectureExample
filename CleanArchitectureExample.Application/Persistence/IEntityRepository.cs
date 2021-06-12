using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureExample.Application.Persistence
{
    public interface IEntityRepository<EntityType>
    {
        IQueryable<EntityType> Entities { get; }

        void Remove(EntityType entity);

        void Insert(EntityType entity);

        void Update(EntityType entity);

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
