using System;

namespace GildedRose.Console.Updaters
{
    /// <summary>
    /// Updates a Conjured item, which degrades in quality twice as fast as a normal item.
    /// </summary>
    public class ConjuredItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            // Determine degradation rate based on whether the sell date has passed
            int degrade = item.SellIn <= 0 ? 4 : 2;

            // Reduce quality while ensuring it does not drop below zero
            item.Quality = Math.Max(0, item.Quality - degrade);

            // Decrease sell-in after updating quality
            item.SellIn--;
        }
    }
}