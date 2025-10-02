using Application.DomainEvents;
using Application.Exceptions; 
using Application.Repositories; 
using Core.Application;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Constants; 

namespace Application.UseCases.Automovil.Commands.DeleteAutomovil
{
    
    internal sealed class DeleteAutomovilHandler(ICommandQueryBus domainBus, IAutomovilRepository AutomovilRepository)
        : IRequestCommandHandler<DeleteAutomovilCommand, Unit>
    {
        private readonly ICommandQueryBus _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
        private readonly IAutomovilRepository _context = AutomovilRepository ?? throw new ArgumentNullException(nameof(AutomovilRepository));

        public async Task<Unit> Handle(DeleteAutomovilCommand request, CancellationToken cancellationToken)
        {
            
            var automovil = await _context.FindByIdAsync(request.AutomovilId);

            
            if (automovil == null)
            {
                
                throw new BussinessException($"El automóvil con ID {request.AutomovilId} no fue encontrado o ya ha sido eliminado.");
            }

           
            try
            {
                _context.Remove(automovil); 

              
                await _domainBus.Publish(new automovilDeleted(request.AutomovilId), cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
               
                throw new BussinessException(ApplicationConstants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException ?? ex);
            }
        }
    }
}