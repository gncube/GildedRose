using GildedRose.Console;

namespace GildedRose.Tests
{
    public class UpdateQualityShould
    {
        [Fact]
        public void RunWithoutError_GivenEmptyCollection()
        {
            var noNameYet = new NoNameYet();

            noNameYet.UpdateQuality(new List<Item>());
        }
    }
}