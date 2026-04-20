namespace GildedRose.Console.Updaters
{
    /// <summary>
    /// Updates an Aged Brie item.
    /// Aged Brie increases in quality over time:
    /// - Before sell date: +1
    /// - After sell date: +2
    /// Quality is capped at a maximum value of 50.
    /// </summary>
    public class AgedBrieUpdater : IItemUpdater
    {
        private const int MaxQuality = 50;

        public void Update(Item item)
        {
            if (item.Quality < MaxQuality)
                item.Quality++;

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality < MaxQuality)
                item.Quality++;
        }
    }
}