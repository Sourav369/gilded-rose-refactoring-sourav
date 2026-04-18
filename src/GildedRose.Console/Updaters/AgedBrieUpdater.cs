namespace GildedRose.Console.Updaters
{
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