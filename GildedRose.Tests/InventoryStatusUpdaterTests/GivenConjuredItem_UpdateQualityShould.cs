using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Tests.InventoryStatusUpdaterTests
{
    public class GivenConjuredItem_UpdateQualityShould
    {
        private readonly InventoryStatusUpdater _statusUpdater;

        public GivenConjuredItem_UpdateQualityShould()
        {
            _statusUpdater = new InventoryStatusUpdater();
        }

        [Fact]
        public void ReduceQualityByTwo()
        {
            var conjuredItem = new Item { Name = "Conjured Sword", Quality = 20, SellIn = 10 };
            var items = new List<Item> { conjuredItem };
            var expectedResult = 18;

            _statusUpdater.UpdateQuality(items);

            Assert.Equal(expectedResult, conjuredItem.Quality);
        }

        [Fact]
        public void ReduceQualityByFour_AfterSellInReachesZero()
        {
            var conjuredItem = new Item { Name = "Conjured Sword", Quality = 20, SellIn = 1 };
            var items = new List<Item> { conjuredItem };
            var expectedResult = 10;

            _statusUpdater.UpdateQuality(items); // -2
            _statusUpdater.UpdateQuality(items); // -4
            _statusUpdater.UpdateQuality(items); // -4

            Assert.Equal(expectedResult, conjuredItem.Quality);
        }

        [Fact]
        public void FloorQualityAtZero_GivenSellInRemains()
        {
            var conjuredItem = new Item { Name = "Conjured Sword", Quality = 1, SellIn = 10 };
            var items = new List<Item> { conjuredItem };
            var expectedResult = 0;

            _statusUpdater.UpdateQuality(items); // -2

            Assert.Equal(expectedResult, conjuredItem.Quality);
        }

        [Fact]
        public void FloorQualityAtZero_GivenSellInZero()
        {
            var conjuredItem = new Item { Name = "Conjured Sword", Quality = 3, SellIn = 0 };
            var items = new List<Item> { conjuredItem };
            var expectedResult = 0;

            _statusUpdater.UpdateQuality(items); // -2

            Assert.Equal(expectedResult, conjuredItem.Quality);
        }
    }
}
