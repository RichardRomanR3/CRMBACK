using System.Threading.Tasks;
namespace Aplicacion.ACCIONARCHIVOS {
    public interface ISubirArchivos {
        Task SubirArchivoAsync (FileModel request);
    }
}