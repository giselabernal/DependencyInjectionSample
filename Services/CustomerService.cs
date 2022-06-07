using DependencyInjectionSample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Services
{
    public class CustomerService
    {
       // private CustomerRepository _repository;
        //en lugar de tener el customerrepository en dependencia vamos a cambiarlo por la interfaz
        private IRepository _repository;

       

        public CustomerService(IRepository repository)
        {
            //_repository = new CustomerRepository();
            _repository = repository;
        }
        //CustomerService tambien tiene una dependencia con customerrepository
        public List<Customer> GetCustomers()
        {
            return _repository.GetCustomers();
        }
    }
}
