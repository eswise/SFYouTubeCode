using RPGInventory.Items.Base;

namespace RPGInventory.Items.Potions
{
    public class HealthPotion : Potion
    {
        public HealthPotion()
        {
            Name = "A Health Potion";
            Weight = 0.1;
            Value = 50;
            Type = ItemType.Potion;
        }
    }
}
