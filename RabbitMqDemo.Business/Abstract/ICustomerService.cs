using RabbitMqDemo.Entities.Concrete;

namespace RabbitMqDemo.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer Add(Customer customer);
    }
}
