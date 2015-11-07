using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using SportStore.Web;
using SportStore.Domain.Abstract;
using SportStore.Domain.Respositories;
using SportStore.Web.HtmlHelpers.Classes;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.HtmlHelpers.ValidationAttributes;

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
            _iKernel.Bind<INewsletterRepository>().To<NewsletterRespository>();
            _iKernel.Bind<INewsletterHelper>().To<NewsletterHelper>();
            _iKernel.Bind<IClientRepository>().To<ClientsRepository>();
            _iKernel.Bind<IRegisterHelper>().To<RegisterHelper>();
            _iKernel.Bind<ILoginHelper>().To<LoginHelper>();
        }
    }
}