using System.Collections.Generic;

namespace hamaraBasket
{
    public class HamaraBasket
    {
        IList<Item> Items;
        public HamaraBasket(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Forest Honey":
                        break;

                    case "Indian Wine":
                        IncreaseQuality(item);
                        if (item.SellIn < 0)
                        {
                            IncreaseQuality(item);
                        }
                        item.SellIn--;
                        break;

                    case "Movie Tickets":
                        if (item.SellIn > 10)
                        {
                            IncreaseQuality(item);
                        }
                        else if (item.SellIn > 5)
                        {
                            IncreaseQuality(item, 2);
                        }
                        else if (item.SellIn > 0)
                        {
                            IncreaseQuality(item, 3);
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                        item.SellIn--;
                        break;

                    default:
                        DecreaseQuality(item);
                        item.SellIn--;

                        if (item.SellIn < 0)
                        {
                            DecreaseQuality(item); 
                        }
                        break;
                }
            }
        }

        private void IncreaseQuality(Item item, int amount = 1)
        {
            if (item.Quality < 50)
            {
                item.Quality = System.Math.Min(50, item.Quality + amount);
            }
        }

        private void DecreaseQuality(Item item, int amount = 1)
        {
            if (item.Quality > 0)
            {
                item.Quality = System.Math.Max(0, item.Quality - amount);
            }
        }
    }
}
