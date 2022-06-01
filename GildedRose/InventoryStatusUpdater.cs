namespace GildedRose.Console
{
    public class InventoryStatusUpdater
    {
        private const string BackstagePassItemName = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrieItemName = "Aged Brie";
        private const string SulfurasItemName = "Sulfuras, Hand of Ragnaros";
        private const string ConjuredItemPrefix = "Conjured";

        public void UpdateQuality(IList<Item> items)
        {
            foreach (Item item in items)
            {
                UpdateItemQuality(item);

                UpdateSellIn(item);
            }
        }

        private static void UpdateItemQuality(Item item)
        {
            if (item.Name != AgedBrieItemName && item.Name != BackstagePassItemName)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != SulfurasItemName)
                    {
                        item.Quality--;
                        if (item.Name.StartsWith(ConjuredItemPrefix) && item.Quality > 0)
                        {
                            item.Quality -= 1;
                        }
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality++;

                    if (item.Name == BackstagePassItemName)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality++;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality++;
                            }
                        }
                    }
                }
            }
        }

        private static void UpdateSellIn(Item item)
        {
            if (item.Name != SulfurasItemName)
            {
                item.SellIn--;
            }
            HandleIfExpired(item);
        }

        private static void HandleIfExpired(Item item)
        {
            if (item.SellIn < 0)
            {
                HandleExpired(item);
            }
        }

        private static void HandleExpired(Item item)
        {
            if (item.Name != AgedBrieItemName)
            {
                if (item.Name != BackstagePassItemName)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != SulfurasItemName)
                        {
                            item.Quality--;
                            if (item.Name.StartsWith(ConjuredItemPrefix) && item.Quality > 0)
                            {
                                item.Quality -= 1;
                            }
                        }
                    }
                }
                else
                {
                    item.Quality -= item.Quality;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }
        }
    }
}