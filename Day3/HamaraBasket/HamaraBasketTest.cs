using NUnit.Framework;
using System.Collections.Generic;

namespace hamaraBasket
{
    [TestFixture]
    public class HamaraBasketTest
    {
        private DomainFactory domain;

        [SetUp]
        public void SetUp()
        {
            domain = new DomainFactory();  
        }

        private IList<Item> PrepareOnelistItem(string name, int sellBy, int qual)
        {
            return domain.PrepareOnelistItem(name, sellBy, qual);
        }

        private void updateQualityRule(IList<Item> Items)
        {
            domain.updateQualityRule(Items);
        }

        [Test]
        public void GenericProductSellByValueShouldReduceByOne()
        {
            string name = "Lux soap 50g";
            int sellBy = 10;
            int quality = 10;

            IList<Item> Items = PrepareOnelistItem(name, sellBy, quality);
            updateQualityRule(Items);

            Assert.That(Items[0].SellIn, Is.EqualTo(sellBy - 1));
        }

        [Test]
        public void GenericProductQualityValueShouldReduceByOne()
        {
            string name = "Lux soap 50g";
            int sellBy = 10;
            int quality = 10;

            IList<Item> Items = PrepareOnelistItem(name, sellBy, quality);
            updateQualityRule(Items);

            Assert.That(Items[0].Quality, Is.EqualTo(quality - 1)); 
        }

        [Test]
        public void ProductQualityDoesNotGoNegative()
        {
            string name = "Lux soap 50g";
            int sellBy = 5;
            int quality = 0;

            IList<Item> Items = PrepareOnelistItem(name, sellBy, quality);
            updateQualityRule(Items);

            Assert.That(Items[0].Quality, Is.EqualTo(0)); 
        }

        [Test]
        public void IndianWineQualityIncreasesOverTime()
        {
            string name = "Indian Wine";
            int sellBy = 5;
            int quality = 10;

            IList<Item> Items = PrepareOnelistItem(name, sellBy, quality);
            updateQualityRule(Items);

            Assert.That(Items[0].Quality, Is.EqualTo(quality + 1)); 
        }

        [Test]
        public void ForestHoneyQualityRemainsSame()
        {
            string name = "Forest Honey";
            int sellBy = 10;
            int quality = 40;

            IList<Item> Items = PrepareOnelistItem(name, sellBy, quality);
            updateQualityRule(Items);

            Assert.That(Items[0].Quality, Is.EqualTo(40));  
            Assert.That(Items[0].SellIn, Is.EqualTo(10));   
        }

        [Test]
        public void MovieTicketsIncreaseQualityAndDropToZeroAfterShow()
        {
            string name = "Movie Tickets";
            int sellBy = 10;
            int quality = 10;

            IList<Item> Items = PrepareOnelistItem(name, sellBy, quality);
            updateQualityRule(Items);

            Assert.That(Items[0].Quality, Is.EqualTo(12)); 

            Items[0].SellIn = 5;
            updateQualityRule(Items);

            Assert.That(Items[0].Quality, Is.EqualTo(15)); 

            Items[0].SellIn = 0;
            updateQualityRule(Items);

            Assert.That(Items[0].Quality, Is.EqualTo(0));
        }
    }
}
