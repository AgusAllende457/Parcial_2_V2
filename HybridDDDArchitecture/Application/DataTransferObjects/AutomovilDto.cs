
namespace Application.DataTransferObjects;

public class AutomovilDto
{
    // El ID debe ser un int, ya que así está en tu entidad Automovil
    public int Id { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Color { get; set; }
    public int Fabricacion { get; set; }
    public string NumeroMotor { get; set; }
    public string NumeroChasis { get; set; }
    // ... otras propiedades
}