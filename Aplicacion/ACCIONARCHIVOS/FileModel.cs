using Microsoft.AspNetCore.Http;

namespace Aplicacion.ACCIONARCHIVOS {
    public class FileModel {
        public string FileName { get; set; }

        public IFormFile FormFile { get; set; }
    }
}