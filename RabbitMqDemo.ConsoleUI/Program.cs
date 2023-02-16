using RabbitMqDemo.Business.Abstract;
using RabbitMqDemo.Business.DependencyResolvers.Ninject;
using RabbitMqDemo.Entities.Concrete;

var customerService = InstanceFactory.GetInstance<ICustomerService>();
var customer = new Customer
{
    CustomerID = "test",
    CompanyName = "Test Company",
    ContactName = "Test Contact",
    ContactTitle = "Test Contact"
};

//var customerList = customerService.GetAll();
//foreach (var customer in customerList)
//{
//    Console.WriteLine("Company Name: " + customer.CompanyName);
//}

customerService.Add(customer);
Console.WriteLine("Finished");
Console.ReadLine();