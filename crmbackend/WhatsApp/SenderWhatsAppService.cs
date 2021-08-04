using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using WhatsApp;
/*RICHARD ROMAN 29-04-2021*/

/*ESTE PEDAZO DE CODIGO ES PROPORCIONADO POR TWILIO PERO PARA QUE FUNCIONE SE DEBE HABILITAR EL ACCOUNTSID 
Y EL AUTHTOKEN DESDE TWILIO */
namespace crmbackend.WhatsApp {

    public class SenderWhatsAppService : ISenderWhatsapp {
        public async Task SendWhatsappAsync (MENSAJE request) {
            const string accountSid = "AC2b89432e74fab3ec58cf3298d45aa81f";
            const string authToken = "5b29b2f65243ddcac23d0a27382e369c";
            TwilioClient.Init (accountSid, authToken);
            var message = await MessageResource.CreateAsync (
                from: new Twilio.Types.PhoneNumber ("whatsapp:+18054919843"),
                body : request.body,
                to : new Twilio.Types.PhoneNumber ("whatsapp:" + request.numero + "")
            );
        }
    }

}