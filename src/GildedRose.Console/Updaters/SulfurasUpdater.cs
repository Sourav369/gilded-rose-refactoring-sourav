namespace GildedRose.Console.Updaters
{
    /// <summary>
    /// Updates a Sulfuras item. As a legendary item, its quality and sell-in never change.
    /// </summary>
    public class SulfurasUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            // Sulfuras is a legendary item — quality and sell-in never change
        }
    }
}