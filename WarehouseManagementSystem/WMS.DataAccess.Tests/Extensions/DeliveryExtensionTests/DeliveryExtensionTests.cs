using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Exceptions;
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
        public void FilterByName_ForAllDummyDeliveries_FilteredValues(List<Delivery> deliveries, List<Delivery> expected, string filterName)
        {
            _outputHelper.GetTestDataInfo(deliveries, expected);
            _outputHelper.GetUsedValueInfo(filterName);
            var data = deliveries.AsQueryable();
            var result = data.FilterByName(filterName).ToList();
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [ClassData(typeof(SetDeliveryNumberTestData))]
        public void SetDeliveryNumber_ForAllDummyDeliveries_CorrectDeliveryNumber(List<Delivery> deliveries, Delivery source, int expected)
        {
            var result = source.SetDeliveryNumber(deliveries);
            result.Should().Be(expected);
        }

        [Theory]
        [ClassData(typeof(SetDeliveryNameTestData))]
        public void SetDeliveryName_ForAllDummyDeliveries_CorrectDeliveryName(int deliveryNumber, Delivery delivery, string expected)
        {
            deliveryNumber.SetDeliveryName(delivery);
            delivery.Name.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SetDeliveryName_ForDefaultDateTime_InvalidDateTimeException()
        {
            var deliveryNumber = 1;
            var delivery = new Delivery()
            {
                Arrival = new DateTime()
            };

            deliveryNumber.Invoking(x => x.SetDeliveryName(delivery))
                .Should()
                .Throw<InvalidDateTimeException>();
        }
    }
}