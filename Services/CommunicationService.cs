using DependencyInjectionSample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Services
{
    public class CommunicationService
    {

        //tiene declarada una independencia con emailservice
        //y dentro del comm service constructor estamos creando una instancia

        //private EmailService _emailService;
        private ISender _sender;
        //y aca abajo vamos a recibir por parametro el
        //public CommunicationService()
        public CommunicationService(ISender sender) 
        {
           // _emailService = new EmailService();
           //aqui se acaba la instancia de emailservice
           //aqui el sender esta siendo inyectado a esta clase
           //aqui lo que va a hacer es que solo se envie el msg
            _sender = sender;
        }
        //sender esta siendo inyectada a la clase comm service
        //esto ocasiona un problema, si el dia de mañana queremos enviar otro mensaje diferente de otro
        //tipo tenemos que venir a cambiar todo aqui
        //tampoco se puede hacer unit testing con mock xke hay dependencia

        //Esta clase va a llamar al servicio que corresponda
        public void  SendMessage(Customer customer, string message)
        {
            //_emailService.Send(customer, message);
            _sender.Send(customer, message);
        }

        //tambien que pasa si se quiere mandar una semana correo por ssms
        //y otra semana por mail, se tendria que venir a cambiar esta clase 
        //para ello implementamos una clase ISender

        //lo que viene, viene algo interesante, no necesitamos que ya no necesitamos depender
        //de emailservice
    }
}
