using RabbitMqDemo.Core.DataAccess;
using RabbitMqDemo.Entities.Concrete;

namespace RabbitMqDemo.DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}
