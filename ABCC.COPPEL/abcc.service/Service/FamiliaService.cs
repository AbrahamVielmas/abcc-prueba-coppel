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
    public class FamiliaService : IFamiliaService
    {
        private readonly IFamiliaRepository _familiaRepository;
        public FamiliaService(IFamiliaRepository familiaRepository)
        {
            this._familiaRepository = familiaRepository;
        }
        public async Task<IEnumerable<Familia>> GetAllFamilias()
        {
            return await _familiaRepository.GetAllFamilias();
        }
    }
}
