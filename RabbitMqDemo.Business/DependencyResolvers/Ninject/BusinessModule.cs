using Ninject.Modules;
using RabbitMqDemo.Business.Abstract;
using RabbitMqDemo.Business.Concrete.Managers;
using RabbitMqDemo.Core.Utilities.Adapter.RabbitMq;
using RabbitMqDemo.DataAccess.Abstract;
using RabbitMqDemo.DataAccess.Concrete.EntityFramework;

namespace RabbitMqDemo.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerDal>().To<EfCustomerDal>().InSingletonScope();
            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<IRabbitMqConnectionAdapter>().To<RabbitMqConnectionAdapter>().InSingletonScope();
        }
    }
}
