using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace LemonadeStandTest
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void StartingStock_GeneratesListof120Items()
        {
            //arrange
            Inventory inventory = new Inventory();
            double expectedResult = 120;
            double actualResult;
            //act
            actualResult = inventory.allItems.Count;
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void NumberofItems_UnincludedItem_Returns0()
        {
            //arrange
            Inventory inventory = new Inventory();
            double expectedResult = 0;
            double actualResult;
            //act
            actualResult = inventory.NumberOfItems("salt");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void SubtractItem_Lemon_Returns9()
        {
            //arrange
            Inventory inventory = new Inventory();
            double expectedResult = 9;
            double actualResult;
            //act
            inventory.SubtractItemFromInventory("lemon");
            actualResult = inventory.NumberOfItems("lemon");
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
