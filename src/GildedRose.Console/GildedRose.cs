using System.Collections.Generic;
using GildedRose.Console.Updaters;

namespace GildedRose.Console
{
    public class GildedRoseService
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

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
            if (!string.IsNullOrEmpty(item.Name) && item.Name.Contains("Conjured"))
            {
                return new ConjuredItemUpdater();
            }

            switch (item.Name)
            {
                case AgedBrie:
                    return new AgedBrieUpdater();

                case BackstagePass:
                    return new BackstagePassUpdater();

                case Sulfuras:
                    return new SulfurasUpdater();

                default:
                    return new NormalItemUpdater();
            }
        }
    }
}