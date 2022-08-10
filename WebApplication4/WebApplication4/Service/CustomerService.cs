using WebApplication4.Interface;

namespace WebApplication4.Service
{
    public class CustomerService : ICustomer
    {
        public string printName(string name)
        {
            return name;
        }
    }
}
