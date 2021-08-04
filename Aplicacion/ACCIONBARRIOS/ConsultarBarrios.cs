using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONBARRIOS {
    public class ConsultarBarrios {
        public class ListarBarrios : IRequest<List<BARRIOSDto>> {
            public Guid CIUDAD_Id { get; set; }
        }
        public class Manejador : IRequestHandler<ListarBarrios, List<BARRIOSDto>> {
            private readonly CRMContext _context;
            private readonly IMapper _mapper;
            public Manejador (CRMContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<BARRIOSDto>> Handle (ListarBarrios request, CancellationToken cancellationToken) {
                var ciudad_id = await _context.CIUDADES.FindAsync (request.CIUDAD_Id);
                var barrios = await _context.BARRIOS
                    .Where (x => x.CIUDAD == ciudad_id)
                    .Include (c => c.CIUDAD).ToListAsync ();
                var barriosDto = _mapper.Map<List<BARRIOS>, List<BARRIOSDto>> (barrios);
                return barriosDto;
            }
        }
    }
}