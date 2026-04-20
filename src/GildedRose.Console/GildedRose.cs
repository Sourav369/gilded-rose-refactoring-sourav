using System;
using System.Collections.Generic;
using GildedRose.Console.Updaters;

namespace GildedRose.Console
{
    /// <summary>
    /// Core service responsible for updating the quality and sell-in values of items.
    /// Delegates update logic to specific item updaters using a strategy-based approach.
    /// </summary>
    public class GildedRoseService
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        private readonly IList<Item> _items;

        /// <summary>
        /// Initializes the service with a collection of items.
        /// Throws an exception if the input collection is null to ensure safe usage.
        /// </summary>
        public GildedRoseService(IList<Item> items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Iterates through all items and updates their state using the appropriate updater.
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
        /// Determines the correct updater for a given item based on its name.
        /// Uses a strategy pattern to map item types to their corresponding update logic.
        /// </summary>
        private IItemUpdater GetUpdater(Item item)
        {
            // Handle Conjured items separately as they degrade faster
            if (!string.IsNullOrEmpty(item.Name) && item.Name.Contains("Conjured"))
            {
                return new ConjuredItemUpdater();
            }

            // Select updater based on known item types
            switch (item.Name)
            {
                case AgedBrie:
                    return new AgedBrieUpdater();

                case BackstagePass:
                    return new BackstagePassUpdater();

                case Sulfuras:
                    return new SulfurasUpdater();

                // Default behavior for normal items
                default:
                    return new NormalItemUpdater();
            }
        }
    }
}