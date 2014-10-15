namespace TradeAndTravel
{
    using System.Collections.Generic;

    class Iron : Item
    {
        const int GeneralWoodValue = 3;

        public Iron(string name, Location location = null)
            : base(name, Iron.GeneralWoodValue, ItemType.Iron, location)
        {
        }

        private static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Iron };
        }
    }
}
