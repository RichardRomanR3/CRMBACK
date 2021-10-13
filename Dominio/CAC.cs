using System;

namespace Dominio
{
    public class CAC
    {
        public Guid CAMPANA_Id { get; set; }
        public string DESCRICAMPANA { get; set; }
        public string ESTADOCAMPANA { get; set; }
        public decimal PRESUPUESTO {get;set;}
        public string EMPRESACONTRATADA {get;set;}

        public DateTime FECGRA { get; set; }

        public int ClientesAlcanzados {get;set;}
    }
}