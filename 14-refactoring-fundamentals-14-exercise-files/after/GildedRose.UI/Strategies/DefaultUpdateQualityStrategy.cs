using GildedRose.UI.Interfaces;

namespace GildedRose.UI.Strategies
{
    public class DefaultUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem item)
        {
            item.DecrementQuality();
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.DecrementQuality();
            }
        }
    }
}