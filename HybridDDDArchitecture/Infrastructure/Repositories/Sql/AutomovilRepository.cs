using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Infraestructure.Repositories.Sql;
using Application.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories.Sql
{
    internal class AutomovilRepository : BaseRepository<Automovil>, IAutomovilRepository
    {

        public AutomovilRepository(StoreDbContext context) : base(context) { }


        public async Task<Automovil> FindByIdAsync(int id)
        {

            return await base.FindOneAsync(new object[] { id });

        }

        public async Task<Automovil> FindByChasisAsync(string chasis)
        {

            string chasisLowerCase = chasis.ToLower();

            return await Query()
                         .Where(a => a.NumeroChasis.ToLower() == chasisLowerCase)
                         .FirstOrDefaultAsync();
        }
        public void Remove(Domain.Entities.Automovil entity)
        {

            base.Context.Set<Automovil>().Remove(entity);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           
            return await base.Context.SaveChangesAsync(cancellationToken);
        }
    }
}