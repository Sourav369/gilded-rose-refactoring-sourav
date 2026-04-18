using System.Collections.Generic;

namespace GildedRose.Console
{
    public class GildedRoseService
    {
        private const int MaxQuality = 50;
        private const string AgedBrie = "Aged Brie";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";

        private readonly IList<Item> _items;

        public GildedRoseService(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                UpdateItem(item);
            }
        }

        private void UpdateItem(Item item)
        {
            if (item.Name == Sulfuras)
                return;

            if (item.Name == AgedBrie)
                UpdateAgedBrie(item);
            else if (item.Name == BackstagePass)
                UpdateBackstagePass(item);
            else
                UpdateNormalItem(item);

            item.SellIn--;
        }

        //  ITEM-SPECIFIC METHODS (CLEANED)

        private void UpdateNormalItem(Item item)
        {
            DecreaseQuality(item);

            if (item.SellIn <= 0)
            {
                DecreaseQuality(item);
            }
        }

        private void UpdateAgedBrie(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn <= 0)
            {
                IncreaseQuality(item);
            }
        }

        private void UpdateBackstagePass(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
                return;
            }

            IncreaseQuality(item);

            if (item.SellIn <= 10)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn <= 5)
            {
                IncreaseQuality(item);
            }
        }

        //  HELPER METHODS

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;
            }
        }

        private void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}