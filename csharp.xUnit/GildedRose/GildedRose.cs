using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualBasic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }


    private void UpdateAgedBrie(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality++;
        }
    }

    private void UpdateBackstagePasses(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality++;

            if (item.SellIn <= 10 && item.Quality < 50)
            {
                item.Quality++;
            }

            if (item.SellIn <= 5 && item.Quality < 50)
            {
                item.Quality++;
            }
        }

        if (item.SellIn <= 0)
        {
            item.Quality = 0;
        }
    }

    private void UpdateStandardItem(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality--;
            if (item.SellIn <= 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }

    private void updateConjuredItem(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 2;
        }
    }

    private void UpdateSellIn(Item item)
    {
        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.SellIn--;
        }
    }


    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
        switch (item.Name)
        {
            case "Aged Brie":
                UpdateAgedBrie(item);
                break;
            case "Backstage passes to a TAFKAL80ETC concert":
                UpdateBackstagePasses(item);
                break;
            case "Conjured Mana Cake":
                updateConjuredItem(item);
                break;
            case "Sulfuras, Hand of Ragnaros":
                return; // Sulfuras never changes
            default:
                UpdateStandardItem(item);
                break;
        }

        UpdateSellIn(item);
        }


        // for (var i = 0; i < Items.Count; i++)
        // {
        //     if (Items[i].Quality < 50)
        //     {
        //         //Aged Brie
        //         if (Items[i].Name == "Aged Brie")
        //         {
        //             Items[i].Quality = Items[i].Quality + 1;
        //         }
        //     }



        //     if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //     {
        //         if (Items[i].Quality > 0)
        //         {
        //             if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //             {
        //                 Items[i].Quality = Items[i].Quality - 1;
        //             }
        //         }
        //     }
        //     else
        //     {
        //         if (Items[i].Quality < 50)
        //         {
        //             Items[i].Quality = Items[i].Quality + 1;

        //             if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
        //             {
        //                 if (Items[i].SellIn < 11)
        //                 {
        //                     if (Items[i].Quality < 50)
        //                     {
        //                         Items[i].Quality = Items[i].Quality + 1;
        //                     }
        //                 }

        //                 if (Items[i].SellIn < 6)
        //                 {
        //                     if (Items[i].Quality < 50)
        //                     {
        //                         Items[i].Quality = Items[i].Quality + 1;
        //                     }
        //                 }
        //             }
        //         }
        //     }

        //     if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //     {
        //         Items[i].SellIn = Items[i].SellIn - 1;
        //     }

        //     if (Items[i].SellIn < 0)
        //     {
        //         if (Items[i].Name != "Aged Brie")
        //         {
        //             if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
        //             {
        //                 if (Items[i].Quality > 0)
        //                 {
        //                     if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
        //                     {
        //                         Items[i].Quality = Items[i].Quality - 1;
        //                     }
        //                 }
        //             }
        //             else
        //             {
        //                 Items[i].Quality = Items[i].Quality - Items[i].Quality;
        //             }
        //         }
        //         else
        //         {
        //             if (Items[i].Quality < 50)
        //             {
        //                 Items[i].Quality = Items[i].Quality + 1;
        //             }
        //         }
        //     }
        // }
    }
}