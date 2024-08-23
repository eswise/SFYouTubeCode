namespace RPGInventory.Items.Base
{
    public abstract class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
        public ItemType Type { get; set; }
    }

    public enum ItemType
    {
        Potion,
        Weapon,
        Armor
    }
}
