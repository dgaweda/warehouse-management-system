using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Extensions;
using DataAccess.Seeders.Data;
using FluentAssertions;
using WMSTest;
using Xunit;
using Xunit.Abstractions;

namespace WMS.DataAccess.Test.Extensions
{
    public class DeliveryExtensionTests
    {
        private readonly ITestOutputHelper _outputHelper;
        
        public DeliveryExtensionTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        
        [Theory]
        [ClassData(typeof(DeliveryExtensionTestsData))]
        public void FilterByName_ForAllDummyDeliveries_ReturnsFilteredValues(List<Delivery> deliveries, List<Delivery> expected, string filterName)
        {
            _outputHelper.GetTestDataInfo(deliveries, expected);
            _outputHelper.GetUsedValueInfo(filterName);
            var data = deliveries.AsQueryable();
            var result = data.FilterByName(filterName).ToList();
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [ClassData(typeof(SetDeliveryNumberTestData))]
        public void SetDeliveryNumber_ForAllDummyDeliveries_ReturnsCorrectDeliveryNumber(List<Delivery> deliveries, Delivery delivery, int expected)
        {
            var result = delivery.SetDeliveryNumber(deliveries);
            result.Should().Be(expected);
        }
    }
}