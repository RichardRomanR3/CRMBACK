using System.Threading.Tasks;
using crmbackend.WhatsApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatsApp;

namespace crmbackend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class WhatsAppController : ControllerBase {
        private readonly ISenderWhatsapp _IWsp;
        public WhatsAppController (ISenderWhatsapp IWsp) {
            _IWsp = IWsp;
        }

        [HttpPost]
        public async Task Ejecuta (MENSAJE data) {
            await _IWsp.SendWhatsappAsync (data);
        }
    }
}