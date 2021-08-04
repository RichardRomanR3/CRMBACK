using System.Linq;
using Aplicacion.Seguridad;
using AutoMapper;
using Dominio;

namespace Aplicacion {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<CAMPANAS, CAMPANASDto> ()
                .ForMember (x => x.TIPOCAMPANA, y => y.MapFrom (y => y.TIPOSCAMPANAS));
            CreateMap<Dominio.CLIENTES, CLIENTESDto> ()
                .ForMember (x => x.CAMPANA, y => y.MapFrom (z => z.CAMPANAS));
            CreateMap<TAREAS, TAREASGENERALESDto> ()
                .ForMember (x => x.TIPOTAREA, y => y.MapFrom (y => y.TIPOSTAREAS))
                .ForMember (x => x.CLIENTE, y => y.MapFrom (y => y.CLIENTES))
                .ForMember (x => x.POSIBLECLIENTE, y => y.MapFrom (y => y.POSIBLECLIENTE));
            CreateMap<Dominio.CLIENTES, CLIENTESTAREASDto> ();
            CreateMap<REDES_CLIENTES, REDES_CLIENTESDto> ();
            CreateMap<Dominio.CLIENTES, CLIENTESCAMPANASDto> ();
            CreateMap<TIPOSCAMPANAS, TIPOSCAMPANASDto> ();
            CreateMap<TIPOSTAREAS, TIPOSTAREASDto> ();
            CreateMap<BARRIOS, BARRIOSDto> ();
            CreateMap<CIUDADES, CIUDADESDto> ();
            CreateMap<DIRECCIONES, DIRECCIONESDto> ().ForMember (x => x.BARRIO, y => y.MapFrom (y => y.BARRIO))
                .ForMember (x => x.CIUDAD, y => y.MapFrom (y => y.CIUDAD))
                .ForMember (x => x.CLIENTE, y => y.MapFrom (y => y.CLIENTE));
            CreateMap<TELEFONOS, TELEFONOSDto> ().ForMember (x => x.CLIENTE, y => y.MapFrom (y => y.CLIENTE));
            CreateMap<TELEFONOSTAREAS, TELEFONOSTAREASDto> ()
                .ForMember (X => X.TAREA, y => y.MapFrom (y => y.TAREA))
                .ForMember (x => x.CLIENTE, y => y.MapFrom (y => y.CLIENTE));
            CreateMap<TAREAS, TAREASDto> ();
            CreateMap<DIRECCIONESTAREAS, DIRECCIONESTAREASDto> ().ForMember (x => x.BARRIO, y => y.MapFrom (y => y.BARRIO))
                .ForMember (X => X.TAREA, y => y.MapFrom (y => y.TAREA))
                .ForMember (x => x.CIUDAD, y => y.MapFrom (y => y.CIUDAD))
                .ForMember (x => x.CLIENTE, y => y.MapFrom (y => y.CLIENTE));
            CreateMap<CONTACTOS, CONTACTOSDto> ().ForMember (x => x.CLIENTES, y => y.MapFrom (y => y.CLIENTE));
            CreateMap<PANTALLAS, PantallaDto> ();
            CreateMap<POSIBLESCLIENTES, POSIBLESCLIENTESDto> ();
            CreateMap<Roles, RolDto> ()
                .ForMember (x => x.ListaPantallasRol, y => y.MapFrom (z => z.PantallasLista.Select (a => a.PANTALLA).ToList ()));
            CreateMap<Subcategoria, SubcategoriaDto> ()
                .ForMember (x => x.PantallasLista, y => y.MapFrom (y => y.PantallasLista));
            CreateMap<Categoria, CategoriaDto> ()
                .ForMember (x => x.SubcategoriasLista, y => y.MapFrom (y => y.SubcategoriasLista));
            CreateMap<Usuarios, UsuarioDto> ();
            CreateMap<SUGERENCIAS, SUGERENCIASDto> ()
                .ForMember (x => x.Cliente, y => y.MapFrom (y => y.Cliente));
        }
    }
}