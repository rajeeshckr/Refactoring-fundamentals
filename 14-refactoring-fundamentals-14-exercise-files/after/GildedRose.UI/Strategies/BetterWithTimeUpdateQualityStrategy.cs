using GildedRose.UI.Interfaces;

namespace GildedRose.UI.Strategies
{
    public class BetterWithTimeUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem item)
        {
            item.IncrementQuality();
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.IncrementQuality();
            }
        }
    }
}