using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using SportStore.Web;

namespace SportStore.Web.Infrastructure
{
    /// <summary>
    /// Klasa odpowiadająca za kontener wstrzyknięcia
    /// </summary>
    public class NinjectDepedencyResolver : IDependencyResolver
    {
        private IKernel _iKernel;

        public NinjectDepedencyResolver(IKernel iKernel)
        {
            _iKernel = iKernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _iKernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _iKernel.GetAll(serviceType);
        }

        /// <summary>
        /// Metoda do której dodajemy nasze wstrzyknięcia
        /// </summary>
        private void AddBindings()
        {
            
        }
    }
}