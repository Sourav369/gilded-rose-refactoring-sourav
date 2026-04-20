namespace GildedRose.Console
{
    /// <summary>
    /// Represents an inventory item with a name, sell-in days, and quality value.
    /// </summary>
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}