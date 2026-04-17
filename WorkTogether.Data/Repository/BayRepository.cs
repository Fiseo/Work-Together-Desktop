using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTogether.Data.Models;

namespace WorkTogether.Data.Repository
{
    public class BayRepository: EntityRepository<Bay>
    {
        private UnitRepository _unitRepository;
        public BayRepository() : this(new WorkTogetherContext()) { }
        public BayRepository(WorkTogetherContext context) : base(context)
        {
            _unitRepository = new UnitRepository(context);
        }

        protected override void SetDbSet()
        {
            DbSet = Context.BaySet;
        }

        public override void Delete(Bay entity)
        {
            if (entity.IsDeleteable() || entity.IsEveryUnitIsDeletable())
            {
                DbSet.Remove(entity);
                Context.SaveChanges();
                return;
            }
            throw new Exception("This entity isn't deletable at the moment !");
        }

        public override List<Bay> FindAll()
        {
            return DbSet
                .Include(b => b.Units)
                .ToList();
        }
    }
}
