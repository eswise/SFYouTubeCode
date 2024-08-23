namespace RPGInventory.Items.Base
{
    public abstract class Potion : Item
    {
        public void Drink()
        {
            Console.WriteLine("Glug glug glug");
        }
    }
}
