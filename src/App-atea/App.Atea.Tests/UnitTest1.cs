using Atea.Helpers;

namespace App.Atea.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void When_Null_IsPassed_ShouldReturn_False()
        {
            var result = StringExtensions.ValidateIntegerValues(null!);
            Assert.IsFalse(result, "Passing null");
        }

        [TestMethod]
        public void When_Empty_IsPassed_ShouldReturn_False()
        {
            var values = new string[] { };
            var result = StringExtensions.ValidateIntegerValues(values);
            Assert.IsFalse(result, "Passing an empty array");
        }

        [TestMethod]
        [DataRow(new[] { "1" }, true)]
        [DataRow(new[] { "1", "1", "1" }, true)]
        [DataRow(new[] { "a", "1" }, false)]
        public void When_IntegerValues_ArePassed_ShouldReturn_True(string[] values, bool expected)
        {
            var result = StringExtensions.ValidateIntegerValues(values);
            Assert.AreEqual(expected, result, $"Passing values: {string.Concat(",", values)}");
        }
        [TestMethod]
        [DataRow(new[] { "1" }, 1)]
        [DataRow(new[] { "1", "1" }, 2)]
        [DataRow(new[] { "1", "1", "2" }, 4)]
        [DataRow(new[] { "1", "0" }, 1)]
        [DataRow(new[] { "0", "0" }, 0)]
        [DataRow(new[] { "0", "-3" }, -3)]
        public void When_Values_Are_Passed_ShouldReturn_Values(string[] values, int expected)
        {
            var result = values.Add();
            Assert.AreEqual(expected, result, $"Adding up values {string.Concat(",", values)}");
        }

        [TestMethod]
        public void When_NonValidIntegers_ShouldRaise_ArgumentOutOfRangeException()
        {
            var values = new[] { "a", "1" };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => values.Add());
        }
    }
}