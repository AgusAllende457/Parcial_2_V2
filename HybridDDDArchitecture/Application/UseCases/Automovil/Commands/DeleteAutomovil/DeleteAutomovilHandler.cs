using Application.Constants;
using Application.Exceptions;
using Application.Repositories;
using Core.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DomainEvents;

namespace Application.UseCases.Automovil.Commands.DeleteAutomovil
{
    internal sealed class DeleteAutomovilHandler(ICommandQueryBus domainBus, IAutomovilRepository AutomovilRepository)
      : IRequestCommandHandler<DeleteAutomovilCommand, Unit>
    {
        private readonly ICommandQueryBus _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
        private readonly IAutomovilRepository _context = AutomovilRepository ?? throw new ArgumentNullException(nameof(AutomovilRepository));

        public Task<Unit> Handle(DeleteAutomovilCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _context.Remove(request.AutomovilId);

                _domainBus.Publish(new automovilDeleted(request.AutomovilId), cancellationToken);

                return Unit.Task;
            }
            catch (Exception ex)
            {
                throw new BussinessException(ApplicationConstants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}
