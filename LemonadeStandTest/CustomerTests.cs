using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace LemonadeStandTest
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void AverageJoeLikeTheWeather_SunnyAndDry90_Returns3()
        {
            //arrange
            AverageJoe averageJoe = new AverageJoe();
            Weather weather = new Weather();
            weather.actualWeather = "sunny and dry";
            weather.temperature = 90;
            double expectedResult = 3;
            double actualResult;

            //act
            actualResult = averageJoe.LikeTheWeather(weather);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void CheapSkateLikeThePrice_Price5_ReturnNegative3()
        {
            //arrange
            CheapSkate cheapSkate = new CheapSkate();
            double price = 5;
            double expectedResult = -3;
            double actualResult;
            //act
            actualResult = cheapSkate.LikeThePrice(price);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void SweetToothLikeTheTaste_Sunnyand85BasicRecipe_Returns2()
        {
            //arrange
            SweetTooth sweetTooth = new SweetTooth();
            Weather weather = new Weather();
            weather.actualWeather = "sunny";
            weather.temperature = 85;
            Recipe recipe = new Recipe();
            double expectedResult = 2;
            double actualResult;

            //act
            actualResult = sweetTooth.LikeTheTaste(weather, recipe);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
           
    }
}
