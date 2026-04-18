namespace GildedRose.Console.Updaters
{
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