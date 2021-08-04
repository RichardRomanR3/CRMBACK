using System;
using System.Collections.Generic;
namespace Dominio
{
    public class CAMPANASDto
    {
        public Guid CAMPANA_Id { get; set; }
        public int CODCAMPANA {get;set;}
        public string DESCRICAMPANA { get; set; }
        public string NUMCAMPANA { get; set; }
        public string ESTADOCAMPANA { get; set; }
         public string OBJETIVOS {get;set;}
        public decimal PRESUPUESTO {get;set;}
        public string GEOGRAFIA {get;set;}
        public string EMPRESACONTRATADA {get;set;}
        public TIPOSCAMPANASDto TIPOCAMPANA {get;set;}      
    }
}