using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }

    [Fact]
    public void Sulfuras()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].SellIn);
        Assert.Equal(80, Items[0].Quality);
    }


    [Fact]
    public void UpdateQuality_givinSellInLessThan0_shouldDegradeTwiceSpeed()
    {
        IList<Item> Items = new List<Item> { new Item {Name = "+5 Dexterity Vest", SellIn = 3, Quality = 20}, };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(2, Items[0].SellIn);
        Assert.Equal(19, Items[0].Quality);
        app.UpdateQuality();
        Assert.Equal(1, Items[0].SellIn);
        Assert.Equal(18, Items[0].Quality);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].SellIn);
        Assert.Equal(17, Items[0].Quality);
        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(15, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_QualityNeverNegative()
    {
        IList<Item> Items = new List<Item> { new Item {Name = "+5 Dexterity Vest", SellIn = 1, Quality = 1} };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);
        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_AgedBrieQualityCheck_ShouldIncrease()
    {
        IList<Item> Items = new List<Item> { new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}, };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(1, Items[0].SellIn);
        Assert.Equal(1, Items[0].Quality);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].SellIn);
        Assert.Equal(2, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_QualityNeverOver50()
    {
        IList<Item> Items = new List<Item> { new Item {Name = "Aged Brie", SellIn = 2, Quality = 50}, };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(1, Items[0].SellIn);
        Assert.Equal(50, Items[0].Quality);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].SellIn);
        Assert.Equal(50, Items[0].Quality);
    }

    //Check Backstage Pass increase quality
    [Fact]
    public void UpdateQuality_BackStagePassQuality_ShouldIncrease1WhenDaysGreaterThan10()
    {
        IList<Item> Items = new List<Item> { new Item{
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            }, };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(14, Items[0].SellIn);
        Assert.Equal(21, Items[0].Quality);
    }

        [Fact]
    public void UpdateQuality_BackStagePassQuality_ShouldIncrease2WhenDaysLessThan10AndGreaterThan5()
    {
        IList<Item> Items = new List<Item> { new Item{
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 20
            }, };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(9, Items[0].SellIn);
        Assert.Equal(22, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackStagePassQuality_ShouldIncrease3WhenDaysLessThan5AndGreaterThan0()
    {
        IList<Item> Items = new List<Item> { new Item{
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 20
            }, };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(4, Items[0].SellIn);
        Assert.Equal(23, Items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_BackStagePassQuality_ShouldBe0WhenOnAndAfterSellIn()
    {
        IList<Item> Items = new List<Item> { new Item{
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 20
            }, };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);
    }

        [Fact]
    public void UpdateQuality_ConuredItems_DegrageTwiceAsFast()
    {
        IList<Item> Items = new List<Item> { new Item{
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 20
            }, };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(0, Items[0].Quality);
    }


}