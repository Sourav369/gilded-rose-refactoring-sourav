using System;

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
                int increase = 1;
                if (item.SellIn <= 10) increase++;
                if (item.SellIn <= 5)  increase++;
                item.Quality = Math.Min(MaxQuality, item.Quality + increase);
            }

            item.SellIn--;
        }
    }
}