using System;

namespace Dominio {
    public class ROLES_PANTALLAS {
        public string RoleId{get;set;}
        public Roles Role { get; set; }
        
        public Guid PANTALLAId { get; set; }
        public PANTALLAS PANTALLA { get; set; }
    }
}