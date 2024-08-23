using RPGInventory.Items.Base;

namespace RPGInventory.Items.Weapons
{
    public class WoodenSword : Weapon
    {
        public WoodenSword()
        {
            Name = "The Wooden Sword";
            Weight = 1;
            Value = 0;
            Damage = 1;
            Type = ItemType.Weapon;
        }
    }
}
