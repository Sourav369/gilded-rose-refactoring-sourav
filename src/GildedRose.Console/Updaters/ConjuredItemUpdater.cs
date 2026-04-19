using System;

namespace GildedRose.Console.Updaters
{
    public class ConjuredItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            int degrade = item.SellIn <= 0 ? 4 : 2;

            item.Quality = Math.Max(0, item.Quality - degrade);

            item.SellIn--;
        }
    }
}