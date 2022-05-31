using GildedRose.Console;

namespace GildedRose.Tests.InventoryStatusUpdaterTests
{
    public class UpdateQuality_GivenNormalItemShould
    {
        private readonly InventoryStatusUpdater _statusUpdater;

        public UpdateQuality_GivenNormalItemShould()
        {
            _statusUpdater = new InventoryStatusUpdater();
        }

        [Fact]
        public void RunWithoutError()
        {
            _statusUpdater.UpdateQuality(new List<Item>());
        }

        [Fact]
        public void LowerQualityByOne()
        {
            var normalItem = new Item { Name = "Normal Normal", Quality = 20, SellIn = 10 };
            var expectedQuality = normalItem.Quality - 1;
            var items = new List<Item> { normalItem };
            _statusUpdater.UpdateQuality(items);

            Assert.Equal(expectedQuality, normalItem.Quality);
        }

        [Fact]
        public void LowerSellInByOne()
        {
            var normalItem = new Item { Name = "Normal Normal", Quality = 20, SellIn = 10 };
            var expectedSellIn = normalItem.SellIn - 1;
            var items = new List<Item> { normalItem };
            _statusUpdater.UpdateQuality(items);

            Assert.Equal(expectedSellIn, normalItem.SellIn);
        }

        [Fact]
        public void FloorQualityAtZero()
        {
            var normalItem = new Item { Name = "Normal Normal", Quality = 1, SellIn = 10 };
            var expectedResult = 0;
            var items = new List<Item> { normalItem };

            _statusUpdater.UpdateQuality(items);
            _statusUpdater.UpdateQuality(items);

            Assert.Equal(expectedResult, normalItem.Quality);
        }

        [Fact]
        public void AllowNegativeSellIn()
        {
            var normalItem = new Item { Name = "Normal Normal", Quality = 50, SellIn = 1 };
            var expectedResult = -1;
            var items = new List<Item> { normalItem };

            _statusUpdater.UpdateQuality(items);
            _statusUpdater.UpdateQuality(items);

            Assert.Equal(expectedResult, normalItem.SellIn);
        }

        [Fact]
        public void DecreaseQualityByTwo_AfterSellInReachesZero()
        {
            var normalItem = new Item { Name = "Normal Normal", Quality = 50, SellIn = 1 };
            var expectedResult = 45;
            var items = new List<Item> { normalItem };

            _statusUpdater.UpdateQuality(items); // -1
            _statusUpdater.UpdateQuality(items); // -2
            _statusUpdater.UpdateQuality(items); // -2

            Assert.Equal(expectedResult, normalItem.Quality);
        }
    }
}