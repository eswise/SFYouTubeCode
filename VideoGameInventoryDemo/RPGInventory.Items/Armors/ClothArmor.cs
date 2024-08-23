using RPGInventory.Items.Base;

namespace RPGInventory.Items.Armors
{
    public class ClothArmor : Armor
    {
        public ClothArmor()
        {
            Name = "A wool cloth armor";
            Weight = 2;
            Value = 100;
            Defense = 1;
            Type = ItemType.Armor;
        }
    }
}
