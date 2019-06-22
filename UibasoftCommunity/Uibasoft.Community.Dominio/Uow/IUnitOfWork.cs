using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Dominio.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        Guid InstanceId { get; }
        int Complete();
        Task<int> CompleteAsync();
        void RollbackChanges();
    }
}
