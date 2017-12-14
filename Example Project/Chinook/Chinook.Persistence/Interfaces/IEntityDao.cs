using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chinook.Persistence.Interfaces
{
    public class DbResult<TEntity>
    {
        public IEnumerable<TEntity> Items { get; set; }
        public int Count { get; set; }
    }

    public enum DbOrderDirection
    {
        ASC = 0,
        DESC
    }

    public interface IEntityDao<TEntity, TEntityPK>
    {
        List<string> OrderFieldList { get; set; }

        DbResult<TEntity> FindAll(
                string searchString = "", bool doPaging = false,
                int pageNo = 1,
                int pagesize = 25,
                string orderBy = "id",
                DbOrderDirection orderDirection = DbOrderDirection.ASC);

        TEntity Find(TEntityPK id);
        TEntity Save(TEntity entity);

        void Delete(TEntity entity);
        void Delete(TEntityPK id);
    }
}
