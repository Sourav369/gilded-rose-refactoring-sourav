namespace GildedRose.Console.Updaters
{
    /// <summary>
    /// Updates a Sulfuras item.
    /// Sulfuras is a legendary item:
    /// - Quality remains constant (always 80)
    /// - Sell-in value does not decrease
    /// </summary>
    public class SulfurasUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            // Sulfuras is a legendary item — quality and sell-in never change
        }
    }
}