using System;
using KomodoCafe_MenuRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private MenuItemsRepository _repo = new MenuItemsRepository();

        [TestMethod]
        public void AddToListIncreasesCount()
        {
            // Arrange
            // Set up the necessary pieces to run our code
            MenuItems item = new MenuItems(1, "food", "beef", "cow", 5.00m);

            // Act
            // Run code we want to make sure works
            _repo.AddMenuItemToList(item);

            // Assert - ensure a condition
            // AreEqual - value you expect, value you got from the code
            int test = _repo.GetMenuItemsList().Count;
            Assert.AreEqual(1, test);
        }

        [TestMethod]
        public void RemoveFromListIsTrue()
        {
            // Arrange
            MenuItems item = new MenuItems(1, "food", "beef", "cow", 5.00m);

            // Act
            _repo.AddMenuItemToList(item);

            // Assert
            bool testTwo = _repo.RemoveItemFromList("food");
            Assert.IsTrue(true, "food");
        }

        [TestMethod]
        public void UpdateToMenuItemIsTrue()
        {
            // Arrange
            MenuItems item = new MenuItems(1, "entree", "beef", "cow", 5.00m);

            // Act
            _repo.AddMenuItemToList(item);

            // Assert
            //bool itemTest = _repo.GetMenuItems("entree");
            //bool testThree = _repo.UpdateExistingMenuItem();


        }
    }
}
