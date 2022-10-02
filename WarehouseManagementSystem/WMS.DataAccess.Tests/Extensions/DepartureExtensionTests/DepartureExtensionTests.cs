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
        [Fact]
        public void SetCloseTime_ForDepartureWithClosedState_CorrectState()
        {
            var departure = DummyDeparture.GetDummyDepartures().Last();
            departure.SetCloseTime();
            departure.CloseTime.GetValueOrDefault().Date.Should().Be(DateTime.Now.Date);
        }
        
        [Fact]
        public void SetCloseTime_ForDepartureWithOpenState_CorrectState()
        {
            var departure = DummyDeparture.GetDummyDepartures().First();
            departure.SetCloseTime();
            departure.CloseTime.Should().Be(null);
        }

        [Fact]
        public void FilterByName_ForSampleFilterName_FilteredDeparture()
        {
            var departures = DummyDeparture.GetDummyDepartures().AsQueryable();
            var expected = departures.FirstOrDefault();
            
            var result = departures.FilterByName("Sample Opened").FirstOrDefault();
            
            result.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void FilterByName_ForEmptyFilterName_FilteredDeparture()
        {
            var departures = DummyDeparture.GetDummyDepartures().AsQueryable();

            var result = departures.FilterByName("");
            
            result.Should().BeEquivalentTo(departures);
        }

        [Fact]
        public void FilterByOpeningTime_ForDefaultDateTime_AllDummyDepartures()
        {
            var departures = DummyDeparture.GetDummyDepartures().AsQueryable();
            var result = departures.FilterByOpeningTime(default);
            result.Should().BeEquivalentTo(departures);
        }
        
        [Fact]
        public void FilterByOpeningTime_ForMinDateTime_AllDummyDepartures()
        {
            var departures = DummyDeparture.GetDummyDepartures().AsQueryable();
            var result = departures.FilterByOpeningTime(DateTime.MinValue);
            result.Should().BeEquivalentTo(departures);
        }
    }
}