using RabbitMqDemo.Business.Abstract;
using RabbitMqDemo.Core.Utilities.Adapter.RabbitMq;
using RabbitMqDemo.DataAccess.Abstract;
using RabbitMqDemo.Entities.Concrete;

namespace RabbitMqDemo.Business.Concrete.Managers
{
    public class CustomerManager : ICustomerService
    {
        private readonly IRabbitMqConnectionAdapter _rabbitMqConnectionAdapter;
        private readonly ICustomerDal _customerDal;

        public CustomerManager(IRabbitMqConnectionAdapter rabbitMqConnectionAdapter, ICustomerDal customerDal)
        {
            _rabbitMqConnectionAdapter = rabbitMqConnectionAdapter;
            _customerDal = customerDal;
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetList();   
        }

        public Customer Add(Customer customer)
        {
            _rabbitMqConnectionAdapter.SendMessage(customer);
            _rabbitMqConnectionAdapter.GetMessage(customer);
            var addedCustomer = _customerDal.Add(customer);
            return addedCustomer;
        }
    }
}
