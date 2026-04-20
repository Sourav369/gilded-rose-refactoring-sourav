namespace GildedRose.Console.Updaters
{
    /// <summary>
    /// Updates a standard inventory item by degrading its quality over time.
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