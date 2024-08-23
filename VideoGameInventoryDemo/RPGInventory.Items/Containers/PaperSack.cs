using RPGInventory.Items.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Items.Containers
{
    public class PaperSack : WeightRestrictedContainer
    {
        public PaperSack(int capacity, double maxWeight) : base(capacity, maxWeight)
        {
        }
    }
}
