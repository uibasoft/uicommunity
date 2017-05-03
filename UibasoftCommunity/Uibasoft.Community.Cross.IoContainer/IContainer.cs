using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Cross.IoContainer
{
    public interface IContainer
    {
        TServicio Resolver<TServicio>();
        IEnumerable<TServicio> ResolverAll<TServicio>();
        object Resolver(Type type);
        void RegisterType(Type controllerType);
        void RegisterType(Type interfaceType, Type implementationType);
        void RegisterAllFromAssemblies(string nombre);
    }
}
