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

        [Fact]
        public void LowerQuality_GivenNormalItem()
        {
            var statusUpdater = new InventoryStatusUpdater();


            var normalItem = new Item { Name = "Normal Normal", Quality = 20, SellIn = 10 };
            var expectedQuality = normalItem.Quality - 1;
            var items = new List<Item> { normalItem };
            statusUpdater.UpdateQuality(items);

            Assert.Equal(expectedQuality, normalItem.Quality);

        }
    }
}