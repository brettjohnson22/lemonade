using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {
        //member variables (HAS A)
        public Lemon lemon;
        public Sugar sugar;
        public Ice ice;

        //constructor (SPAWNER)
        static Store()
        {
            new Lemon();
            new Sugar();
            new Ice();
        }
        public Store()
        {
            lemon = new Lemon();
            sugar= new Sugar();
            ice = new Ice();
        }
        //member methods (CAN DO)
        public void SellItem(Inventory inv, StoreItem itemToSell)
        {
            if (inv.myWallet >= itemToSell.CostPerOrder)
            {
                if (itemToSell.Name == "lemon")
                {
                    for (int i = 0; i < itemToSell.SellAmount; i++)
                    {
                        inv.allItems.Add(new Lemon());
                    }
                    inv.myWallet -= lemon.costPerOrder;
                }
                else if (itemToSell.Name == "sugar")
                {
                    for (int i = 0; i < itemToSell.SellAmount; i++)
                    {
                        inv.allItems.Add(new Sugar());
                    }
                    inv.myWallet -= sugar.costPerOrder;
                }
                else if (itemToSell.Name == "ice")
                {
                    for (int i = 0; i < itemToSell.SellAmount; i++)
                    {
                        inv.allItems.Add(new Ice());
                    }
                    inv.myWallet -= ice.costPerOrder;
                }
            }
            else
            {
                UserInterface.CantAfford();
            }
        }
    }
}
