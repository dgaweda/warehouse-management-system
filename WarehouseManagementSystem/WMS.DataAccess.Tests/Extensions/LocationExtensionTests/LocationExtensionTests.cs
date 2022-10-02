using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Exceptions;
using DataAccess.Extensions;
using DataAccess.Seeders.Data;
using FluentAssertions;
using Xunit;

namespace WMS.DataAccess.Test.Extensions.LocationExtensionTests
{
    public class LocationExtensionTests
    {
        public static IEnumerable<object[]> AddProductAmountTestData()
        {
            yield return new object[]
            {
                new Location()
                {
                    ProductId = new Guid(),
                    CurrentAmount = 50,
                    MaxAmount = 100
                },
                new Location()
                {
                    ProductId = null,
                    CurrentAmount = 0,
                    MaxAmount = 100
                },
                50
            };
            
            yield return new object[]
            {
                new Location()
                {
                    ProductId = new Guid(),
                    CurrentAmount = 50,
                    MaxAmount = 100
                },
                new Location()
                {
                    ProductId = null,
                    CurrentAmount = 25,
                    MaxAmount = 100
                },
                75
            };
        }

        [Fact]
        public void SetName_ForEmptyName_UnchangedLocation()
        {
            var locationFromRequest = new Location();
            var locationToEdit = new Location();
            
            locationToEdit.SetName(locationFromRequest);
            locationToEdit.Name.Should().BeNull();
        }
        
        [Fact]
        public void SetName_ForSpecifiedName_UnchangedLocation()
        {
            var locationFromRequest = DummyLocation.GetDummyLocations().First();
            var locationToEdit = new Location();
            
            locationToEdit.SetName(locationFromRequest);
            locationToEdit.Name.Should().Be("A-02-05");
        }

        [Fact]
        public void SetProductAmount_ForAmountHigherThanMaxAmount_OutOfRangeException()
        {
            var locationFromRequest = new Location()
            {
                ProductId = new Guid(),
                CurrentAmount = 150,
                MaxAmount = 100
            };
            var locationToEdit = new Location()
            {
                ProductId = null,
                CurrentAmount = 0,
                MaxAmount = 100
            };
            
            locationToEdit.Invoking(x => x.AddProductAmount(locationFromRequest))
                .Should()
                .Throw<OutOfRangeException>()
                .WithMessage("Amount can't be higher than Max Amount of the location.");
        }
        
        [Theory]
        [MemberData(nameof(AddProductAmountTestData))]
        public void AddProductAmount_ForProperAmount_CorrectLocation(Location locationFromRequest, Location locationToEdit, int expectedAmount)
        {
            locationToEdit.AddProductAmount(locationFromRequest);

            locationToEdit.ProductId.Should().Be(locationFromRequest.ProductId);
            locationToEdit.CurrentAmount.Should().Be(expectedAmount);
        }

        [Fact]
        public void FilterByName_ForNoFilterName_AllDummyLocations()
        {
            var locations = DummyLocation.GetDummyLocations().AsQueryable();

            var result = locations.FilterByName("");

            result.Should().BeEquivalentTo(locations);
        }
    }
}