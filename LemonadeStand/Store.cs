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
        //static Store()
        //{
        //    new Lemon();
        //    new Sugar();
        //    new Ice();
        //}
        public Store()
        {
            lemon = new Lemon();
            sugar= new Sugar();
            ice = new Ice();
        }
        //member methods (CAN DO)
        public void SellItem<T>(Inventory inv, ref T itemToSell) where T : StoreItem, new()
        {
            if (inv.myWallet >= itemToSell.costPerOrder)
            {
                for (int i = 0; i < itemToSell.sellAmount; i++)
                {
                    inv.allItems.Add(new T());
                }
                inv.myWallet -= itemToSell.costPerOrder;
            }
            else
            {
                UserInterface.CantAfford();
            }
        }
    }
}
