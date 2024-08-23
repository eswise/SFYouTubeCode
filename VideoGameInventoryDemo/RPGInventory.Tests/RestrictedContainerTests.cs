using RPGInventory.Items.Armors;
using RPGInventory.Items.Base;
using RPGInventory.Items.Containers;
using RPGInventory.Items.Potions;
using RPGInventory.Items.Weapons;

namespace RPGInventory.Tests
{
    public class RestrictedContainerTests
    {
        [Fact]
        public void AddWrongItem_Failure()
        {
            var item = new WoodenSword();
            var container = new PotionBelt(4, ItemType.Potion);

            var result = container.AddItem(item);
            Assert.Equal(AddItemResult.WrongType, result);
        }

        [Fact]
        public void AddItem_Success()
        {
            var item = new HealthPotion();
            var container = new PotionBelt(4, ItemType.Potion);

            var result = container.AddItem(item);
            Assert.Equal(AddItemResult.Success, result);
        }

        [Fact]
        public void AddItem_Overweight_Failure()
        {
            var container = new PaperSack(5, 2.5);
            var item1 = new ClothArmor();
            var item2 = new WoodenSword();

            var result1 = container.AddItem(item1);
            Assert.Equal(AddItemResult.Success, result1);

            Assert.Equal(2, container.CurrentWeight);

            var result2 = container.AddItem(item2);
            Assert.Equal(AddItemResult.OverWeight, result2);
        }

        [Fact]
        public void AddItem_Overweight_Success()
        {
            var container = new PaperSack(5, 3);
            var item1 = new ClothArmor();
            var item2 = new WoodenSword();

            var result1 = container.AddItem(item1);
            Assert.Equal(AddItemResult.Success, result1);

            var result2 = container.AddItem(item2);
            Assert.Equal(AddItemResult.Success, result2);

            Assert.Equal(3, container.CurrentWeight);
        }

        [Fact]
        public void RemoveItem_Calculates_Weight()
        {
            var container = new PaperSack(5, 3);
            var item1 = new ClothArmor();
            var item2 = new WoodenSword();

            var result1 = container.AddItem(item1);
            Assert.Equal(AddItemResult.Success, result1);

            var result2 = container.AddItem(item2);
            Assert.Equal(AddItemResult.Success, result2);

            Assert.Equal(3, container.CurrentWeight);

            var item3 = container.RemoveItem(0);
            Assert.Equal(1, container.CurrentWeight);
        }
    }
}
