using abcc.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abcc.service.IService
{
    public interface IClaseService
    {
        Task<IEnumerable<Clase>> GetAllClases();
    }
}
