using System;

namespace GildedRose.Console.Updaters
{
    /// <summary>
    /// Updates a Backstage Pass item.
    /// Quality increases as the concert date approaches:
    /// - More than 10 days: +1
    /// - 10 days or less: +2
    /// - 5 days or less: +3
    /// After the concert (sell date <= 0), quality drops to 0.
    /// Quality is capped at a maximum value of 50.
    /// </summary>
    public class BackstagePassUpdater : IItemUpdater
    {
        private const int MaxQuality = 50;

        public void Update(Item item)
        {
            // Once the concert has passed, the value drops to zero
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            else
            {
                // Base increase as the event approaches
                int increase = 1;

                // Increase faster as sell date gets closer
                if (item.SellIn <= 10) increase++;
                if (item.SellIn <= 5)  increase++;

                // Ensure quality does not exceed the maximum allowed value
                item.Quality = Math.Min(MaxQuality, item.Quality + increase);
            }

            // Decrease sell-in after updating quality
            item.SellIn--;
        }
    }
}