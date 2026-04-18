using System.Collections.Generic;
using GildedRose.Console.Updaters;

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
            foreach (Item item in _items)
            {
                IItemUpdater updater = GetUpdater(item);
                updater.Update(item);
            }
        }

        private IItemUpdater GetUpdater(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieUpdater();

                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassUpdater();

                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasUpdater();

                default:
                    return new NormalItemUpdater();
            }
        }
    }
}