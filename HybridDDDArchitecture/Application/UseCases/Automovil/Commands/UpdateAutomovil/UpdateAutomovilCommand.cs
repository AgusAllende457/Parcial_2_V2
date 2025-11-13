using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Application.UseCases.Automovil.Commands.UpdateAutomovil
{
    public class UpdateAutomovilCommand : IRequestCommand<bool>
    {
        [JsonIgnore]
        public int AutomovilId { get; set; } 

        public string? Color { get; set; }
        public string? NumeroMotor { get; set; }

        public UpdateAutomovilCommand() { }
    }
}