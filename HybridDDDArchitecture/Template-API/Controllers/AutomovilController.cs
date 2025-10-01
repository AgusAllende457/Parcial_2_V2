using Application.UseCases.Automovil.Commands.CreateAutomovil;
using Application.UseCases.Automovil.Commands.DeleteAutomovil;
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
    }
}
