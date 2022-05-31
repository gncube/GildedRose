using GildedRose.Console;

namespace GildedRose.Tests
{
    public class UpdateQualityShould
    {
        [Fact]
        public void RunWithoutError_GivenEmptyCollection()
        {
            var statusUpdater = new InventorStatusUpdater();

            statusUpdater.UpdateQuality(new List<Item>());
        }
    }
}