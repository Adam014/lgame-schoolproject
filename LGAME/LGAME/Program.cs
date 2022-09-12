using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGAME
{
    class Program
    {
        static void Main(string[] args)
        {

            Weapon Sword = new Weapon(5, "Fire", 100, false, "The DragonSlayer", 20, "The best sword.");
            Weapon Axe = new Weapon(8, "Fire", 100, false, "The VikingSlayer", 40, "The best axe.");
            Armor Armor = new Armor(true, false, 30, false, "Diamond Armor", 50, "The best armor.");
            Potion Damage = new Potion(true, 0, false, "The Destroyer potion", 5, "The best potion", 100);
            Inventory inv = new Inventory(100, false);

            inv.Vlozit(Sword);
            inv.Vlozit(Axe);
            inv.Vlozit(Damage);
            inv.Remove(Axe);
            inv.Vlozit(Armor);

            Console.ReadKey();
            Console.Clear();

            Sword.Use();
            Sword.Use();
            Sword.Use();
            Sword.Use();
            Sword.Use();
            Sword.Use();
            Sword.Use();
            Sword.Use();
            Sword.Use();
            Sword.Use();
            Damage.Use();
            Armor.Use();
            Armor.Use();
            Armor.Use();

            Console.ReadKey();
            Console.Clear();

            if (Armor.State <= 0)
            {
                inv.Remove(Armor);
            }

            if (Sword.State <= 0)
            {
                inv.Remove(Sword);
            }

            if (Damage.Destroyed == true)
            {
                inv.Remove(Damage);
            }

            Console.ReadKey();
            Console.Clear();

            inv.Info();

            Console.Clear();

            inv.Vlozit(Armor);

            Console.ReadKey();
            Console.Clear();

            inv.Info();

            Console.WriteLine("ukonci program stisknutim libovolneho tlacitka");
            Console.ReadKey();
        }
    }
    internal class Inventory
    {
        List<Item> Inventar;
        public int Capacity;
        public bool InventoryFull;

        public Inventory(int capacity,bool inventoryFull)
        {
            Capacity = capacity;
            InventoryFull = inventoryFull;
            Inventar = new List<Item>();
        }
       

        public void Vlozit(Item item)
        {
            if (item.Weight >= Capacity)
            {
                Console.WriteLine("Inventory is full!");
                InventoryFull = true;
            }
            else
            {
                Inventar.Add(item);
                Capacity = Capacity - item.Weight;
                InventoryFull = false;
                Console.WriteLine("Added: \n" + item.Name);
                Console.WriteLine("Capacity of inventory: \n" + Capacity);
            }
        }

        public void Remove(Item item)
        {
            Inventar.Remove(item);
            Capacity = Capacity + item.Weight;
            Console.WriteLine("Removed: " + item.Name);
        }

        public void Info()
        {
            foreach (Item item in Inventar)
            {
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Description: " + item.Description);
                Console.WriteLine("Weight: " + item.Weight);
                Console.WriteLine("\n");
            }

        }
    }

    class Item
    {
        public string Name;
        public int Weight;
        public string Description;

        public Item(string name, int weight, string description)
        {
            Name = name;
            Weight = weight;
            Description = description;
        }

        public virtual void Use()
        {
        }

        public virtual void Info()
        {
        }
    }
    class Weapon : Item
    {
        public int Damage;
        public string Type;
        public int State;
        public bool Destroyed;


        public Weapon(int damage, string type, int state, bool destroyed, string name, int weight, string description) : base(name, weight, description)
        {
            Damage = damage;
            Type = type;
            Destroyed = destroyed;
            State = state;
        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("Damage:" + Damage);
            this.State = State - 10;
            Console.WriteLine("State of Weapon: " + State);

        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine("Name:" + Name);
            Console.WriteLine("Weight:" + Weight);
            Console.WriteLine("Description:" + Description);
            Console.WriteLine("Damage:" + Damage);
            Console.WriteLine("Type:" + Type);
            Console.WriteLine("State:" + State);
        }

    }
    class Potion : Item
    {
        public bool Destroyed;
        public int Efficiency;

        public Potion(bool damage, int efficiency, bool destroyed, string name, int weight, string description, int efectivity) : base(name, weight, description)
        {
            Destroyed = destroyed;
            Efficiency = efficiency;
        }
        public override void Use()
        {
            base.Use();
            this.Destroyed = true;
            Console.WriteLine("Efficiency:" + Efficiency);
            Console.WriteLine("The Potion has been used.");
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine("Name:" + Name);
            Console.WriteLine("Weight:" + Weight);
            Console.WriteLine("Description:" + Description);
            Console.WriteLine("Destroyed:" + Destroyed);
            Console.WriteLine("Efficiency:" + Efficiency);
        }

    }

    class Armor : Item
    {
        public bool FireProtection;
        public bool PoisonProtection;
        public int State;
        public bool Destroyed;

        public Armor(bool fireProtection, bool poisonProtection, int state, bool destroyed, string name, int weight, string description) : base(name, weight, description)
        {
            FireProtection = fireProtection;
            PoisonProtection = poisonProtection;
            State = state;
            Destroyed = destroyed;
        }

        public override void Use()
        {
            base.Use();
            State = State - 10;
            Console.WriteLine("State of Armor: " + State); 
        }

        public override void Info()
        {
            base.Info();
            Console.WriteLine("Name:" + Name);
            Console.WriteLine("Weight:" + Weight);
            Console.WriteLine("Description:" + Description);
            Console.WriteLine("FireProtection:" + FireProtection);
            Console.WriteLine("PoisonProtection:" + PoisonProtection);
            Console.WriteLine("State:" + State);
        }
    }
}
