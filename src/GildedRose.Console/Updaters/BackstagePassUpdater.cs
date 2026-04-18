namespace GildedRose.Console.Updaters
{
    public class BackstagePassUpdater : IItemUpdater
    {
        private const int MaxQuality = 50;

        public void Update(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            else
            {
                if (item.Quality < MaxQuality)
                    item.Quality++;

                if (item.SellIn <= 10 && item.Quality < MaxQuality)
                    item.Quality++;

                if (item.SellIn <= 5 && item.Quality < MaxQuality)
                    item.Quality++;
            }

            item.SellIn--;
        }
    }
}