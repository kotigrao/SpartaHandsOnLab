using Lab.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Application.Contracts
{
    public interface IPatientRepository: IAsyncRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetAllAsync();
    }
}
