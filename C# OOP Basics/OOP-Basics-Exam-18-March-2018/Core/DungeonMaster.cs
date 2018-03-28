using DungeonsAndCodeWizards.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private readonly List<Character> characters;
        private readonly List<Item> itemsPool;
        private int rounds;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.itemsPool = new List<Item>();
            this.rounds = 0;
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }
            else
            {
                switch (characterType)
                {
                    case "Warrior":
                        Warrior warrior = new Warrior(name, parsedFaction);
                        characters.Add(warrior);
                        break;
                    case "Cleric":
                        Cleric cleric = new Cleric(name, parsedFaction);
                        characters.Add(cleric);
                        break;
                    default:
                        throw new ArgumentException($"Invalid character type \"{characterType}\"!");
                }
                return $"{name} joined the party!";
            }
        }

        public string AddItemToPool(string[] args)
        {
            switch (args[0])
            {
                case "HealthPotion":
                    itemsPool.Add(new HealthPotion());
                    break;
                case "PoisonPotion":
                    itemsPool.Add(new PoisonPotion());
                    break;
                case "ArmorRepairKit":
                    itemsPool.Add(new ArmorRepairKit());
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{args[0]}\"!");
            }
            return $"{args[0]} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var lastItemName = string.Empty;

            var character = this.FindCharacter(characterName);

            if (itemsPool.Count < 1)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            else
            {
                lastItemName = itemsPool.Last().GetType().Name;
                character.ReceiveItem(itemsPool.Last());
                itemsPool.RemoveAt(itemsPool.Count - 1);
            }

            return $"{characterName} picked up {lastItemName}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = this.FindCharacter(characterName);
            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.FindCharacter(giverName);
            var receiver = this.FindCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);


            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.FindCharacter(giverName);
            var receiver = this.FindCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);


            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var sb = new StringBuilder();
            foreach (var c in characters.OrderByDescending(a => a.IsAlive).ThenByDescending(o => o.Health))
            {
                if (c.IsAlive)
                {
                    sb.AppendLine($"{c.Name} - HP: {c.Health}/{c.BaseHealth}, AP: {c.Armor}/{c.BaseArmor}, Status: Alive");
                }
                else
                {
                    sb.AppendLine($"{c.Name} - HP: {c.Health}/{c.BaseHealth}, AP: {c.Armor}/{c.BaseArmor}, Status: Dead");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];
            var sb = new StringBuilder();

            var attacker = this.FindCharacter(attackerName);
            var receiver = this.FindCharacter(receiverName);

            if (attacker is Cleric)
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }
            else
            {
                var attackerW = (Warrior)characters.FirstOrDefault(a => a.Name == attackerName);
                attackerW.Attack(receiver);
                sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
                if (receiver.Health <= 0)
                {
                    sb.AppendLine($"{receiver.Name} is dead!");
                    receiver.IsAlive = false;
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var sb = new StringBuilder();
            var healer = this.FindCharacter(healerName);
            var receiver = this.FindCharacter(healingReceiverName);

            if (healer is Warrior)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
            else
            {
                var healerC = (Cleric)characters.Find(c => c.Name == healerName);
                healerC.Heal(receiver);
                sb.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");
            }

            return sb.ToString().TrimEnd();
        }

        public string EndTurn(string[] args)
        {
            var sb = new StringBuilder();
            int countAlivePeople = 0;
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].IsAlive)
                {
                    countAlivePeople++;
                }
            }

            foreach (var c in characters.Where(x => x.IsAlive))
            {
                var healthBeforeRest = c.Health;
                c.Rest();
                sb.AppendLine($"{c.Name} rests ({healthBeforeRest} => {c.Health})");
            }
            if (countAlivePeople == 0 || countAlivePeople == 1)
            {
                this.rounds++;
                if (countAlivePeople == 1)
                {
                    foreach (var c in characters.Where(x => x.IsAlive))
                    {
                        var healthBeforeRest = c.Health;
                        c.Rest();
                        sb.AppendLine($"{c.Name} rests ({healthBeforeRest} => {c.Health})");
                    }
                }

            }
            else if (countAlivePeople > 1)
            {
                this.rounds = 0;
            }
            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            bool isGameOver = false;
            if (this.rounds > 0)
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        public Character FindCharacter(string name)
        {
            var character = characters.FirstOrDefault(c => c.Name == name);

            if (character == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            return character;
        }
    }
}
