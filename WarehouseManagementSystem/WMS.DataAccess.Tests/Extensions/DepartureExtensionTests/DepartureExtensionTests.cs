using System;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Seeders.Data;
using FluentAssertions;
using Xunit;

namespace WMS.DataAccess.Test.Extensions.DepartureExtensionTests
{
    public class DepartureExtensionTests
    {
        private readonly IQueryable<Departure> _dummyDepartures;
        public DepartureExtensionTests()
        {
            _dummyDepartures = DummyDeparture.GetDummyDepartures().AsQueryable();
        }
        
        [Fact]
        public void SetCloseTime_ForDepartureWithClosedState_CorrectState()
        {
            var departure = _dummyDepartures.Last();
            departure.SetCloseTime();
            departure.CloseTime.GetValueOrDefault().Date.Should().Be(DateTime.Now.Date);
        }
        
        [Fact]
        public void SetCloseTime_ForDepartureWithOpenState_CorrectState()
        {
            var departure = _dummyDepartures.First();
            
            departure.SetCloseTime();

            departure.CloseTime.Should().BeNull();
        }

        [Fact]
        public void FilterByName_ForSampleFilterName_FilteredDeparture()
        {
            var departures = _dummyDepartures;
            var expected = departures.FirstOrDefault();
            
            var result = departures.FilterByName("Sample Opened").FirstOrDefault();
            
            result.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void FilterByName_ForEmptyFilterName_FilteredDeparture()
        {
            var departures = _dummyDepartures;

            var result = departures.FilterByName("");
            
            result.Should().BeEquivalentTo(departures);
        }

        [Fact]
        public void FilterByOpeningTime_ForDefaultDateTime_AllDummyDepartures()
        {
            var departures = _dummyDepartures;
            
            var result = departures.FilterByOpeningTime(default);
            
            result.Should().BeEquivalentTo(departures);
        }
        
        [Fact]
        public void FilterByOpeningTime_ForMinDateTime_AllDummyDepartures()
        {
            var departures = _dummyDepartures;
            
            var result = departures.FilterByOpeningTime(DateTime.MinValue);
            
            result.Should().BeEquivalentTo(departures);
        }
    }
}