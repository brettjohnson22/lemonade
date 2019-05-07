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
                    Console.WriteLine("You forgot to put your ice in the freezer, and it all melted. You'll have to buy more tomorrow.");
                    ice = 0;
                    break;
                case 7:
                    Console.WriteLine("As you were packing up your lemonade stand for the night, a horde of zombies shambles down your street towards you. You pelt them with lemons until they get the message and stumble off in the opposite direction. You're safe for now, but unfortunately you'll have to buy more lemons tomorrow.");
                    lemons = 0;
                    break;
                case 8:
                    Console.WriteLine("A super fancy food truck that makes delicious-looking blended beverages parks right next to you, threatening to steal all your business. While the driver is distracted, you pour all your sugar in the truck's generator. The blender sputters and whirrs before stopping all together, smoke rising from the truck. The driver glares at you before driving off for repairs. Your business is safe for now, but you'll have to buy more sugar tomorrow.");
                    sugar = 0;
                    break;
                case 9:
                    if (myWallet > 15)
                    {
                        Console.WriteLine("The neighborhood bully swiped $5 when you weren't looking. What a jerk!");
                        myWallet -= 5;
                        totalProfit -= 5;
                    }
                    break;
            }
        }
    }
}
