using RPGInventory.Items.Base;

namespace RPGInventory.Items.Containers
{
    public class PotionBelt : TypeRestrictedContainer
    {
        public PotionBelt(int capacity, ItemType requiredType) : base(capacity, requiredType)
        {
        }
    }
}
