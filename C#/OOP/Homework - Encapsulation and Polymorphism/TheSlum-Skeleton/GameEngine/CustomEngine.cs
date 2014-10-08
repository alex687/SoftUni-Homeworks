namespace TheSlum.GameEngine
{
    using System;
    using System.Collections.Generic;
    using Bonuses;
    using Characters;
    using Items;

    public class CustomEngine : Engine
    {
        public CustomEngine()
        {
            this.timeoutItems = new List<Bonus>();
        }

        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character character = null;
            switch (inputParams[1])
            {
                case "mage":
                    character = this.CreateMage(inputParams);
                    break;
                case "warrior":
                    character = this.CreateWarior(inputParams);
                    break;
                case "healer":
                    character = this.CreateHealer(inputParams);
                    break;
                default:
                    throw new NotSupportedException("Invalid Character");
            }

            this.characterList.Add(character);
        }

        protected new void AddItem(string[] inputParams)
        {
            var id = inputParams[1];
            var characterForAddingItems = this.characterList.Find(c => c.Id == id);
            var item = this.CreateItem(inputParams);
            characterForAddingItems.AddToInventory(item);
        }

        private Item CreateItem(string[] inputParams)
        {
            Item item = null;
            switch (inputParams[2])
            {
                case "axe":
                    item = new Axe(inputParams[3]);
                    break;
                case "shield":
                    item = new Shield(inputParams[3]);
                    break;
                default:
                    item = this.CreateBonus(inputParams);
                    break;
            }

            return item;
        }

        private Item CreateBonus(string[] inputParams)
        {
            Bonus bonus = null;
            switch (inputParams[2])
            {
                case "pill":
                    bonus = new Pill(inputParams[3]);
                    break;
                case "injection":
                    bonus = new Injection(inputParams[3]);
                    break;
                default:
                    throw new InvalidOperationException("Invalid Item or Bonus");
            }

            this.timeoutItems.Add(bonus);
            return (Item)bonus;
        }

        private Character CreateMage(string[] inputParams)
        {
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = this.GetTeam(inputParams[5]);

            return new Mage(id, x, y, team);
        }

        private Character CreateWarior(string[] inputParams)
        {
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = this.GetTeam(inputParams[5]);

            return new Warrior(id, x, y, team);
        }

        private Character CreateHealer(string[] inputParams)
        {
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = this.GetTeam(inputParams[5]);

            return new Healer(id, x, y, team);
        }

        private Team GetTeam(string team)
        {
            return (Team)Enum.Parse(typeof(Team), team, true);
        }
    }
}
