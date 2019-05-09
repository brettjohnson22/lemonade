using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        //member variables (HAS A)
        public double myWallet;
        public double totalProfit;
        public double lemons;
        public double sugar;
        public double ice;
        public Recipe myRecipe;

        //constructor (SPAWNER)
        public Inventory()
        {
            myRecipe = new Recipe();
            myWallet = 10;
            totalProfit = 0;
            lemons = 10;
            sugar = 20;
            ice = 100;
        }
        //member methods (CAN DO)
        public void TerribleMisfortune()
        {
            Random rand = new Random();
            int misfortune = rand.Next(10);
            switch(misfortune)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    break;
                case 5:
                case 6:
                    ice = 0;
                    UserInterface.IceMelt();
                    break;
                case 7:
                    lemons = 0;
                    UserInterface.LemonToss();
                    break;
                case 8:
                    sugar = 0;
                    UserInterface.SugarTank();
                    break;
                case 9:
                    if (myWallet > 15)
                    {
                        myWallet -= 5;
                        totalProfit -= 5;
                        UserInterface.BullySwipe();
                    }
                    break;
            }
        }
    }
}
