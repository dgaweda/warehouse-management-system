﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.DepartureRepository
{
    public class DepartureRepository : Repository<Departure>, IDepartureRepository
    {
        public DepartureRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Departure>> GetDeparturesByState(StateType state)
        {
            return await GetQueryableEntity()
                .Where(x => x.State == state)
                .ToListAsync();
        }

        public override IQueryable<Departure> GetQueryableEntity()
        {
            return Entity.AsQueryable();
        }
    }
}