using System;

namespace GildedRose.Console.Updaters
{
    /// <summary>
    /// Updates a Backstage Pass item, increasing quality as the concert date approaches.
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