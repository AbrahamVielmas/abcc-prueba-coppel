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
    public class ClaseRepository : IClasesRepository
    {
        private readonly ContextDapper _contextDapper;

        public ClaseRepository(ContextDapper contextDapper)
        {
            this._contextDapper = contextDapper;
        }
        public async Task<IEnumerable<Clase>> GetAllClases()
        {
            IDbConnection conn = _contextDapper.CreateConnection();
            IEnumerable<Clase> res = await conn.QueryAsync<Clase>(
                sql: "SP_GetClases",
                commandType: CommandType.StoredProcedure
                );
            return res;
        }
    }
}
