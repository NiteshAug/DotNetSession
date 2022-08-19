using WebApplication5.Interface;

namespace WebApplication5.Service
{
    public class CustomerService : ICustomer
    {
        public string printName(string name)
        {
            return name;
        }
    }
}
