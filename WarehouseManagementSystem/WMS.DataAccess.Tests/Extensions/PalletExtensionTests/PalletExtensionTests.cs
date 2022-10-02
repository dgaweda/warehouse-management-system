using DataAccess.Entities;
using DataAccess.Enums;
using DataAccess.Extensions;
using FluentAssertions;
using WMS.DataAccess.Test.Extensions.PalletExtensionTests.TestData;
using Xunit;

namespace WMS.DataAccess.Test.Extensions.PalletExtensionTests
{
    public class PalletExtensionTests
    {
        [Theory]
        [ClassData(typeof(SetStatusTestData))]
        public void SetStatusTest(Pallet source, PalletStatus expected)
        {
            source.SetStatus();
            source.PalletStatus.Should().Be(expected);
        }
    }
}