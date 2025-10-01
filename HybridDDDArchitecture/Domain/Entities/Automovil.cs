using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Validators;

namespace Domain.Entities
{
    public class Automovil : DomainEntity<int, AutomovilValidator>
    {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Color { get; private set; }
        public int Fabricacion { get; private set; }
        public string NumeroMotor { get; private set; }
        public string NumeroChasis { get; private set; }
        protected Automovil()
        {
        }
        public Automovil(string marca, string modelo, string color, int fabricacion,
       string numeroMotor, string numeroChasis)
        {
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Fabricacion = fabricacion;
            NumeroMotor = numeroMotor;
            NumeroChasis = GenerarNumeroChasis(modelo, color);
        }
        private string GenerarNumeroChasis(string modelo, string color)
        {
            var sufijo = Guid.NewGuid().ToString("N").Substring(0, 6);
            return $"CHS-{modelo.Substring(0, 3).ToUpper()}-{color.Substring(0, 3).ToUpper()}-{DateTime.Now:yyyyMMddHHmmss}-{sufijo}";
        }
    }

}