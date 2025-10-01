using Application.DataTransferObjects;
using Core.Application; // Asumo IRequestQuery está aquí

namespace Application.UseCases.Automovil.Queries.GetAllAutomoviles
{
  
    public class GetAllAutomovilesQuery : IRequestQuery<IList<AutomovilDto>>
    {
        
    }
}