using RPGInventory.Items.Base;
using RPGInventory.Items.Containers;
using RPGInventory.Items.Potions;
using RPGInventory.Items.Weapons;

namespace RPGInventory.Tests
{
    public class BaseContainerTests
    {
        [Fact]
        public void AddItem_Success()
        {
            var chest = new TreasureChest(1);

            var sword = new WoodenSword();

            var result = chest.AddItem(sword);

            Assert.Equal(AddItemResult.Success, result);
        }

        [Fact]
        public void RemoveItem_Success()
        {
            var chest = new TreasureChest(1);

            var sword = new WoodenSword();

            chest.AddItem(sword);

            var output = chest.RemoveItem(0);

            Assert.Equal(output, sword);
        }

        [Fact]
        public void RemoveItem_BadIndex_ReturnsNull()
        {
            var chest = new TreasureChest(1);

            var output = chest.RemoveItem(500);

            Assert.Null(output);
        }

        [Fact]
        public void RemoveItem_EmptySlot_ReturnsNull()
        {
            var chest = new TreasureChest(1);
            var output = chest.RemoveItem(0);
            Assert.Null(output);
        }

        [Fact]
        public void AddItem_FullContainer_ReturnsFalse()
        {
            var chest = new TreasureChest(1);

            var sword = new WoodenSword();

            chest.AddItem(sword);

            var output = chest.AddItem(new HealthPotion());

            Assert.Equal(AddItemResult.OverCapacity, output);
        }
    }
}
