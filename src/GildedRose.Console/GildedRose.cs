using System.Collections.Generic;

namespace GildedRose.Console
{
    public class GildedRoseService
    {
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
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                UpdateSulfuras(item);
                return;
            }

            if (item.Name == "Aged Brie")
            {
                UpdateAgedBrie(item);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateBackstage(item);
            }
            else
            {
                UpdateNormalItem(item);
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                UpdateExpiredItem(item);
            }
        }

        //  ITEM-SPECIFIC METHODS

        private void UpdateNormalItem(Item item)
        {
            DecreaseQuality(item);
        }

        private void UpdateAgedBrie(Item item)
        {
            IncreaseQuality(item);
        }

        private void UpdateBackstage(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn < 11)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 6)
            {
                IncreaseQuality(item);
            }
        }

        private void UpdateSulfuras(Item item)
        {
            // Do nothing
        }

        private void UpdateExpiredItem(Item item)
        {
            if (item.Name == "Aged Brie")
            {
                IncreaseQuality(item);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = 0;
            }
            else if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                DecreaseQuality(item);
            }
        }

        //  HELPER METHODS

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
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