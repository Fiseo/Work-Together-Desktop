using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data
{
    public abstract class EntityRepository<E>
        where E : DbEntity
    {
        protected DbSet<E> DbSet { get; set; }
        protected WorkTogetherContext Context { get; }
        public EntityRepository(WorkTogetherContext context)
        {
            Context = context;
            SetDbSet();
        }

        public EntityRepository()
        {
            Context = new WorkTogetherContext();
            SetDbSet();
        }

        protected abstract void SetDbSet();

        public virtual void Save(E entity)
        {
            if (entity.IsValid())
            {
                DbSet.Update(entity);
                Context.SaveChanges();
                return;
            }
            throw new Exception("This entity is invalid !");
        }

        public virtual void Delete(E entity)
        {
            if(entity.IsDeleteable())
            {
                DbSet.Remove(entity);
                Context.SaveChanges();
                return;
            }
            throw new Exception("This entity isn't deletable at the moment !");
        }

        public virtual List<E> FindAll()
        {
            return DbSet.ToList();
        }
    }
}
