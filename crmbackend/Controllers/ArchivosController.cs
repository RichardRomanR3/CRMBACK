using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aplicacion.ACCIONARCHIVOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//SE USA
namespace crmbackend.Controllers {

  [ApiController]
  [Route ("api/[controller]")]
  [AllowAnonymous]
  public class ArchivosController : ControllerBase {
    private readonly ISubirArchivos _subir;
    public ArchivosController (ISubirArchivos subir) {
      _subir = subir;

    }

    [HttpPost]
    public async Task<string> Upload ([FromForm] FileModel request) {
      await _subir.SubirArchivoAsync (request);
      string path = Path.Combine (Directory.GetCurrentDirectory (), "Archivos", request.FileName);
      return request.FileName;
    }

    [HttpGet ("{nombre}")]
    public async Task<FileResult> Download (string nombre) {
      string path = Path.Combine (Directory.GetCurrentDirectory (), "Archivos", nombre);
      var memory = new MemoryStream ();
      using (var stream = new FileStream (path, FileMode.Open)) {
        await stream.CopyToAsync (memory);
      }
      memory.Position = 0;
      var ext = Path.GetExtension (path).ToLowerInvariant ();
      var file = PhysicalFile (path, GetMimeTypes () [ext], Path.GetFileName (path));
      return File (memory, GetMimeTypes () [ext], Path.GetFileName (path));
    }
    private Dictionary<string, string> GetMimeTypes () {
      return new Dictionary<string, string> { { ".txt", "text/plain" },
        { ".pdf", "application/pdf" },
        { ".doc", "application/vnd.ms-word" },
        { ".docx", "application/vnd.ms-word" },
        { ".xls", "application/vnd.ms-excel" },
        { ".xlsx", "application/vnd.openxmlformats.officedocument.spreadsheetml.sheet" },
        { ".png", "image/png" },
        { ".jpg", "image/jpg" },
        { ".jpeg", "image/jpeg" },
        { ".gif", "Image/gif" },
        { ".csv", "text/csv" },
      };
    }
  }
}