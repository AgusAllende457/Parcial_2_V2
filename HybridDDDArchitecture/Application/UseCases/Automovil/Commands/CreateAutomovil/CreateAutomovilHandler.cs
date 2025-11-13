using Application.Constants;
using Application.Exceptions;
using Application.Repositories;
using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Automovil.Commands.CreateAutomovil;
using Application.ApplicationServices;
using Application.DomainEvents;
using System.Threading; 

namespace Application.UseCases.Automovil.Commands.CreateAutomovil
{
    internal class CrearAutomovilHandler : IRequestCommandHandler<CrearAutomovilCommand, string>
    {
        
        private readonly ICommandQueryBus _domainBus;
        private readonly IAutomovilRepository _automovilRepository;
        private readonly IAutomovilApplicationService _automovilApplicationService;

        public CrearAutomovilHandler(
        ICommandQueryBus domainBus,
        IAutomovilRepository automovilRepository,
        IAutomovilApplicationService automovilApplicationService)
        {
            _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
            _automovilRepository = automovilRepository ?? throw new
            ArgumentNullException(nameof(automovilRepository));
            _automovilApplicationService = automovilApplicationService ?? throw new
            ArgumentNullException(nameof(automovilApplicationService));
        }

        public async Task<string> Handle(CrearAutomovilCommand request, CancellationToken
        cancellationToken)
        {

            var validationErrors = new List<string>();

           
            void ValidateStringField(string value, string fieldName)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    validationErrors.Add($"El campo {fieldName} no puede ser nulo o estar vacío.");
                }
                
                else if (value.Equals("string", StringComparison.OrdinalIgnoreCase))
                {
                    validationErrors.Add($"El campo {fieldName} no puede tener el valor literal 'string'.");
                }
            }

           
            ValidateStringField(request.Marca, "Marca");
            ValidateStringField(request.Modelo, "Modelo");
            ValidateStringField(request.Color, "Color");
            ValidateStringField(request.NumeroMotor, "Número de Motor");
            ValidateStringField(request.NumeroChasis, "Número de Chasis");

            
            if (validationErrors.Any())
            {
                
                throw new InvalidEntityDataException(string.Join(Environment.NewLine, validationErrors));
            }
            


            var entity = new Domain.Entities.Automovil(
            request.Marca,
            request.Modelo,
            request.Color,
            request.Fabricacion,
            request.NumeroMotor,
            request.NumeroChasis
            );

            
            if (!entity.IsValid) throw new InvalidEntityDataException(entity.GetErrors());
            if (_automovilApplicationService.AutomovilExist(entity.NumeroChasis)) throw new
            EntityDoesExistException();

            
            try
            {
                object createdId = await _automovilRepository.AddAsync(entity);
                await _domainBus.Publish(entity.To<AutomovilCreado>(), cancellationToken);
                return createdId.ToString(); 
            }
            catch (Exception ex)
            {
                throw new BussinessException(ApplicationConstants.PROCESS_EXECUTION_EXCEPTION,
                ex.InnerException);
            }
        }
    }
}
