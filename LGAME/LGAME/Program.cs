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
            Inventory inv = new Inventory(100, false);



            Console.ReadKey();
        }
    }
    class Inventory
    {
        public List<Item> Inventar;
        public int Capacity;
        public bool InventoryFull;

        public Inventory(int capacity,bool inventoryFull)
        {
            Capacity = capacity;
            InventoryFull = inventoryFull;
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
                Console.WriteLine("Added:" + item);
                Capacity = Capacity + item.Weight;
                InventoryFull = false;
            }
        }

        public void Info(Item item)
        {
            Console.WriteLine("Name:" + item.Name);
            Console.WriteLine("Weight:" + item.Weight);
            Console.WriteLine("Description:" + item.Description);
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
            Console.WriteLine("Destoyed?:" + Destroyed);
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
            Console.WriteLine("Efficiency:" + Efficiency);
            this.Destroyed = true;
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
            Console.WriteLine("Destroyed:" + Destroyed);
        }
    }
}
