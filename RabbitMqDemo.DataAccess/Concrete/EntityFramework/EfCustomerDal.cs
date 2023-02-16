using RabbitMqDemo.Core.DataAccess.EntityFramework;
using RabbitMqDemo.DataAccess.Abstract;
using RabbitMqDemo.DataAccess.Concrete.EntityFramework.Contexts;
using RabbitMqDemo.Entities.Concrete;

namespace RabbitMqDemo.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RabbitMqDemoContext>, ICustomerDal
    {
    }
}
