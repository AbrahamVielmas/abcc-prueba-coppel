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
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ContextDapper _contextDapper;

        public DepartamentoRepository(ContextDapper contextDapper)
        {
            this._contextDapper = contextDapper;
        }

        public async Task<IEnumerable<Departamento>> GetAllDepartamentos()
        {
            IDbConnection conn = _contextDapper.CreateConnection();
            IEnumerable<Departamento> res = await conn.QueryAsync<Departamento>(
                sql: "SP_GetDepartamentos",
                commandType: CommandType.StoredProcedure
                );
            return res;
        }
    }
}
