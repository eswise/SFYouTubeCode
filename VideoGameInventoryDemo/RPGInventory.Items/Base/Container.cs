using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Items.Base
{
    public abstract class Container
    {
        private int _capacity;
        private Item[] _contents;

        protected Container(int capacity)
        {
            _capacity = capacity;
            _contents = new Item[capacity];
        }

        public virtual AddItemResult AddItem(Item item)
        {
            for (int i = 0; i < _capacity; i++)
            {
                if (_contents[i] == null)
                {
                    _contents[i] = item;
                    return AddItemResult.Success;
                }
            }

            return AddItemResult.OverCapacity;
        }

        public virtual Item RemoveItem(int index)
        {
            if(index >= 0 && index < _capacity)
            {
                Item item = _contents[index];
                if(item != null)
                {
                    _contents[index] = null;
                    return item;
                }
            }

            return null;
        }
    }

    public enum AddItemResult
    {
        Success,
        OverCapacity,
        WrongType,
        OverWeight
    }
}
