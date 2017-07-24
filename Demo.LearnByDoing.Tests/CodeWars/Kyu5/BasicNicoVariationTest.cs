using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
    public class BasicNicoVariationTest : BaseTest
    {
        public BasicNicoVariationTest(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("crazy", "secretinformation", "cseerntiofarmit on  ")]
        [InlineData("abc", "abcd", "abcd  ")]
        [InlineData("ba", "1234567890", "2143658709")]
        [InlineData("a", "message", "message")]
        [InlineData("key", "key", "eky")]
        public void TestSampleNico(string key, string message, string expected)
        {
            string actual = Kata.Nico(key, message);
            Assert.Equal(expected, actual);
        }
    }
    
    public partial class Kata 
    {
        public static string Nico(string key, string message) 
        {
            return message;
        }
    }
}