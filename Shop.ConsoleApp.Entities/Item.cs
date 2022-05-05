namespace Shop.ConsoleApp.Entities
{
    public class Item
    {
        private readonly ItemType type;
        private readonly double price;
        public Item(ItemType _type, double _price)
        {
            type = _type;
            price = _price;
        }
        public ItemType GetItemType() => type;
        public double GetPrice() => price;
    }
}