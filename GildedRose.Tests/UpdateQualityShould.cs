using GildedRose.Console;

namespace GildedRose.Tests
{
    public class UpdateQualityShould
    {
        [Fact]
        public void RunWithoutError_GivenEmptyCollection()
        {
            var statusUpdater = new InventoryStatusUpdater();

            statusUpdater.UpdateQuality(new List<Item>());
        }
    }
}