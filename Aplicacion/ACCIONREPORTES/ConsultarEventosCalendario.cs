using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.ACCIONREPORTES
{
    public class ConsultarEventosCalendario
    {
        public class Ejecuta : IRequest<List<EVENTOCALENDARIO>>
        {
            public string UsuarioId {get; set;}
            public class Manejador : IRequestHandler<Ejecuta, List<EVENTOCALENDARIO>>
            {
                CRMContext _context;
                public Manejador(CRMContext context)
                {
                    _context = context;
                }
                public async Task<List<EVENTOCALENDARIO>> Handle(Ejecuta request, CancellationToken cancellationToken)
                {
                    var ev = await _context.TAREAS.Where(x => x.COMPLETADO == null && x.UsuarioId == request.UsuarioId).Include(x => x.TIPOSTAREAS).ToListAsync();
                    var eventosFinal = new List<EVENTOCALENDARIO>();
                    for (int row = 0; row <= ev.Count - 1; row++)
                    {
                        var tipotarea = await _context.TIPOSTAREAS.FindAsync(ev[row].TIPOSTAREAS.TIPOTAREA_Id);
                        eventosFinal.Add(new EVENTOCALENDARIO
                        {
                            id = ev[row].TAREA_Id,
                            title = tipotarea.DESCRITIPOTAREA,
                            start = ev[row].FECHAVTO,
                            end = ev[row].FECHAVTO
                        });
                    }

                    return eventosFinal;
                }
            }

        }
    }
    }