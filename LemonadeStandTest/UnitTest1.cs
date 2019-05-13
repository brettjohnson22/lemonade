using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace LemonadeStandTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PourCups_PositiveNumberofPitchers_ReturnsNumberTimes6()
        {
            //arrange
            Game.cupsPerPitcher = 6;
            //game.Welcome();
            Player player = new Player();
            double numberOfPitchers = 3;
            double expectedResult = numberOfPitchers * 6;
            double actualResult;

            //act
            actualResult = player.PourCups(numberOfPitchers);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void StartingRecipe_GeneratesListof23Items()
        {
            //arrange
            Recipe recipe = new Recipe();
            double expectedResult = 23;
            double actualResult;
            //act
            actualResult = recipe.recipeList.Count;
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }




    }
}
