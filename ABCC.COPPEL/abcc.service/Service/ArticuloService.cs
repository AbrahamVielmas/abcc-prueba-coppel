using abcc.domain.Entities;
using abcc.repository.IRepository;
using abcc.service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abcc.service.Service
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _articuloRepository;

        public ArticuloService(IArticuloRepository articuloRepository)
        {
            this._articuloRepository = articuloRepository;
        }

        public async Task<Articulo> CreateArticulo(Articulo articulo)
        {
            return await _articuloRepository.CreateArticulo(articulo);
        }

        public async Task<int> DeleteArticulo(int sku)
        {
            return await _articuloRepository.DeleteArticulo(sku);
        }

        public async Task<Articulo> GetArticuloBySku(int sku)
        {
            return await _articuloRepository.GetArticuloBySku(sku);
        }

        public async Task<Articulo> UpdateArticuloAsync(Articulo articulo)
        {
            return await _articuloRepository.UpdateArticuloAsync(articulo);
        }
    }
}
