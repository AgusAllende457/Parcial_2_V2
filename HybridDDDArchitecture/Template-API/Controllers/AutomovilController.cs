using Application.UseCases.Automovil.Commands.CreateAutomovil;
using Application.UseCases.Automovil.Commands.DeleteAutomovil;
using Application.UseCases.Automovil.Commands.UpdateAutomovil;
using Application.UseCases.Automovil.Queries.GetAllAutomoviles;
using Application.UseCases.Automovil.Queries.GetAutomovilByChasis;
using Application.UseCases.Automovil.Queries.GetAutomovilById;
using Application.UseCases.DummyEntity.Commands.DeleteDummyEntity;
using Application.UseCases.DummyEntity.Commands.UpdateDummyEntity;
using Application.UseCases.DummyEntity.Queries.GetAllDummyEntities;
using Application.UseCases.DummyEntity.Queries.GetDummyEntityBy;
using Core.Application;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    public class AutomovilController : BaseController
    {
        private readonly ICommandQueryBus _commandQueryBus;
        public AutomovilController(ICommandQueryBus commandQueryBus)
        {
            _commandQueryBus = commandQueryBus ?? throw new
           ArgumentNullException(nameof(commandQueryBus));
        }
        [HttpPost("api/v1/[controller]")]
        public async Task<IActionResult> Create(CrearAutomovilCommand command)
        {
            if (command is null) return BadRequest();
            var id = await _commandQueryBus.Send(command);
            return Created($"api/v1/[controller]/{id}", new { Id = id });
        }
        [HttpDelete("api/v1/[Controller]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            await _commandQueryBus.Send(new DeleteAutomovilCommand { AutomovilId = id });

            return NoContent();
        }

        [HttpPut("api/v1/[controller]/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAutomovilCommand command)
        {

            command.AutomovilId = id;

            bool updated = await _commandQueryBus.Send(command);

            if (!updated)
                return NotFound(); 

            return NoContent(); 
        }

       [HttpGet("api/v1/[Controller]")]

            public async Task<IActionResult> GetAll()
            {
                // 1. Crear la instancia del Query sin parámetros
                var query = new GetAllAutomovilesQuery();

                // 2. Enviar el Query al Bus. El resultado es la lista directa (IList<AutomovilDto>).
                var entities = await _commandQueryBus.Send(query);

                // 3. Retornar el resultado HTTP 200 con la lista
                return Ok(entities);
            }

        [HttpGet("api/v1/[Controller]/{id}")]
      
        public async Task<IActionResult> GetById(int id)
        {
           
            if (id <= 0) return BadRequest("El ID del automóvil debe ser un valor positivo.");


            var automovilDto = await _commandQueryBus.Send(new GetAutomovilByIdQuery { AutomovilId = id });

            return Ok(automovilDto);
        }

        [HttpGet("api/v1/[Controller]/chasis/{chasis}")]
        public async Task<IActionResult> GetByChasis(string chasis)
        {
            if (string.IsNullOrEmpty(chasis)) return BadRequest("El número de chasis es requerido.");

            var entity = await _commandQueryBus.Send(new GetAutomovilByChasisQuery { NumeroChasis = chasis });

            return Ok(entity);
        }

    }
}

