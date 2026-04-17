using System.Collections.Generic;
using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    /// <summary>
    /// Characterization tests — written BEFORE any refactoring.
    /// These tests lock down the existing behaviour so we can
    /// refactor safely without breaking anything.
    /// All tests follow the Arrange -> Act -> Assert pattern.
    /// </summary>
    public class GildedRoseTests
    {
        // -------------------------------------------------------
        // NORMAL ITEMS
        // -------------------------------------------------------

        [Fact]
        public void NormalItem_BeforeSellDate_QualityDecreasesBy1()
        {
            // Arrange
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void NormalItem_BeforeSellDate_SellInDecreasesBy1()
        {
            // Arrange
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void NormalItem_OnSellDate_QualityDecreasesBy2()
        {
            // Arrange
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void NormalItem_AfterSellDate_QualityDecreasesBy2()
        {
            // Arrange
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void NormalItem_QualityNeverGoesNegative()
        {
            // Arrange
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 5, Quality = 0 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void NormalItem_AfterSellDate_QualityNeverGoesNegative()
        {
            // Arrange
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 0 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(0, item.Quality);
        }


        // -------------------------------------------------------
        // AGED BRIE
        // -------------------------------------------------------

        [Fact]
        public void AgedBrie_BeforeSellDate_QualityIncreasesBy1()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(11, item.Quality);
        }

        [Fact]
        public void AgedBrie_AfterSellDate_QualityIncreasesBy2()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 10 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(12, item.Quality);
        }

        [Fact]
        public void AgedBrie_QualityNeverExceeds50()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void AgedBrie_AfterSellDate_QualityNeverExceeds50()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 49 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(50, item.Quality);
        }


        // -------------------------------------------------------
        // SULFURAS
        // -------------------------------------------------------

        [Fact]
        public void Sulfuras_QualityNeverChanges()
        {
            // Arrange
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(80, item.Quality);
        }

        [Fact]
        public void Sulfuras_SellInNeverChanges()
        {
            // Arrange
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(0, item.SellIn);
        }


        // -------------------------------------------------------
        // BACKSTAGE PASSES
        // -------------------------------------------------------

        [Fact]
        public void BackstagePass_MoreThan10DaysLeft_QualityIncreasesBy1()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void BackstagePass_10DaysOrLess_QualityIncreasesBy2()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(22, item.Quality);
        }

        [Fact]
        public void BackstagePass_5DaysOrLess_QualityIncreasesBy3()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(23, item.Quality);
        }

        [Fact]
        public void BackstagePass_AfterConcert_QualityDropsToZero()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void BackstagePass_QualityNeverExceeds50()
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 };
            var app = new GildedRoseService(new List<Item> { item });

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(50, item.Quality);
        }
        [Fact]
        public void SellIn_Decreases_Below_Zero()
        {
            // Arrange
            var item = new Item { Name = "Normal Item", SellIn = 0, Quality = 10 };
            var app = new GildedRoseService(new List<Item> { item });
            // Act
            app.UpdateQuality();
            // Assert
            Assert.Equal(-1, item.SellIn);
        }
        [Fact]
        public void BackstagePass_At_11_Days_Increases_By_One()
        {
            // Arrange
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 11,
                Quality = 20
            };

            var app = new GildedRoseService(new List<Item> { item });
            // Act
            app.UpdateQuality();
            // Assert
            Assert.Equal(21, item.Quality);
        }
        [Fact]
        public void BackstagePass_At_6_Days_Increases_By_Two()
        {
            // Arrange
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 6,
                Quality = 20
            };

            var app = new GildedRoseService(new List<Item> { item });
            // Act
            app.UpdateQuality();
            // Assert
            Assert.Equal(22, item.Quality);
        }
        [Fact]
        public void Sulfuras_SellIn_Does_Not_Change_Even_If_Positive()
        {
            // Arrange
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 10,
                Quality = 80
            };

            var app = new GildedRoseService(new List<Item> { item });
            // Act
            app.UpdateQuality();
            // Assert
            Assert.Equal(10, item.SellIn);
        }
    }
}
