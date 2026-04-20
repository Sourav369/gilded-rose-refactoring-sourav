namespace GildedRose.Console.Updaters
{
    /// <summary>
    /// Defines the contract for updating an inventory item's quality and sell-in value.
    /// </summary>
    public interface IItemUpdater
    {
        /// <summary>
        /// Updates the quality and sell-in values of the given item.
        /// </summary>
        void Update(Item item);
    }
}