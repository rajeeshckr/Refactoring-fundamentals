using System;
using System.Linq;
using GildedRose.UI;
using GildedRose.UI.Strategies;
using Xunit;
using FluentAssertions;

namespace GildedRose.UnitTests.Strategies
{
    public class BackstagePassUpdateQualityStrategy_UpdateQualityShould : BaseStrategyTest
    {
        BackstagePassUpdateQualityStrategy _strategy = new BackstagePassUpdateQualityStrategy();

        [Fact]
        public void IncreaseQualityOfBackstagePassesByOneWith11DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 11);
            int startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(startingQuality + 1);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith10DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 10);
            int startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByTwoWith6DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 6);
            int startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(startingQuality + 2);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith5DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 5);
            int startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void IncreaseQualityOfBackstagePassesByThreeWith1DayLeft()
        {
            var passes = GetBackstagePasses(sellIn: 1);
            int startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(startingQuality + 3);
        }

        [Fact]
        public void SetQualityOfBackstagePassesToZeroWith0DaysLeft()
        {
            var passes = GetBackstagePasses(sellIn: 0);
            int startingQuality = passes.Quality;

            _strategy.UpdateQuality(passes);

            passes.Quality.Should().Be(0);
        }

        private static StoreItem GetBackstagePasses(int sellIn = DEFAULT_STARTING_SELLIN,
    int quality = DEFAULT_STARTING_QUALITY)
        {
            return new StoreItem(
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality });
        }
    }
}