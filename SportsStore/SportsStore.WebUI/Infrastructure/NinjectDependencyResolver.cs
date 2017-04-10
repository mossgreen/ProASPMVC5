using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using Moq;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            // -> this is how we mock data  <-
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();

            //mock.Setup(m => 
            //    m.Products)
            //    .Returns(new 
            //        List<Product> { new Product { Name = "Football", Price = 25 }, new Product { Name = "Surf board", Price = 179 }, new Product { Name = "Running shoes", Price = 95 } });

            ///*Rather than create a new instance of the implementation object each time, 
            // * Ninject will always satisfy requests for the IProductRepository interface 
            // * with the same mock object.*/
            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);

            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}