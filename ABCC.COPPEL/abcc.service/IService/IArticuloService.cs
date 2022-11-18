using abcc.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abcc.service.IService
{
    public interface IArticuloService
    {
        Task<Articulo> GetArticuloBySku(int sku);
        Task<Articulo> CreateArticulo(Articulo articulo);
        Task<Articulo> UpdateArticuloAsync(Articulo articulo);
        Task<int> DeleteArticulo(int sku);
    }
}
