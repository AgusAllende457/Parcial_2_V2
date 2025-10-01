using Application.Repositories;
using Application.UseCases.Automovil.Queries.GetAllAutomoviles;
using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DataTransferObjects;

namespace Application.UseCases.Automovil.Querie.GetAllAutomovil
{
    internal class GetAllAutomovilesHandler (IAutomovilRepository context)
    : MediatR.IRequestHandler<GetAllAutomovilesQuery, IList<AutomovilDto>>
    {
        private readonly IAutomovilRepository _context = context;

        public async Task<IList<AutomovilDto>> Handle(GetAllAutomovilesQuery request, CancellationToken cancellationToken)
        {
            IList<Domain.Entities.Automovil> entities = await _context.FindAllAsync();

       
            var automovilesAsEnumerable = entities.To<AutomovilDto>();

          
            return automovilesAsEnumerable.ToList();
        }
    }

}
