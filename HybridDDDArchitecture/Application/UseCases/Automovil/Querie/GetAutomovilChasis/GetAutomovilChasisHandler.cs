using Application.DataTransferObjects;
using Application.Exceptions;
using Application.Repositories;
using Application.UseCases.Automovil.Queries.GetAutomovilByChasis;
using Core.Application;
using Domain.Entities;

internal sealed class GetAutomovilByChasisHandler(IAutomovilRepository context)
    : IRequestQueryHandler<GetAutomovilByChasisQuery, AutomovilDto>
{
    private readonly IAutomovilRepository _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<AutomovilDto> Handle(GetAutomovilByChasisQuery request, CancellationToken cancellationToken)
    {
        
        Automovil entity = await _context.FindByChasisAsync(request.NumeroChasis)
            ?? throw new EntityDoesNotExistException($"Automóvil con Chasis {request.NumeroChasis} no existe.");

        return entity.To<AutomovilDto>();
    }
}