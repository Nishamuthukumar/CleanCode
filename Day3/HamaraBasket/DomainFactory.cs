using System.Collections.Generic;

namespace hamaraBasket
{
    public class DomainFactory
    {
        public IList<Item> PrepareOnelistItem(string name, int sellBy, int qual)
        {
            return new List<Item> { new Item { Name = name, SellIn = sellBy, Quality = qual } };
        }

        public void updateQualityRule(IList<Item> Items)
        {
            HamaraBasket app = new HamaraBasket(Items);
            app.UpdateQuality();
        }
    }
}
