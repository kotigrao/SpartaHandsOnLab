using Lab.Application.Contracts;
using Lab.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Infrastructure.Repositories
{
    public class PatientRepository: RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            var carList = await _dbContext.Patients.ToListAsync();
            return carList;
        }
    }
}
