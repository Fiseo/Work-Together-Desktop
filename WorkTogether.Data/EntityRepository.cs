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
            setDbSet();
        }

        public EntityRepository()
        {
            Context = new WorkTogetherContext();
            setDbSet();
        }

        protected abstract void setDbSet();

        public void save(E entity)
        {
            if (entity.isValid())
            {
                DbSet.Update(entity);
                Context.SaveChanges();
                return;
            }
            throw new Exception("This entity is invalid !");
        }

        public void delete(E entity)
        {
            if(entity.isDeletable())
            {
                DbSet.Remove(entity);
                Context.SaveChanges();
                return;
            }
            throw new Exception("This entity isn't deletable at the moment !");
        }

        public virtual List<E> findAll()
        {
            return DbSet.ToList();
        }
    }
}
