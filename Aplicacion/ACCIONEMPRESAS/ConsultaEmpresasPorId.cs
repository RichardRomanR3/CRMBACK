using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.ACCIONEMPRESAS {
    public class ConsultaEmpresasPorId {
        public class EmpresaUnica : IRequest<Empresas> {
            public Guid EMPRESA_Id { get; set; }

        }
        public class Manejador : IRequestHandler<EmpresaUnica, Empresas> {
            private readonly CRMContext _context;
            public Manejador (CRMContext context) {
                _context = context;

            }

            public async Task<Empresas> Handle (EmpresaUnica request, CancellationToken cancellationToken) {
                var empresa = await _context.Empresas.FindAsync (request.EMPRESA_Id);
                return empresa;
            }
        }
    }
}