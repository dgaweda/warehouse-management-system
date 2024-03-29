﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Repository.DepartureRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Query.DepartureQueries
{
    public class GetDeparturesQuery : QueryBase<List<Departure>>
    {
        public string Name { get; set; }
        public DateTime OpeningTime { get; set; }
        private readonly IDepartureRepository _departureRepository;

        public GetDeparturesQuery(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public override async Task<List<Departure>> Execute()
        {
            return await _departureRepository.GetAll()
                .FilterByName(Name)
                .FilterByOpeningTime(OpeningTime)
                .ToListAsync();
        }
    }
}
