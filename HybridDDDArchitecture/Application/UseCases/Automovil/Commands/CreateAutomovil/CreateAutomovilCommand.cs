using Core.Application;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; 

namespace Application.UseCases.Automovil.Commands.CreateAutomovil
{

    public class CrearAutomovilCommand : IRequestCommand<string>
    {
       
     [DefaultValue("")]
        public string Marca { get; set; }

      [DefaultValue("")]
        public string Modelo { get; set; }

       
        [Required(ErrorMessage = "El color es requerido.")]
        [RegularExpression(@"^(?!string$|STRING$|String$).*$", ErrorMessage = "El valor 'string' no está permitido.")]

     [DefaultValue("")]
        public string Color { get; set; }

     [DefaultValue("")]
        public int Fabricacion { get; set; } 

        [Required(ErrorMessage = "El número de motor es requerido.")]
        [RegularExpression(@"^(?!string$|STRING$|String$).*$", ErrorMessage = "El valor 'string' no está permitido.")]
     [DefaultValue("")]
        public string NumeroMotor { get; set; }

        [Required(ErrorMessage = "El número de chasis es requerido.")]
        [RegularExpression(@"^(?!string$|STRING$|String$).*$", ErrorMessage = "El valor 'string' no está permitido.")]
     [DefaultValue("")]
        public string NumeroChasis { get; set; }
    }
}
