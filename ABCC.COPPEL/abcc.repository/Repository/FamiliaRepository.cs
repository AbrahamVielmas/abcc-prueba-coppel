using abcc.domain.Entities;
using abcc.repository.Infraestructure.Context;
using abcc.repository.IRepository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abcc.repository.Repository
{
    public class FamiliaRepository : IFamiliaRepository
    {
        private readonly ContextDapper _contextDapper;
        public FamiliaRepository(ContextDapper contextDapper)
        {
            this._contextDapper = contextDapper;
        }
        public async Task<IEnumerable<Familia>> GetAllFamilias()
        {
            IDbConnection conn = _contextDapper.CreateConnection();
            IEnumerable<Familia> res = await conn.QueryAsync<Familia>(
                sql: "SP_GetFamilias",
                commandType: CommandType.StoredProcedure
                );
            return res;
        }
    }
}
