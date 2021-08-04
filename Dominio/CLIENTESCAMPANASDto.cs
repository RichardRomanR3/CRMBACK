using System;
using System.Text.Json.Serialization;

namespace Dominio
{
    public class CLIENTESCAMPANASDto
    {       
        public Guid CLIENTE_Id { get; set; }
        public int CODCLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string CI { get; set; }
        public string RUC { get; set; }
        [JsonIgnore]
        public CAMPANASDto CAMPANA { get; set; }
       
    }
}