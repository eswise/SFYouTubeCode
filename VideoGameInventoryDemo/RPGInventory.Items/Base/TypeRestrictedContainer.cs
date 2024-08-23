using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Items.Base
{
    public abstract class TypeRestrictedContainer : Container
    {
        protected ItemType _requiredType;

        public TypeRestrictedContainer(int capacity, ItemType requiredType) : base(capacity)
        {
            _requiredType = requiredType;
        }

        public override AddItemResult AddItem(Item item)
        {
            if(item.Type == _requiredType)
            {
                return base.AddItem(item);
            }

            return AddItemResult.WrongType;
        }
    }
}
