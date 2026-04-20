using System;
using System.Collections.Generic;
using GildedRose.Console.Updaters;

namespace GildedRose.Console
{
    /// <summary>
    /// Manages the daily update of quality and sell-in values for all inventory items.
    /// </summary>
    public class GildedRoseService
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        private readonly IList<Item> _items;

        /// <summary>
        /// Initializes the service with a collection of items.
        /// </summary>
        public GildedRoseService(IList<Item> items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Updates all items by applying their respective update rules.
        /// </summary>
        public void UpdateQuality()
        {
            foreach (Item item in _items)
            {
                IItemUpdater updater = GetUpdater(item);
                updater.Update(item);
            }
        }

        /// <summary>
        /// Returns the appropriate updater for the given item.
        /// </summary>
        private IItemUpdater GetUpdater(Item item)
        {
            // Handle Conjured items separately as they degrade faster
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