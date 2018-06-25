using System;
using System.Linq;
using GildedRose.UI;
using GildedRose.UI.Strategies;
using Xunit;
using FluentAssertions;

namespace GildedRose.UnitTests.Strategies
{
    public class ConjuredItemUpdateQualityStrategy_UpdateQualityShould : BaseStrategyTest
    {
        ConjuredItemUpdateQualityStrategy _strategy = new ConjuredItemUpdateQualityStrategy();

        [Fact]
        public void ReduceConjuredItemQualityByTwo()
        {
            var conjuredItem = GetConjuredItem();
            int startingQuality = conjuredItem.Quality;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.Quality.Should().Be(startingQuality - 2);
        }

        [Fact]
        public void ReduceConjuredItemSellInByOne()
        {
            var conjuredItem = GetConjuredItem();
            int startingSellIn = conjuredItem.SellIn;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.SellIn.Should().Be(startingSellIn - 1);
        }

        [Fact]
        public void ReduceConjuredItemQualityByFourWhenSellInLessThan1()
        {
            var conjuredItem = GetConjuredItem(sellIn: 0);
            int startingQuality = conjuredItem.Quality;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.Quality.Should().Be(startingQuality - 4);
        }

        [Fact]
        public void NotReduceQualityBelowZero()
        {
            var conjuredItem = GetConjuredItem(quality: 0);
            int startingQuality = conjuredItem.Quality;

            _strategy.UpdateQuality(conjuredItem);

            conjuredItem.Quality.Should().Be(0);
        }

        private static StoreItem GetConjuredItem(int sellIn = DEFAULT_STARTING_SELLIN, 
            int quality = DEFAULT_STARTING_QUALITY)
        {
            return new StoreItem(
                new Item { Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality });
        }
    }
}