using System;
using System.IO;
using System.Threading.Tasks;
namespace Aplicacion.ACCIONARCHIVOS {
    public class SubirArchivos : ISubirArchivos {

        public async Task SubirArchivoAsync (FileModel request) {
            try {
                string path = Path.Combine (Directory.GetCurrentDirectory (), "Archivos", request.FileName);
                using (Stream stream = new FileStream (path, FileMode.Create)) {
                    await request.FormFile.CopyToAsync (stream);
                }
            } catch (Exception ex) {
                Console.WriteLine ("NO SE PUDO" + ex);
            }
        }
    }
}