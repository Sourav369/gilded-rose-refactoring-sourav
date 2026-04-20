namespace GildedRose.Console.Updaters
{
    /// <summary>
    /// Updates a normal item.
    /// Quality decreases over time:
    /// - Before sell date: -1
    /// - After sell date: -2
    /// Quality is never allowed to go below 0.
    /// </summary>
    public class NormalItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            if (item.Quality > 0)
                item.Quality--;

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality > 0)
                item.Quality--;
        }
    }
}