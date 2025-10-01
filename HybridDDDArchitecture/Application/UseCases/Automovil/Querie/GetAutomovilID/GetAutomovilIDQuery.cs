using Application.DataTransferObjects;
using Core.Application;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Automovil.Queries.GetAutomovilById
{
    public class GetAutomovilByIdQuery : IRequestQuery<AutomovilDto>
    {
        [Required]
 
        public int AutomovilId { get; set; }

        public GetAutomovilByIdQuery()
        {
        }
    }
}