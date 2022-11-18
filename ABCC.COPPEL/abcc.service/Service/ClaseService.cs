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
    public class ClaseService : IClaseService
    {
        private readonly IClasesRepository _claseRepository;

        public ClaseService(IClasesRepository claseRepository)
        {
            this._claseRepository = claseRepository;
        }

        public async Task<IEnumerable<Clase>> GetAllClases()
        {
            return await _claseRepository.GetAllClases();
        }
    }
}
