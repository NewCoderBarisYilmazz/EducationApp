using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.DataAccess.Repositories.RepositoryPattern
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
