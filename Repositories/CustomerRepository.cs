using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Repositories
{
    public class CustomerRepository : IRepository
    {
        //private MySQLConnection _connection;
        //entonces el cambio es el siguiente, quitamos el mysqlconnection
        private IDBConnection _connection;
        //aunque no tenga nada repository depende de connection

        //public CustomerRepository()
        public CustomerRepository(IDBConnection connection)
        {
            //_connection = new MySQLConnection();
            _connection = connection;
            //de nuevo este repositorio tiene una dependencia con sql
            //que pasa si quiero agregar oracle connection?? //creamos la clase
            //y aqui tendriamos que cambiar la conexion completa o a mysql o a oracle
        }

        public List<Customer> GetCustomers()
        {
            if (_connection.GetType() == typeof(MySQLConnection))
            {
                Console.WriteLine("Get customers from sql");
            }
            else
            {
                Console.WriteLine("Get customers from oracle");
            }
            return new List<Customer>
            { 
                new Customer() {Id=1,Name="Gloria Almanza", Email="gloria.almanza@gmail.com", Phone= "33444345"},
                new Customer() {Id=2,Name="Fernando Mtz", Email="fer.mtz@hotmail.com", Phone= "5678943234"},
                new Customer() {Id=3,Name="Raul Godinez", Email="rgodinez@gmail.com", Phone= "3345677345"},
                new Customer() {Id=4,Name="Maria Avila", Email="m.avila@hotmail.com", Phone= "87654565"},
                new Customer() {Id=5,Name="Rosa Galicia", Email="rosagalicia1@gmail.com", Phone= "66679766"},
            };
        }
    }
}
