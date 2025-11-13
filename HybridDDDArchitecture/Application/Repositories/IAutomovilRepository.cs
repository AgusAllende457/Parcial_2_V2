using Core.Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IAutomovilRepository : IRepository<Automovil> 
    {

        Task<Automovil> FindByIdAsync(int id);

        Task<Automovil> FindByChasisAsync(string chasis);



        void Remove(Domain.Entities.Automovil entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}

