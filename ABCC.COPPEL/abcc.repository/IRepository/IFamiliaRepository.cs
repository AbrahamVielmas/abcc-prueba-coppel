using abcc.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abcc.repository.IRepository
{
    public interface IFamiliaRepository
    {
        Task<IEnumerable<Familia>> GetAllFamilias();
    }
}
