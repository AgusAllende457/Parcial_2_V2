using Application.DataTransferObjects;
using Application.Exceptions;
using Application.Repositories;
using Application.UseCases.Automovil.Queries.GetAutomovilById;
using Core.Application;
using Domain.Entities;

internal sealed class GetAutomovilByIdHandler(IAutomovilRepository context)
    : IRequestQueryHandler<GetAutomovilByIdQuery, AutomovilDto>
{
    private readonly IAutomovilRepository _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<AutomovilDto> Handle(GetAutomovilByIdQuery request, CancellationToken cancellationToken)
    {
        
        Automovil entity = await _context.FindByIdAsync(request.AutomovilId)
            ?? throw new EntityDoesNotExistException();

        return entity.To<AutomovilDto>();
    }
}