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
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public DepartamentoService(IDepartamentoRepository departamentoRepository)
        {
            this._departamentoRepository = departamentoRepository;
        }
        public async Task<IEnumerable<Departamento>> GetAllDepartamentos()
        {
            return await _departamentoRepository.GetAllDepartamentos();
        }
    }
}
