using Ninject;
using SportStore.Domain.Abstract;
using SportStore.Domain.Respositories;
using SportStore.Web.HtmlHelpers.Classes;
using SportStore.Web.HtmlHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

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
            _iKernel.Bind<ICatalogsRepository>().To<CatalogsRepository>();
            _iKernel.Bind<ICatalogHelper>().To<CatalogsHelper>();
            _iKernel.Bind<IAccountManagmentHelper>().To<AccountManagmentHelper>();
            _iKernel.Bind<IGlobalSearchHelper>().To<GlobalSearchHelper>();
            _iKernel.Bind<IOrdersRepository>().To<OrdersRepository>();
            _iKernel.Bind<IOrderHelper>().To<OrderHelper>();
        }
    }
}