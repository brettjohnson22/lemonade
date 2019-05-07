using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Welcome();
            game.RunWeek();
        }
    }
}
//What happens before a day starts?
//Player sees the forecast, sets a price, sets a recipe.
//
//Once player proceeds, the actual day triggers.
//What happens on an actual day?
//Actual weather is determined.
//Weather determines number of customers. Randomly choose from a range that depends on weather conditions.
//For each el in total number of customers, if (random), choose x, y, or z customer.
//Each customer decides if they will buy a cup.
//What factors determine customer "choice"?
//Base chance to buy, impacted by different factors.
//Temp, taste, price.



//You sold a cups at $b a piece, making you $c. Today's batch cost d, so you made a net profit of e. You now have f.
// a = customers. b = price. c = sales. d = cost * 8. e = c - d. f = wallet.