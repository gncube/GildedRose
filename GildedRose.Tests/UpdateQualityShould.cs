using GildedRose.Console;

namespace GildedRose.Tests
{
    public class UpdateQualityShould_GivenNormalItem
    {

        [Fact]
        public void RunWithoutError()
        {
            var statusUpdater = new InventoryStatusUpdater();

            statusUpdater.UpdateQuality(new List<Item>());
        }

        [Fact]
        public void LowerQuality()
        {
            var statusUpdater = new InventoryStatusUpdater();


            var normalItem = new Item { Name = "Normal Normal", Quality = 20, SellIn = 10 };
            var expectedQuality = normalItem.Quality - 1;
            var items = new List<Item> { normalItem };
            statusUpdater.UpdateQuality(items);

            Assert.Equal(expectedQuality, normalItem.Quality);
        }

        [Fact]
        public void LowerSellIn()
        {
            var statusUpdater = new InventoryStatusUpdater();

            var normalItem = new Item { Name = "Normal Normal", Quality = 20, SellIn = 10 };
            var expectedSellIn = normalItem.SellIn - 1;
            var items = new List<Item> { normalItem };
            statusUpdater.UpdateQuality(items);

            Assert.Equal(expectedSellIn, normalItem.SellIn);
        }

        [Fact]
        public void FloorQualityAtZero()
        {
            var statusUpdater = new InventoryStatusUpdater();
            var normalItem = new Item { Name = "Normal Normal", Quality = 1, SellIn = 10 };
            var expectedResult = 0;
            var items = new List<Item> { normalItem };

            statusUpdater.UpdateQuality(items);
            statusUpdater.UpdateQuality(items);

            Assert.Equal(expectedResult, normalItem.Quality);
        }

        [Fact]
        public void AllowNegativeSellIn()
        {
            var statusUpdater = new InventoryStatusUpdater();
            var normalItem = new Item { Name = "Normal Normal", Quality = 50, SellIn = 1 };
            var expectedResult = -1;
            var items = new List<Item> { normalItem };

            statusUpdater.UpdateQuality(items);
            statusUpdater.UpdateQuality(items);

            Assert.Equal(expectedResult, normalItem.SellIn);
        }

        [Fact]
        public void DecreaseQualityTwiceAsFast_AfterSellInReachesZero()
        {
            var statusUpdater = new InventoryStatusUpdater();
            var normalItem = new Item { Name = "Normal Normal", Quality = 50, SellIn = 1 };
            var expectedResult = 45;
            var items = new List<Item> { normalItem };

            statusUpdater.UpdateQuality(items); // -1
            statusUpdater.UpdateQuality(items); // -2
            statusUpdater.UpdateQuality(items); // -2

            Assert.Equal(expectedResult, normalItem.Quality);
        }
    }
}