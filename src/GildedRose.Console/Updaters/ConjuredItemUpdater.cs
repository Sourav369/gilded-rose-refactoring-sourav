namespace GildedRose.Console.Updaters
{
    public class ConjuredItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            // Degrade twice as fast as normal
            int degrade = 2;

            if (item.SellIn <= 0)
            {
                degrade = 4;
            }

            item.Quality = System.Math.Max(0, item.Quality - degrade);

            item.SellIn--;
        }
    }
}