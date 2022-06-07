using DependencyInjectionSample.Repositories;
using DependencyInjectionSample.Services;

namespace DependencyInjectionSample
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Dependencias
            //var sender = new SMSService();
            var sender = new EmailService();
            //var connection = new MySQLConnection();
            var connection = new OracleConnection();

            var repository = new CustomerRepository(connection);
            var customerService = new CustomerService(repository);
            var communicationService = new CommunicationService(sender);

            var customers = customerService.GetCustomers();

            var message = "Message to broadcast to all customers";
            foreach(var customer in customers)
            {
                communicationService.SendMessage(customer, message);
            }    

        }
    }
}