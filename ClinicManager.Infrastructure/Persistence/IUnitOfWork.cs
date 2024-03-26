using ClinicManagerAPI.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
       Task<int> CommitAsync();
             
    }
}
