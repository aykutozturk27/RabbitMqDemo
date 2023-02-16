using RabbitMqDemo.Core.Entities;

namespace RabbitMqDemo.Entities.Concrete
{
    public class Customer : BaseEntity
    {
        public string? CustomerID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
    }
}
