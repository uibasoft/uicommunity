using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uibasoft.Community.Cross.IoContainer
{
    public static class IoC
    {
        private static readonly object lockObj = new object();
        private static IContainer _container;
        public static IContainer Container
        {
            get { return _container; }

            private set
            {
                lock (lockObj)
                {
                    _container = value;
                }
            }
        }
        public static void SetContainer(IContainer container)
        {
            Container = container;
        }
        public static TServicio Resolver<TServicio>()
        {
            return _container.Resolver<TServicio>();
        }
        public static object Resolver(Type type)
        {
            return _container.Resolver(type);
        }
    }
}
