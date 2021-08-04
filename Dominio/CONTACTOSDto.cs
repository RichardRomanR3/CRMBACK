using System;
namespace Dominio
{
    public class CONTACTOSDto
    {
         public Guid CONTACTO_Id { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public string USUARIOP{get;set;}
        public string OBSERVACIONES { get; set; }
        public DateTime FECGRA { get; set; }
        public CLIENTESTAREASDto CLIENTES { get; set; }
    }
}