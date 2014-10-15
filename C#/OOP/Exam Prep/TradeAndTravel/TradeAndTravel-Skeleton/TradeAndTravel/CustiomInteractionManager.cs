namespace TradeAndTravel
{
    using System.Linq;

    class CustiomInteractionManager : InteractionManager
    {
        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            switch (personTypeString)
            {
                case "merchant":
                    return new Merchant(personNameString, personLocation);
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }

        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords[2], actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            string itemTypeToCraft = commandWords[2];
            string chosenItemName = commandWords[3];
            var actorInventory = actor.ListInventory();
            if (itemTypeToCraft == "armor")
            {
                if (actorInventory.Any(i => i.ItemType == ItemType.Iron))
                {
                    AddToPerson(actor, new Armor(chosenItemName));
                }
            }
            else if (itemTypeToCraft == "weapon")
            {
                if (actorInventory.Any(i => i.ItemType == ItemType.Iron) &&
                    actorInventory.Any(i => i.ItemType == ItemType.Wood))
                {
                    AddToPerson(actor, new Weapon(chosenItemName));
                }
            }
        }

        private void HandleGatherInteraction(string name, Person actor)
        {
            if (actor.Location is IGatheringLocation)
            {
                var location = actor.Location as IGatheringLocation;

                if (actor.ListInventory().Any(i => i.ItemType == location.RequiredItem))
                {
                    AddToPerson(actor, location.ProduceItem(name));
                }
            }
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {

            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }
    }
}
