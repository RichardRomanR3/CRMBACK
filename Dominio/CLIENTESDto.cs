using System;

namespace Dominio {
    public class CLIENTESDto {
        public Guid CLIENTE_Id { get; set; }
        public int CODCLIENTE { get; set; }
        public string NUMCLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string CI { get; set; }
        public string RUC { get; set; }
        public string PROFESIONORUBRO { get; set; }
        public string HOBBY { get; set; }
        public string OBSERVACIONES {get;set;}
        public DateTime FECGRA { get; set; }

        public CAMPANASDto CAMPANA { get; set; }
    }
}