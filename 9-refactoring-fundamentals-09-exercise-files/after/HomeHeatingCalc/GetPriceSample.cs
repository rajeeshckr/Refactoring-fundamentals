using System;
using System.Linq;

namespace HomeHeatingCalc
{
    /// <summary>
    /// Taken from Refactoring, pp. 122-123, and converted into C#
    /// </summary>
    class SampleItem
    {
        private int _quantity;
        private int _itemPrice;

        decimal GetPrice()
        {
            return GetBasePrice() * GetDiscountFactor();
        }
        private decimal GetDiscountFactor()
        {
            if (GetBasePrice() > 1000)
            {
                return 0.95m;
            }
            return 0.98m;
        }
        private int GetBasePrice()
        {
            return _quantity * _itemPrice;
        }
    }
}
