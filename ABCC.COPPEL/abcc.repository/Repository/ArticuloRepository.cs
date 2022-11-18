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
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ContextDapper _contextDapper;

        public ArticuloRepository(ContextDapper contextDapper)
        {
            this._contextDapper = contextDapper;
        }

        public async Task<Articulo> GetArticuloBySku(int sku)
        {
            IDbConnection conn = _contextDapper.CreateConnection();
            Articulo res = await conn.QueryFirstOrDefaultAsync<Articulo>(
                sql: "SP_GetArticulosBySku",
                param: new { _sku = sku },
                commandType: CommandType.StoredProcedure
                );
            return res;
        }

        public async Task<Articulo> UpdateArticuloAsync(Articulo articulo)
        {
            IDbConnection conn = _contextDapper.CreateConnection();
            int res = await conn.ExecuteAsync(
                sql: "SP_UpdateArticulo",
                param: new { _id = articulo.Id, _sku = articulo.Sku, _nombreArticulo = articulo.NombreArticulo,
                _marca = articulo.Marca, _modelo = articulo.Modelo,
                    _idDepartamento = articulo.IdDepartamento,
                _idClase = articulo.IdClase, _idFamilia = articulo.IdFamilia, _stock = articulo.Stock,
                _cantidad = articulo.Cantidad, _descontinuado = articulo.Descontinuado, _fechaBaja = articulo.FechaBaja },
                commandType: CommandType.StoredProcedure
                );
            return await GetArticuloBySku(articulo.Sku);
        }

        public async Task<Articulo> CreateArticulo(Articulo articulo)
        {
            IDbConnection conn = _contextDapper.CreateConnection();
            int res = await conn.ExecuteAsync(
                sql: "SP_InsertArticulo",
                param: new { _sku = articulo.Sku, _nombreArticulo = articulo.NombreArticulo, _marca = articulo.Marca
                , _modelo = articulo.Modelo, _idDepartamento = articulo.IdDepartamento, _idClase = articulo.IdClase
                , _idFamilia = articulo.IdFamilia, _stock = articulo.Stock, _cantidad = articulo.Cantidad},
                commandType: CommandType.StoredProcedure
                );
            return await this.GetArticuloBySku(articulo.Sku);
        }

        public async Task<int> DeleteArticulo(int sku)
        {
            IDbConnection conn = _contextDapper.CreateConnection();
            int res = await conn.ExecuteAsync(
                sql: "SP_DeleteArticulo",
                param: new { _sku = sku },
                commandType: CommandType.StoredProcedure
                );
            return res;
        }
    }
}
