using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Items.Base
{
    public class WeightRestrictedContainer : Container
    {
        protected double _maxWeight;
        protected double _currentWeight = 0;

        public double CurrentWeight { get { return _currentWeight; } }

        public WeightRestrictedContainer(int capacity, double maxWeight) : base(capacity)
        {
            _maxWeight = maxWeight;
        }

        public override AddItemResult AddItem(Item item)
        {
            if (_currentWeight + item.Weight > _maxWeight)
            {
                return AddItemResult.OverWeight;
            }

            if (base.AddItem(item) == AddItemResult.Success)
            {
                _currentWeight += item.Weight;
                return AddItemResult.Success;
            }
            else
            {
                return AddItemResult.OverCapacity;
            }
        }

        public override Item RemoveItem(int index)
        {
            var item = base.RemoveItem(index);

            if (item != null)
            {
                _currentWeight -= item.Weight;
            }

            return item;
        }
    }
}
