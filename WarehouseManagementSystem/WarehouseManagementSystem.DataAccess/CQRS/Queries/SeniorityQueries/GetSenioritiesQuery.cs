using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.SeniorityQueries
{
    public class GetSenioritiesQuery : QueryBase<List<Seniority>>
    {
        private readonly IGetEntityHelper<Seniority> _seniority;

        public GetSenioritiesQuery(IGetEntityHelper<Seniority> seniority)
        {
            _seniority = seniority;
        }

        public override async Task<List<Seniority>> Execute(WMSDatabaseContext context) => await _seniority.GetFilteredData(context);
    }
}
