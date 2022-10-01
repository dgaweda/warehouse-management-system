using System.Collections;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace WMSTest
{
    public static class TestOutputHelperExtension
    {
        public static void GetTestDataInfo<T>(this ITestOutputHelper outputHelper, IEnumerable<T> source, IEnumerable<T> expected)
        {
            outputHelper.WriteLine("----------------------------INPUT----------------------------------");
            outputHelper.WriteLine($"{source.ToString<T>()}");
            outputHelper.WriteLine("-------------------------- EXPECTED--------------------------------");
            outputHelper.WriteLine($"{expected.ToString<T>()}");
            outputHelper.WriteLine("-------------------------------------------------------------------");
        }

        public static void GetUsedValueInfo(this ITestOutputHelper outputHelper, string value)
        {
            outputHelper.WriteLine($"Value used in test: {value}");
            outputHelper.WriteLine("---------------------------------------------------------------");
        }
    }
}