namespace GildedRose.Console.Updaters
{
    /// <summary>
    /// Defines a contract for updating item quality and sell-in values.
    /// Each item type implements its own update logic based on specific business rules.
    /// </summary>
    public interface IItemUpdater
    {
        /// <summary>
        /// Updates the quality and sell-in values of the given item.
        /// </summary>
        void Update(Item item);
    }
}