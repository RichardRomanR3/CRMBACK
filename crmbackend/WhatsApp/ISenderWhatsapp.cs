using System.Threading.Tasks;
using WhatsApp;

namespace crmbackend.WhatsApp {
    public interface ISenderWhatsapp {
        Task SendWhatsappAsync (MENSAJE request);
    }
}