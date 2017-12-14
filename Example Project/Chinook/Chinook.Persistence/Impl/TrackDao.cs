using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;
using Chinook.Domain;
using Chinook.Persistence.Interfaces;
using Dapper;

namespace Chinook.Persistence.Impl
{
    public class TrackDao : IEntityDao<Track, int>, ITrackDao
    {
        #region Pirvate variables and constructors

        private IDictionary<string, string> orderSetting = new Dictionary<string, string>()
                {
                    {"id", "TrackId"},
                    {"name", "Name"}
                };

        protected readonly IDbConnectionFactory factory;

        public TrackDao(IDbConnectionFactory factory)
        {
            this.factory = factory;
        }

        public List<string> OrderFieldList
        {
            get
            {

                return orderSetting.Keys.ToList<string>();
            }

            set
            {

            }
        }

        #endregion

        #region Generic Entity interface implementation

        public DbResult<Track> FindAll(
                string searchString = "",
                bool doPaging = false, int pageNo = 1, int pageSize = 25,
                string orderBy = "id", DbOrderDirection orderDirection = DbOrderDirection.ASC)
        {
            IEnumerable<Track> entities = null;
            var count = 0;

            using (IDbConnection conn = factory.GetConnection())
            {
                #region Criteria

                if (!String.IsNullOrEmpty(searchString))
                    throw new NotImplementedException();

                #endregion

                #region Sql Ordering

                var sqlOrderBy = String.Empty;

                if (!String.IsNullOrEmpty(orderBy) || orderSetting[orderBy] == null)
                    orderBy = "id";

                if (orderSetting[orderBy] != null)
                {
                    sqlOrderBy = "order by " + orderSetting[orderBy];

                    if (orderDirection == DbOrderDirection.ASC)
                    {
                        sqlOrderBy = sqlOrderBy + " asc";
                    }
                    else
                    {
                        sqlOrderBy = sqlOrderBy + " desc";
                    }
                }

                #endregion

                #region Find Count

                var sqlCount = "select count(*) from Track";
                conn.Open();
                count = conn.Query<int>(sqlCount, new { searchString = searchString }).FirstOrDefault<int>();
                conn.Close();

                #endregion

                #region Paging
                
                if (doPaging)
                {
                    throw new NotImplementedException();
                }                

                #endregion

                var sql = String.Empty;
                sql = "select TrackId as Id, Name from Track";

                conn.Open();
                entities = conn.Query<Track>(sql);
            }

            return new DbResult<Track>() { Items = entities, Count = count };
        }

        public Track Find(int id)
        {
            throw new NotImplementedException();
        }

        public Track Save(Track entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Track entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ITrackDao interface implementation


        #endregion
    }
}
