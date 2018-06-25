using System;
using System.Linq;
using GildedRose.UI;
using GildedRose.UI.Strategies;
using Xunit;
using FluentAssertions;

namespace GildedRose.UnitTests.Strategies
{
    public class LegendaryUpdateQualityStrategy_UpdateQualityShould : BaseStrategyTest
    {
        LegendaryUpdateQualityStrategy _strategy = new LegendaryUpdateQualityStrategy();
        [Fact]
        public void NotChangeQualityOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            int startingQuality = sulfuras.Quality;

            _strategy.UpdateQuality(sulfuras);

            sulfuras.Quality.Should().Be(startingQuality);
        }

        [Fact]
        public void NotChangeSellInOfSulfuras()
        {
            var sulfuras = GetSulfuras();
            int startingSellIn = sulfuras.SellIn;

            _strategy.UpdateQuality(sulfuras);

            sulfuras.SellIn.Should().Be(startingSellIn);
        }
        private static StoreItem GetSulfuras()
        {
            return new StoreItem(
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
        }
    }
}